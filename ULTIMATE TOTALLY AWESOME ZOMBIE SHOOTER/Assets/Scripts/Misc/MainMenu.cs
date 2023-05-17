using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LvlToLoad;
    public string Menu;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(LvlToLoad);
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(Menu);
    }

   public void QuitGame()
   {
    Application.Quit();
   }
}
