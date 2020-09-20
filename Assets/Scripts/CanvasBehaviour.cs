using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public Canvas canvas;
    public static CanvasBehaviour instance;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI scoreNumber;
    public TextMeshProUGUI highScoreNumber;
    public GameObject highScorePanel;
    public GameManager gameManager;
    public GameObject gameOverPanel;
    public GameObject hintPanel;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        Debug.Log("Stop breaking my game.");
        /*if (instance == null)
        {
            
        /*}
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(canvas.gameObject);*/
    }

    private void OnEnable()
    {

    }

    public void UpdateGameOverUI()
    {
        scoreNumber.text = scoreUI.text;

        Debug.Log(scoreNumber.text);
        Debug.Log(highScoreNumber.text);

        if (int.Parse(scoreNumber.text) > gameManager.GetHighScore())
        {
            highScorePanel.SetActive(true);
            PlayerPrefs.SetInt("HighScore", int.Parse(scoreNumber.text));
        }
        else
            highScorePanel.SetActive(false);

        highScoreNumber.text = gameManager.GetHighScore().ToString();
    }
}
