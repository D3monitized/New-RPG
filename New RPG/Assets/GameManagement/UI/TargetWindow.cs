using UnityEngine;
using UnityEngine.UI; 

public class TargetWindow : MonoBehaviour
{
    public Text targetName;
    public Image targetHealthbar; 
    
    public void OnTargetUpdated(Entity target)
    {
        if (target.Name != "")
            targetName.text = target.Name;
        else
            targetName.text = target.race.myRace.ToString();

        float currentHealth = target.currentHealth;
        float health = target.health;

        targetHealthbar.fillAmount = currentHealth / health; 
    }
    public void OnTargetRemoved()
    {
        targetName.text = "";
        targetHealthbar.fillAmount = 0;
    }
}
