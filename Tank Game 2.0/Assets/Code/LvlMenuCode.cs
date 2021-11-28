using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMenuCode : MonoBehaviour
{
   /* 
    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl1");
    }
    */
    public void PlayGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
        //sound
    }
}
