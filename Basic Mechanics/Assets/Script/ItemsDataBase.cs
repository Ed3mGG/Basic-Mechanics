using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public Item[] allItems;
    public static ItemsDataBase instance;

    //Permet d'acceder au script ItemsDataBase depuis n'importe où (appelé Singletone)
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ItemsDataBase dans la scène");
            return;
        }
        instance = this;
    }
}
