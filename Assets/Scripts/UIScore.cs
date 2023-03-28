using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
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
        TextMeshProGUI.text = GameManager.instance.score.ToString();
    }
}
