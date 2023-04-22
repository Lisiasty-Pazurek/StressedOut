using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPattern : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    public float x, y;
    private int[] movementStep = new int[4];
    
    public float speed;
    public PatternType patternType;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        x=myTransform.position.x; 
        y=myTransform.position.y;
        movementStep[0] = 0;
        movementStep[1] = 0;
        movementStep[2] = 0;
        movementStep[3] = 0;
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
            case PatternType.UpAndDownAndLeftRight:
                UpAndDownMovement();
                LeftRightMovement();
                break;
            default:
                break;
        }
    }

    void UpAndDownMovement()
    {
        if (movementStep[0] == 0)
        {
            if (y >= yMax)
                movementStep[0] = 1;
            else
                y += speed * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 1)
        {
            if (y <= yMin)
                movementStep[0] = 0;
            else
                y -= speed * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
    }

    void LeftRightMovement()
    {
        if (movementStep[1] == 0)
        {
            if (x >= xMax)
                movementStep[1] = 1;
            else
                x+=speed * Time.deltaTime;
                myTransform.position = new Vector3(x, y, 0); 
        }
        else if (movementStep[1] == 1)
        {
            if (x <= xMin)
                movementStep[1] = 0;
            else
                x-=speed * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
    }

    public enum PatternType
    {
        UpAndDown,
        LeftRight,
        UpAndDownAndLeftRight
    }
}
