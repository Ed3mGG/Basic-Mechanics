using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    public bool isInContact;
    public Text interactUI;


    void Awake() 
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
          
    }

    

    //Si collision détectée, isInContact = true
    private void OnTriggerEnter2D(Collider2D collision)
   {       
       if(collision.CompareTag("Player"))
       {
           interactUI.enabled = true;
           isInContact = true;  
       }
   }  
    //Si collision n'est plus détecté, isInContact = false
   private void OnTriggerExit2D(Collider2D collision) 
   {
       isInContact = false;   
       interactUI.enabled = false;    
   }


    // Permet de jouer une animation de FadeIn & Out pour remettre la caméra au point de spawn du player
   private void Update() 
   {     
       interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

       if(Input.GetKeyDown(KeyCode.E) && isInContact)
       {
        StartCoroutine(loadNextScene());
       }
   }
  
   public IEnumerator loadNextScene()
   {
       LoadAndSaveData.instance.SaveData();
       interactUI.enabled = false;
       fadeSystem.SetTrigger("FadeIn");
       yield return new WaitForSeconds(1f);
       SceneManager.LoadScene(sceneName);
    }
}
