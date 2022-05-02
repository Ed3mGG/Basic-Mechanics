using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;

    //Permet d'acceder au script LoadAndSaveData depuis n'importe où (appelé Singletone)
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);

        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
            int id = int.Parse(itemsSaved[i]);
            Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
            }
            
        }

        Inventory.instance.UpdateInventoryUI();
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        // Sauvegarde
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);
     


        
    }
   
}
