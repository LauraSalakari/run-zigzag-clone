using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private GameManager gameManager;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = gameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
