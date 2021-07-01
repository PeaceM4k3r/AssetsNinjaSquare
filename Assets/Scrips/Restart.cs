using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    Scene level1;
    


    public void RestartLevel()
    {
        SceneManager.LoadScene("Dungeon platt");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

}
