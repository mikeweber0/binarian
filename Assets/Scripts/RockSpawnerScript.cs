using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnerScript : MonoBehaviour
{
    public float rockTimer;
    private float privRockTimer;
    public GameObject rockPrefab;
    // Start is called before the first frame update

    void Start()
    {
        privRockTimer = rockTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerExpired())
        {
            spawnRock();
        }
    }

    void spawnRock()
    {
        float randomX = Random.Range(-3.8f, 3.8f);
        float randomY = Random.Range(3f, 4f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        int rockDecimalSpawn = Random.Range(0, 31);
        var spawnedRock = Instantiate(rockPrefab, spawnPosition, rockPrefab.transform.rotation, rockPrefab.transform.parent);
        spawnedRock.GetComponent<RockScript>().rockDecimal = rockDecimalSpawn;
    }

    bool timerExpired()
    {
        privRockTimer -= Time.deltaTime;
        if (privRockTimer <= 0)
        {
            privRockTimer = rockTimer;
            return true;
        }
        return false;
    }
}
