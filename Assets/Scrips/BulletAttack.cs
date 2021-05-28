using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
 
    public GameObject bullet;
    private Rigidbody2D rigid;
    public float bulletRange;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(bulletSpeed, 0f);

        if(gameObject.transform.position.x >= bulletRange)
        {
            Destroy(gameObject);
        }



    }
}
