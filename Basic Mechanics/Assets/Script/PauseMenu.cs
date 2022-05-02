using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool isGamePaused = false;

   public GameObject pauseMenuUI;

   public GameObject settingsWindow;

   private void Update() 
   {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
           if(isGamePaused)
           {
               Resume();
           }
           else
           {
               Paused();
           }
       }
   }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuBIS");
        Resume();        
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

}
