using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float moveSpeed;
    public int rockDecimal;
    public int laserCounter = 0;
    public int rockSum = 0;
    public int maxDigits = 5;
    public int baseNumber = 2;
    public GameObject rockDecimalText;
    public GameObject playerStats;
    private SpriteRenderer spriteRenderer;
    private Color myColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerStats = GameObject.Find("PlayerStats");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        offscreenDetection();
        if(rockDecimal != 6 && rockDecimal != 9)
        {
            rockDecimalText.GetComponent<TextMeshPro>().text = rockDecimal.ToString();
        }
        else
        {
            rockDecimalText.GetComponent<TextMeshPro>().text = rockDecimal.ToString() + ".";
        }
    }

    void Movement()
    {
        Vector3 movement = new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(0, 0, 40) * Time.deltaTime;
        transform.Translate(movement, Space.World);
        transform.Rotate(rotation);
    }

    void offscreenDetection()
    {
        if (transform.position.y <= -2.5 & transform.position.y >= -5)
        {
            if(spriteRenderer.color != myColor)
            {
                playerStats.GetComponent<PlayerStats>().TakeDamage(1f);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LaserLeft" | other.gameObject.tag == "LaserRight")
        {
            laserCounter++;
            if (other.gameObject.tag == "LaserLeft" & laserCounter <= maxDigits)
            {
                rockSum += 1 * (int) Math.Pow(baseNumber, maxDigits - laserCounter);
            }
            if (other.gameObject.tag == "LaserRight" & laserCounter <= maxDigits)
            {
                rockSum += 0 * (int)Math.Pow(baseNumber, maxDigits - laserCounter);
            }
            if (laserCounter == maxDigits)
            {
                if (rockSum == rockDecimal)
                {
                    rockSum = 0;
                    laserCounter = 0;
                    Destroy(gameObject);
                    GameManager.instance.score += 1;
                }
                else
                {
                    spriteRenderer.color = myColor;
                    rockDecimalText.GetComponent<TextMeshPro>().color = myColor;
                    playerStats.GetComponent<PlayerStats>().TakeDamage(1f);
                }
            }
            Destroy(other.gameObject);
        }
    }
}
