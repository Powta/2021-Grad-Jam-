// References
// www.youtube.com/watch?v=dwcT-Dch0bA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject myAudioManager;
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            myAudioManager.gameObject.GetComponent<AudioManager>().PlayGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag=="Enemy1"||collision.gameObject.tag=="Enemy2")
        {
            myAudioManager.gameObject.GetComponent<AudioManager>().PlayGameOver();
            Destroy(gameObject);
        }
      
    }
}
