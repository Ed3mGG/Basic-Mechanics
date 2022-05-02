using UnityEngine;
using UnityEngine.SceneManagement;

public class Crédits : MonoBehaviour
{

    public GameObject TextSkip;

    public bool ending = false;

    public void LoadMainMenu()
    {
        TextSkip.SetActive(true);
        ending = true;
    }

    public void Update() 
    {
        if(Input.anyKey && ending)
        {
            TextSkip.SetActive(false);
            SceneManager.LoadScene("MainMenuBIS");
            ending = false;
        }
    }
}
