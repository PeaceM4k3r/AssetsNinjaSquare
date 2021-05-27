using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Transform end;
    public GameObject objectToMove;
    public float speedMove;

    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //move from A to B
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end.position, speedMove * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            //Inicia calculo de daño
        }
    }
}
