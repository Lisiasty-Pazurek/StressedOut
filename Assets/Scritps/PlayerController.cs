using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Canvas gameCanvas;
    private Vector3 moveDirection;
    private Vector3 randomDirection; 
 
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

    public void RandomizeMovementDIrection()
    {
        randomDirection = Vector3(random.range(-1,1),random.range(-1,1),random.range(-1,1));
    }

    public void TakeBreath()
    {
        // do breathing action 
        
    }
}
