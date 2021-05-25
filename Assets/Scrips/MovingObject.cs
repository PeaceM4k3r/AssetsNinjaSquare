using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public Vector3 currentTarget;
    public float speedMove;


    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move from A to B
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, speedMove * Time.deltaTime);

        //update currentTarget
        if (objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }
        if (objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
    }
}
