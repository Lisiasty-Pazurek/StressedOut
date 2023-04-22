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
    public bool holdBreathe;
    public bool deepBreathe;
    private Vector3 moveDirection;
    private Vector3 randomDirection;
    private Vector3 randomDir;

    [Header("Scaling setup")]
    public int moveSpeed;
    public float breathSpeed;
    public float unstressLevel;
    public float breatheMaxTime;
    public float holdBreatheTime;
    public float holdBreatheMaxTime;
    public float maxSize;

    public float defaultMinBreath = 1;
    public float defaultMaxBreath = 4;
    public float deepMaxBreath = 4;

    public float forceScale = 5;
    public float forceScaleDeepBreath = 0.5f;
    public float forceScaleHoldBreath = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

        if (inhale)
        {

            if (this.gameObject.transform.localScale.x >= defaultMaxBreath && !deepBreathe)
                inhale = false;
            else
            {
                this.gameObject.transform.localScale += new Vector3(breathSpeed, breathSpeed, 0);

                if (Input.GetMouseButton(0) && this.gameObject.transform.localScale.x < deepMaxBreath)
                {
                    deepBreathe = true;
                }
                else
                {
                    deepBreathe = false;
                }

            }
        }
        if (!inhale)
        {
            if (this.gameObject.transform.localScale.x < defaultMinBreath)
            {
                if (Input.GetMouseButton(1) && holdBreatheTime < holdBreatheMaxTime)
                {
                    holdBreatheTime += Time.deltaTime;
                    holdBreathe = true;
                }
                else
                {
                    holdBreatheTime = 0;
                    inhale = true;
                    holdBreathe = false;
                }
            }
            else
            {
                this.gameObject.transform.localScale -= new Vector3(breathSpeed, breathSpeed, 0);

            }
        }

        //if (Input.GetMouseButtonDown(0) && breathTime < breatheMaxTime)
        //{
        //    OnInhale();
        //}
        //if (Input.GetMouseButtonUp(0) || breathTime >= breatheMaxTime)
        //{
        //    OnExhale();
        //}

    }

    void Movement()
    {
        moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 force;
        if (deepBreathe)
            force = moveDirection * forceScaleDeepBreath;
        else if (holdBreathe)
            force = moveDirection * forceScaleHoldBreath;
        else
            force = moveDirection * forceScale;

        rb.velocity = force;

        //moveDirection = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5);
        // rb.MovePosition(moveDirection);

        // rb.AddForce(force * forceScale);
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
        levelController.stressLevel -= breathSpeed * unstressLevel;
        breathSpeed = 0;

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
