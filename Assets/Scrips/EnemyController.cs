using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform startRoute;
    public Transform endRoute;
    public GameObject Enemy;
    private Animator thisAnimator;


    private Vector3 currentTarget;
    public float moveSpeed = 5f;


    public int maxHP = 5;
    public int currentHP;





    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = Enemy.GetComponent<Animator>();
        currentTarget = endRoute.transform.position;
        currentHP = maxHP;

        LookForward();
    }

    // Update is called once per frame
    void Update()
    {
        // from actual to currentTarget
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, currentTarget, moveSpeed * Time.deltaTime);
        
        
        if(Enemy.transform.position == endRoute.transform.position)
        {
            currentTarget = startRoute.position;
            LookForward();
        }

        if (Enemy.transform.position == startRoute.position)
        {
            currentTarget = endRoute.position;
            LookForward();
        }




        thisAnimator.SetFloat("speed", moveSpeed);
    }



    void LookForward()
    {
        if (currentTarget.x < Enemy.transform.position.x)
        {
            Enemy.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        if (currentTarget.x > Enemy.transform.position.x)
        {
            Enemy.transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
    }


    



}
