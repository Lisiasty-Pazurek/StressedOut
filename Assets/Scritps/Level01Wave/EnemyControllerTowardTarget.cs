using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerTowardTarget : MonoBehaviour
{
    private Rigidbody2D rb;
    public CircleCollider2D eCollider;
    public float stressPower;
    public Transform moveDestination;

    public LevelController levelController;

    public float maxSpeed;
    public float forceModifier;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelController = FindObjectOfType<LevelController>();
        // moveDestination = new Vector2(Random.Range(-maxSpeed,maxSpeed),Random.Range(-maxSpeed,maxSpeed));

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = (MoveDestination2D - CurrentPosition2D);
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * forceModifier);
        }

        eCollider.enabled = !levelController.gameEnded;

    }

    private Vector2 MoveDestination2D { get { return new Vector2(moveDestination.position.x, moveDestination.position.y); } }
    private Vector2 CurrentPosition2D { get { return new Vector2(transform.position.x, transform.position.y); } }
    public void ChangeDestination()
    {
        //moveDestination = new Vector2(Random.Range(-maxSpeed,maxSpeed),Random.Range(-maxSpeed,maxSpeed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //ChangeDestination();
    }
}
