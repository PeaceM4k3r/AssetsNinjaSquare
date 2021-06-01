using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 1f;
    private Rigidbody2D thisRigid;




    // Start is called before the first frame update
    void Start()
    {
        thisRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        thisRigid.velocity = new Vector2(bulletSpeed, 0f);
        Destroy(gameObject, bulletLifeTime);
    }


    




}
