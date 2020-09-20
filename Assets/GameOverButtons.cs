using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public GameObject panel;
    public GameManager gameManager;

    public void PlayAgain()
    {
        panel.SetActive(false);
        gameManager.EndGame();
    }
}
