using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public CircleCollider2D eCollider;    
    public float stressPower;
    public Vector2 moveDestination;

    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDestination = new Vector2(Random.Range(-maxSpeed,maxSpeed),Random.Range(-maxSpeed,maxSpeed));
      
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveDestination);  
    }

    public void ChangeDestination()
    {
        moveDestination = new Vector2(Random.Range(-maxSpeed,maxSpeed),Random.Range(-maxSpeed,maxSpeed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ChangeDestination();
    }
}
