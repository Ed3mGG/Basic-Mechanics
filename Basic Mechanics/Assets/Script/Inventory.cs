using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public List<Item> content = new List<Item>();
    private int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemNameUI;
    public Text previousItemText;
    public Text nextItemText;

    public PlayerEffect playerEffects;


    public static Inventory instance;

    //Permet d'acceder au script Inventory depuis n'importe où
    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    private void Start() 
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealingPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        playerEffects.AddJumpForce(currentItem.jumpForceGiven, currentItem.jumpForceDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
            previousItemText.text = "<";
            nextItemText.text = ">";
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
            previousItemText.text = "";
            nextItemText.text = "";
        }
        
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI(); 

    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString(); // ToString() transforme le int en string
    }
}
