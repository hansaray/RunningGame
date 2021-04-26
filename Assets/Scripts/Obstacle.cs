﻿using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Kill the player
            playerMovement.Die();
        }
    }


    void Update()
    {
        
    }
}
