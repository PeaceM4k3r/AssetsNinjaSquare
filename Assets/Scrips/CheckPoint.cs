using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite cpOff;
    public Sprite cpOn;

    public SpriteRenderer spriteSelector;



    // Start is called before the first frame update
    void Start()
    {
        spriteSelector = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteSelector.sprite = cpOn;
        }
    }


}
