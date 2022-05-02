using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;

    //Permet d'acceder au script GameOverManager depuis n'importe où (appelé Singletone)
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }
        instance = this;
    }
    //a la mort du personnage, désactive l'UI
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }
    
    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        //recommencer le niveau
        //Recharge la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Replace le joueur au spawn
        //Réactive les mouvements du joueur
        PlayerHealth.instance.Respawn();
        //Redonner les pdvs
        //Désactive l'UI GameOver
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
}
