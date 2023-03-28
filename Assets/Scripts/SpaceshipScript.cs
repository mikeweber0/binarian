using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public GameObject laserObjectLeft;
    public GameObject laserObjectRight;
    public GameObject laserSpawnerLeft;
    public GameObject laserSpawnerRight;
    public GameObject playerStats;
    private Color myColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -4, 4);
        position.y = Mathf.Clamp(position.y, -2, 2);
        transform.position = position;
    }

    void Shooting()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserObjectLeft, laserSpawnerLeft.transform.position, laserSpawnerLeft.transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(laserObjectRight, laserSpawnerRight.transform.position, laserSpawnerRight.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            if(other.gameObject.GetComponent<SpriteRenderer>().color != myColor)
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<FlashScript>().Flash();
                playerStats.GetComponent<PlayerStats>().TakeDamage(1f);
            }
        }
    }

}
