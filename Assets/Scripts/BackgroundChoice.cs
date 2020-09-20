using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChoice : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject aquapink;

    private void Awake()
    {
        int choice = (int)Random.Range(1.0f, 3.99f);

        if(!aquapink.activeSelf && !red.activeSelf && !blue.activeSelf)
        {
            if (choice == 1)
            {
                aquapink.SetActive(true);
            }
            else if (choice == 2)
            {
                red.SetActive(true);
            }
            else
            {
                blue.SetActive(true);
            }
        }
    }
}
