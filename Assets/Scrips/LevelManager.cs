using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //respawn
    public float waitToRespawn;
    public PlayerController thePlayer;
    //HP Player
    public int maxHp;
    public int currentHp;
    //Dead Efect
    public GameObject deadParticleEffect;


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
        thePlayer.gameObject.SetActive(true);
    }

    public void HurtPlayer(int damageToTake)
    {
        //Debug.Log("Damage Taken = " + damageToTake);
        currentHp -= damageToTake;
        Debug.Log("HP: " + currentHp + "/" + maxHp);
    }

}
