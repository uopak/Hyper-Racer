using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gasText;
    public PlayerController player;

    private int gas = 100;
    private bool isGameRunning = false;
    
    public bool IsGameRunning => isGameRunning; // 게임 상태 확인용 프로퍼티

    void Start()
    {
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        UpdateGasText();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        isGameRunning = true;
        player.StartMoving();
        StartCoroutine(ConsumeGas());
    }

    public void GameOver()
    {
        isGameRunning = false;
        player.StopMoving();
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ConsumeGas()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(1f);
            gas -= 10;
            UpdateGasText();
            if (gas <= 0)
            {
                GameOver();
            }
        }
    }

    public void AddGas(int amount)
    {
        gas += amount;
        if (gas > 100) gas = 100;
        UpdateGasText();
    }

    private void UpdateGasText()
    {
        gasText.text = "Gas: " + gas;
    }
}
