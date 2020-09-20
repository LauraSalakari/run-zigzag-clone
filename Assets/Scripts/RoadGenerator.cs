using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPosition;
    public float offset = 0.67f;

    private int roadCount;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.4f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance < 50)
        {
            spawnPos = new Vector3(lastPosition.x + offset, lastPosition.y, lastPosition.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z + offset);
        }

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPosition = g.transform.position;

        roadCount++;

        float crystalChance = Random.Range(0, 100);

        if(roadCount % 3 == 0 && crystalChance > 40)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
