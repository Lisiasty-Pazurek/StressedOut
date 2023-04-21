using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPattern : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    public float x, y;
    public float movementStep;
    public float speed;
    public PatternType patternType;

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        x=transform.position.x; 
        y=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch (patternType)
        {
            case PatternType.UpAndDown:
                UpAndDownMovement();
                break;
            case PatternType.LeftRight:
                LeftRightMovement();
                break;
            default:
                break;
        }
    }

    void UpAndDownMovement()
    {
        if (movementStep == 0)
        {
            if (y >= yMax)
                movementStep = 1;
            else
                y += speed * Time.deltaTime;
            transform.position = new Vector3(x, y, 0);
        }
        else if (movementStep == 1)
        {
            if (y <= yMin)
                movementStep = 0;
            else
                y -= speed * Time.deltaTime;
            transform.position = new Vector3(x, y, 0);
        }
    }

    void LeftRightMovement()
    {
        if (movementStep == 0)
        {
            if (x >= xMax)
                movementStep = 1;
            else
                x+=speed * Time.deltaTime;
                transform.position = new Vector3(x, y, 0); 
        }
        else if (movementStep == 1)
        {
            if (x <= xMin)
                movementStep = 0;
            else
                x-=speed * Time.deltaTime;
            transform.position = new Vector3(x, y, 0);
        }
    }

    public enum PatternType
    {
        UpAndDown,
        LeftRight
    }
}
