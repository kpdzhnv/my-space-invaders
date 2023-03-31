using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsMovement : MonoBehaviour
{
    public float leftX, rightX;
    public int speed;
    private Vector3 leftPoint, rightPoint;
    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = Random.value > 0.5f;
        leftPoint = transform.position;
        rightPoint = transform.position;
        leftPoint.x = leftX * 2; // far & unreachable 
        rightPoint.x = rightX * 2; // far & unreachable
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.childCount == 0)
            Destroy(gameObject);

        if (movingRight)
        {
            Debug.Log("right");
            // actually it is possible to check every child for the borders
            // but they are instantiated from left to right, so...
            if (transform.GetChild(transform.childCount - 1).transform.position.x >= rightX)
                movingRight = false;
            transform.position = Vector3.MoveTowards(transform.position, rightPoint, 1.0f / speed);
        }
        else
        {
            Debug.Log("left");
            if (transform.GetChild(0).transform.position.x <= leftX)
                movingRight = true;
            transform.position = Vector3.MoveTowards(transform.position, leftPoint, 1.0f / speed);

        }

    }

}
