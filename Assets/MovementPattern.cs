using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPattern : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    public float x, y;
    public int[] movementStep = new int[4];

    public float[] speed = new float[4];
    public PatternType patternType;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        x = myTransform.position.x;
        y = myTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO if inhale => return;
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
            case PatternType.SquareClockwise:
                ClockWise();
                break;
            case PatternType.SquareCounterClockwise:
                CounterClockWise();
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
                y += speed[0] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 1)
        {
            if (y <= yMin)
                movementStep[0] = 0;
            else
                y -= speed[0] * Time.deltaTime;
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
                x += speed[1] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[1] == 1)
        {
            if (x <= xMin)
                movementStep[1] = 0;
            else
                x -= speed[1] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
    }

    void ClockWise()
    {
        if (movementStep[0] == 0)
        {
            if (x >= xMax)
                movementStep[0] = 1;
            else
                x += speed[0] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 1)
        {
            if (y <= yMin)
                movementStep[0] = 2;
            else
                y -= speed[1] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 2)
        {
            if (x <= xMin)
                movementStep[0] = 3;
            else
                x -= speed[2] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 3)
        {
            if (y >= yMax)
                movementStep[0] = 0;
            else
                y += speed[3] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
    }

    void CounterClockWise()
    {
        if (movementStep[0] == 2)
        {
            if (x >= xMax)
                movementStep[0] = 3;
            else
                x += speed[2] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 1)
        {
            if (y <= yMin)
                movementStep[0] = 2;
            else
                y -= speed[1] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 0)
        {
            if (x <= xMin)
                movementStep[0] = 1;
            else
                x -= speed[0] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
        else if (movementStep[0] == 3)
        {
            if (y >= yMax)
                movementStep[0] = 0;
            else
                y += speed[3] * Time.deltaTime;
            myTransform.position = new Vector3(x, y, 0);
        }
    }

    public enum PatternType
    {
        UpAndDown,
        LeftRight,
        UpAndDownAndLeftRight,
        SquareClockwise,
        SquareCounterClockwise
    }
}
