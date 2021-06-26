using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("TestLevel");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

}
