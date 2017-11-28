using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1f;
    public float paddleStrength = 75f;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
    public Rigidbody ballRB;

    // Update is called once per frame
    private void Start()
    {
        //ballRB = GetComponentInChildren<Rigidbody>();
        
          
    }

    void Update ()
    {
        float xPos = transform.position.x + (Input.GetAxisRaw("Horizontal")) * paddleSpeed;
        playerPos = new Vector3(Mathf.Clamp(xPos, -6f, 11f), -9.5f, 0);
        transform.position = playerPos;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ball")
        {
            ContactPoint contact = collision.contacts[0];
            if(contact.point.x > transform.position.x)
            {
                Debug.Log("Hit ball right");
                ballRB.AddForce(transform.right * paddleStrength);
            }
            else if(contact.point.x < transform.position.x)
            {
                Debug.Log("Hit ball left");
                ballRB.AddForce(transform.right * -paddleStrength);


            }
        }
    }
}
