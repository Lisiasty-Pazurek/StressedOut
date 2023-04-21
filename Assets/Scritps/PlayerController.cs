using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public LevelController levelController;
    private Rigidbody2D rb;

    [Header("Attributes")]
    public bool inhale;
    private Vector3 moveDirection;
    private Vector3 randomDirection;
    private Vector3 randomDir;

    [Header("Scaling setup")]
    public int moveSpeed;
    public float breathTime;
    public float unstressLevel;
    public float breatheMaxTime;
    public float maxSize;
    public float basicScale = 2;

    public float forceScale = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (inhale)
        {
            breathTime += Time.deltaTime;
            this.gameObject.transform.localScale += new Vector3(breathTime * (1 / maxSize), breathTime * (1 / maxSize), 0);

        }
        if (!inhale)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, new Vector3(basicScale, basicScale, 0), Time.deltaTime);
        }


        if (Input.GetMouseButtonDown(0) && breathTime < breatheMaxTime)
        {
            OnInhale();
        }
        if (Input.GetMouseButtonUp(0) || breathTime >= breatheMaxTime)
        {
            OnExhale();
        }

    }

    void Movement()
    {
        //moveDirection = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5);
        moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // rb.MovePosition(moveDirection);

        Vector2 force = moveDirection;

        // rb.AddForce(force * forceScale);
        rb.velocity = moveDirection * forceScale;
        //        rb.AddForce(randomDirection);
    }

    public void RandomizeMovementDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }

    public void OnInhale()
    {

        inhale = true;
        // do breathing action
    }

    public void OnExhale()
    {
        inhale = false;
        levelController.stressLevel -= breathTime * unstressLevel;
        breathTime = 0;

    }



    private void Pulse()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<EnemyController>() != null)
        {
            levelController.stressLevel += other.gameObject.GetComponent<EnemyController>().stressPower;
        }

        if (other.gameObject.GetComponent<EnemyControllerTowardTarget>() != null)
        {
            levelController.stressLevel += other.gameObject.GetComponent<EnemyControllerTowardTarget>().stressPower;
        }
    }
}
