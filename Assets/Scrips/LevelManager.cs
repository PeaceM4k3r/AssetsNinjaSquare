using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //respawn
    public float waitToRespawn;
    private PlayerController thePlayer;
    //HP Player
    public int maxHp = 6;
    public int currentHp;
    //Dead Efect
    public GameObject deadParticleEffect;


    // HUD
    // HP Bar
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite hFull;
    public Sprite hHalf;
    public Sprite hEmpty;







    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        




    }

    public void respawnPlayer()
    {
        
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        Instantiate(deadParticleEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        thePlayer.transform.position = thePlayer.respawnCoords;
        currentHp = maxHp;
        hpUpdate();
        thePlayer.gameObject.SetActive(true);
        //Debug.Log("HP: " + currentHp + "/" + maxHp);
    }

    public void HurtPlayer(int damageToTake)
    {
        //Debug.Log("Damage Taken = " + damageToTake);
        currentHp -= damageToTake;
        Debug.Log("HP: " + currentHp + "/" + maxHp);
        hpUpdate();

    }

    public void hpUpdate()
    {
        if (currentHp <= 0)
        {
            Heart1.sprite = hEmpty;
            Heart2.sprite = hEmpty;
            Heart3.sprite = hEmpty;
            respawnPlayer();
        }
        if (currentHp == 1)
        {
            Heart1.sprite = hHalf;
            Heart2.sprite = hEmpty;
            Heart3.sprite = hEmpty;
        }
        if (currentHp == 2)
        {
            Heart1.sprite = hFull;
            Heart2.sprite = hEmpty;
            Heart3.sprite = hEmpty;
        }
        if (currentHp == 3)
        {
            Heart1.sprite = hFull;
            Heart2.sprite = hHalf;
            Heart3.sprite = hEmpty;
        }
        if (currentHp == 4)
        {
            Heart1.sprite = hFull;
            Heart2.sprite = hFull;
            Heart3.sprite = hEmpty;
        }
        if (currentHp == 5)
        {
            Heart1.sprite = hFull;
            Heart2.sprite = hFull;
            Heart3.sprite = hHalf;
        }
        if (currentHp == 6)
        {
            Heart1.sprite = hFull;
            Heart2.sprite = hFull;
            Heart3.sprite = hFull;
        }

    }


}
