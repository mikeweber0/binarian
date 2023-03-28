using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    private TextMeshProUGUI TextMeshProGUI;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver && TextMeshProGUI.enabled == false)
        {
            TextMeshProGUI.enabled = true;
            GameManager.instance.restartGame = true;
        }
    }
}
