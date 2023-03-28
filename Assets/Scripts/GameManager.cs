using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject spaceshipObject;
    public GameObject playerStats;
    public int score;
    public bool gameOver = false;
    public bool restartGame = false;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        restartHandler();
        deathHandler();
    }

    void restartHandler()
    {
        if (restartGame)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void deathHandler()
    {
        if(playerStats.GetComponent<PlayerStats>().Health == 0f)
        {
            Destroy(spaceshipObject);
            gameOver = true;
        }
    }
}
