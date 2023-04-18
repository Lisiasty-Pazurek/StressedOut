using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public CircleCollider2D eCollider;
    public Vector2 moveDestination;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDestination = new Vector2(Random.Range(0,3),Random.Range(0,5));
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveDestination);
    }
}
