using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform startRoute;
    public Transform endRoute;
    //public GameObject Enemy;
    private Animator thisAnimator;
    public bool takenDMG = false;

    private Vector3 currentTarget;
    public float moveSpeed = 5f;

    private CapsuleCollider2D capsule; 

    public int maxHP = 6;
    public int currentHP;
    public int invTime;



    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        thisAnimator = GetComponent<Animator>();
        currentTarget = endRoute.transform.position;

        currentHP = maxHP;
        Debug.Log("BoarHP: " + currentHP + "/" + maxHP);
        
        LookForward();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }

        // from actual to currentTarget
        if (!takenDMG)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
        }



        if (transform.position == endRoute.transform.position)
        {
            currentTarget = startRoute.position;
            LookForward();
        }

        if (transform.position == startRoute.position)
        {
            currentTarget = endRoute.position;
            LookForward();
        }




        thisAnimator.SetFloat("speed", moveSpeed);
        thisAnimator.SetBool("takenDmg", takenDMG);
    }



    void LookForward()
    {
        if (currentTarget.x < transform.position.x)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        if (currentTarget.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletPlayer")
        {
            if (!takenDMG)
            { 
                StartCoroutine(invencibilityFrames());
                currentHP -= 1;
                Debug.Log("BoarHP: " + currentHP + "/" + maxHP);
                Destroy(collision.gameObject);
            }

        }
    }

    public IEnumerator invencibilityFrames()
    {

        takenDMG = true;

        yield return new WaitForSeconds(invTime);

        takenDMG = false;

    }

}
