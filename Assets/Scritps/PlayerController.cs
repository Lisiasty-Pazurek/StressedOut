using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header ("References")]
    public LevelController levelController;
    private Rigidbody2D rb;


    public bool inhale;
    private Vector3 moveDirection;
    private Vector3 randomDirection; 
    public float scalingParameter = 1;

 
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) + randomDirection;
        rb.MovePosition(moveDirection);
    }

    public void RandomizeMovementDirection()
    {
        randomDirection = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
    }

    public bool TakeBreath()
    {
        inhale = true;
        // do breathing action 
        this.gameObject.transform.localScale *= scalingParameter;
        return true;
    }

    private void Pulse()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        levelController.stressLevel +=10;
    }
}
