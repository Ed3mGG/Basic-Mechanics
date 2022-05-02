using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScene : MonoBehaviour
{

    public GameObject TextSkip;
    public float timer;

    public void Update() 
    {
        if(Input.anyKey)
        {
            TextSkip.SetActive(false);
            SceneManager.LoadScene("MainMenuBIS");
        }

        timer = timer + Time.deltaTime;
        if (timer >= 0.5)
        {
            TextSkip.SetActive(true);
        }
        if (timer >= 1)
        {
            TextSkip.SetActive(false);
            timer = 0;
        }


    }    
}
