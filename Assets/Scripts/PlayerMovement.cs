using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    bool isWalkingRight = true;
    public Transform rayStart;
    private Animator anim;
    private GameManager gameManager;
    public GameObject crystalEffect;
    public AudioSource crystalAudio;
    public AudioSource footsteps;
    public GameObject hintPanel;

    private bool didUpdateGameOverUI = false;
    static bool gameReset = false;


    private bool isRunning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            if (gameReset)
            {
                //CanvasBehaviour.instance.gameOverPanel.SetActive(true);
                //gameOverPanel.SetActive(true);
                gameReset = false;
            }

            if (CanvasBehaviour.instance.gameOverPanel.activeSelf)
            {
                CanvasBehaviour.instance.hintPanel.SetActive(false);
            }
            else
            {
                CanvasBehaviour.instance.hintPanel.SetActive(true);
            }

            return;
        }
        else
        {
            anim.SetTrigger("GameStarted");
            isRunning = true;
            CanvasBehaviour.instance.hintPanel.SetActive(false);
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void Update()
    {
        PlayFootsteps();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchDirection();
        }

        RaycastHit hit;

        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("IsFalling");
            isRunning = false;
        }
        else
        {
            anim.SetTrigger("NotFallingAnymore");
        }

        if (transform.position.y < -10)
        {
            gameReset = true;
            if (!didUpdateGameOverUI)
            {
                CanvasBehaviour.instance.UpdateGameOverUI();
                didUpdateGameOverUI = true;
                CanvasBehaviour.instance.gameOverPanel.SetActive(true);
            }
            //if(Input.GetKeyDown(KeyCode.Return))
              //  gameManager.EndGame();
        }
    }

    void SwitchDirection()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        isWalkingRight = !isWalkingRight;

        if (isWalkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.tag == "Crystal")
        {
            anim.SetTrigger("IsNearCrystal");
            crystalAudio.Play();
            gameManager.IncreaseScore();
            GameObject g = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 1);
            Destroy(other.gameObject, 0.2f);    
        }
    }

    private void PlayFootsteps()
    {
        if (isRunning)
        {
            if (!footsteps.isPlaying)
            {
                footsteps.mute = false;
                footsteps.Play();
            }
        }
        else
        {
            footsteps.mute = true;
        }
    }
}
