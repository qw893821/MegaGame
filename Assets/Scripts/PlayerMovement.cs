﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //player movement properity
    public float speed;
    public float gravity;
    public float jumpSpeed;

    //player gameobject
    public GameObject player;
    public Rigidbody playerRig;
    //get player location
    public Transform playerTrans;

    //player movement direction
    public Vector3 horiMovement;
    public Vector3 vertMovement;
    //player dash properity
    public float dash;
    float dashTime;
    float dashDuration;
    bool isDash;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        playerRig = player.GetComponent<Rigidbody>();
        speed = 20.0f;
        jumpSpeed = 20.0f;
        gravity = 10.0f;
        dash = 5f;
        dashTime = 0f;
        dashDuration = 0.5f;
        isDash = false;
	}

    private void FixedUpdate()
    {        
        
        HorizontalMove();
        PlayerJump();
        PlayerDash();
    }

    void HorizontalMove()
    {
        float h;
        h = Input.GetAxisRaw("Horizontal");
        horiMovement.Set(h, 0f, 0f);
        horiMovement = horiMovement.normalized * speed * Time.deltaTime;
        playerRig.AddForce(horiMovement,ForceMode.Impulse);
        
    }

    void PlayerJump()
    {
        float v;
        v = Input.GetAxisRaw("Jump");
        vertMovement.Set(0f, v, 0f);
        vertMovement = vertMovement.normalized * jumpSpeed * Time.deltaTime;
        playerRig.AddForce(vertMovement,ForceMode.Impulse);
    }
    void PlayerDash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            isDash = true;
        }
        if(isDash)
        {
            
            
            dashTime += Time.deltaTime;
            if (isDash&&dashTime<dashDuration)
            {
                Vector3 dashDir;
                dashDir = new Vector3(playerRig.transform.position.x, 0f, 0f);
                dashDir = dashDir.normalized;
                playerRig.MovePosition(playerRig.transform.position+dashDir*dash*Time.deltaTime);
                print(dashDir);
            }
            else if (dashTime > dashDuration)
            {
                isDash = false;
                dashTime = 0f;
            }
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}