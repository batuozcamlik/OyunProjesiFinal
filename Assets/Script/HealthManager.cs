using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public HealthSO playerHealth; 
    public Image healtBarImage;

  
    public HealthSO[] allPlayerHealt;
    public GameObject player;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged.RemoveListener(UpdateHealthUI); 
    }

    private void UpdateHealthUI(int currentHealth)
    {
       healtBarImage.fillAmount= (float)currentHealth / playerHealth.maxHealth;
    }

    public void Update()
    {
        playerHealth.OnHealthChanged.AddListener(UpdateHealthUI);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerHealth = allPlayerHealt[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerHealth = allPlayerHealt[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerHealth = allPlayerHealt[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerHealth = allPlayerHealt[3];
        }

        player.GetComponent<SpriteRenderer>().color = playerHealth.color;
        FindAnyObjectByType<HealthTester>().playerHealth = playerHealth;
    }
}
