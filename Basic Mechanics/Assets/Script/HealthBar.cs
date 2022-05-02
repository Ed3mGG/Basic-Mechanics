using UnityEngine;
using UnityEngine.UI; //Permet d'utiliser Slider & autres 

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // ** Permet de changer la couleur de la barre de pdv
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health) // Initialisation de la barre d'HP au max en lançant le jeu
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f); // ** Suite du changement de couleur de la barre de pdv 
    }

    public void SetHealth(int health) // Indique à la barre d'HP le nombre de pdv à afficher
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); // **
    }
}
