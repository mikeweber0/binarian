using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        offscreenDetection();
    }

    void Movement()
    {
        Vector3 movement = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void offscreenDetection()
    {
        if (transform.position.y >= 2.5)
        {
            Destroy(gameObject);
        }
    }
}
