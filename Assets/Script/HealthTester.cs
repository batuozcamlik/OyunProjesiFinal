using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTester : MonoBehaviour
{
    public HealthSO playerHealth;

    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI oldText, newText;

    void Update()
    {
        #region Test Code
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth.Heal(10); 
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerHealth.TakeDamage(10); 
        }
        #endregion
    }

    public void takeDmg()
    {
        playerHealth.TakeDamage(10); 
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score==0)
        {
            oldText.text ="";
            newText.text = (score + 1).ToString();
        }
        else
        {
            oldText.text = (score - 1).ToString();
            newText.text = (score + 1).ToString();
        }
        
    }
}
