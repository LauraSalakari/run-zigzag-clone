using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI scoreNumber;
    public TextMeshProUGUI highScoreNumber;

    private void Awake()
    {
        highScoreUI.text = "BEST: " + GetHighScore().ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadGenerator>().StartBuilding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(1);
    }

    public void IncreaseScore()
    {
        score++;
        scoreUI.text = score.ToString();

        if (score > GetHighScore())
        {
            highScoreUI.text = "BEST: " + score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
