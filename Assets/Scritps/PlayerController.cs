using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header ("References")]
    public LevelController levelController;
    private Rigidbody2D rb;

    public int moveSpeed;
    public float breathTime;

    public bool inhale;
    private Vector3 moveDirection;
    private Vector3 randomDirection; 
    private Vector3 randomDir;
    public float scalingParameter = 2;

 
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
            this.gameObject.transform.localScale += new Vector3(breathTime/5,breathTime/5,0);
                  
        }
        if (!inhale)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, new Vector3(scalingParameter, scalingParameter, 0), Time.deltaTime);            
        }


        if (Input.GetMouseButtonDown(0))
        {
            OnInhale();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnExhale();
        }

    }

    void Movement()
    {
        moveDirection = Vector3.Lerp(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition), 5);
        rb.MovePosition(moveDirection);
//        rb.AddForce(randomDirection);
    }

    public void RandomizeMovementDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        
    }

    public void OnInhale()
    {

        inhale = true;
        // do breathing action
    }

    public void OnExhale()
    {
        inhale = false;
        levelController.stressLevel -=breathTime;
        breathTime = 0;

    }

    

    private void Pulse()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        levelController.stressLevel +=10;
    }
}
