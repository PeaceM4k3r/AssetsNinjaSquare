using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followAhead;
    public float smoothing;
    public float cameraY;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);


                if (target.transform.localScale.x > 0f) // Right
                {
                    targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);

                }
                else //  Left
                {
                    targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
                }

                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    
        /*

        if (target.transform.position.y > cameraY) // up
        {
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
        else  // floor lvl
        {
            targetPosition = new Vector3(target.transform.position.x, cameraY, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        */






    }


}
