using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData = new PlayerData();
    [SerializeField] private Text levelValue;
    [SerializeField] private Text healthValue;
    [SerializeField] private Text[] posValues = new Text[3];


    public void IncreaseLevel()
    {
        playerData.Level++;
        UpdateLevelGuiValue();
    }

    public void DecreaseLevel()
    {
        playerData.Level--;
        UpdateLevelGuiValue();
    }

    public void IncreaseHealth()
    {
        playerData.Health++;
        UpdateHealthGuiValue();
    }

    public void DecreaseHealth()
    {
        playerData.Health--;
        UpdateHealthGuiValue();
    }

    public void GenerateRandomPosition()
    {
        for (int i = 0; i < playerData.Position.Length; i++)
        {
            playerData.Position[i] = Random.Range(1.0f, 100.0f);
        }

        UpdatePositionGuiValues();
    }

    private void UpdateLevelGuiValue()
    {
        levelValue.text = playerData.Level.ToString();
    }

    private void UpdateHealthGuiValue()
    {
        healthValue.text = playerData.Health.ToString();
    }
    private void UpdatePositionGuiValues()
    {
       for(int i = 0; i < posValues.Length; i++)
        {
            posValues[i].text = playerData.Position[i].ToString("00.00");
        }
    }

    public void SavePlayerData()
    {
        SaveController.SavePlayerData(playerData);
    }

    public void LoadPlayerData()
    {
        playerData = SaveController.LoadPlayerData();
        UpdateHealthGuiValue();
        UpdateLevelGuiValue();
        UpdatePositionGuiValues();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
