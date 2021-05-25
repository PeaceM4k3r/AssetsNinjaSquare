using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTimer : MonoBehaviour
{
    public float autoDestruccionTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (autoDestruccionTimer <= 0f)
        {
            Destroy(gameObject);
        }
        autoDestruccionTimer = autoDestruccionTimer - Time.deltaTime;

    }
}
