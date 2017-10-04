using System.Collections;
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

    //on ground check
    public bool onGround;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        playerRig = player.GetComponent<Rigidbody>();
        speed = 8.0f;
        jumpSpeed = 30.0f;
        gravity = 10.0f;
        dash = 5f;
        dashTime = 0f;
        dashDuration = 0.5f;
        isDash = false;
        onGround = true;
	}

    private void FixedUpdate()
    {        
        
        HorizontalMove();
        PlayerJump();
        PlayerDash();
    }

    void HorizontalMove()
    {
        bool turning;
        turning = false;
        Vector3 prePos;
        float h;
        h = Input.GetAxisRaw("Horizontal");
        horiMovement.Set(h, 0f, 0f);
        horiMovement = horiMovement.normalized * speed * Time.deltaTime;
        playerRig.MovePosition(transform.position+horiMovement);
        prePos = transform.position;
        if (h<0&&transform.rotation.y==0)
        {
            
            transform.rotation = Quaternion.Euler(0,180f,0);
            //transform.position += new Vector3(1f, 0, 0);
            turning = true;
        }
        else if (h>0 && transform.rotation.y != 0)
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.position += new Vector3(-1f, 0, 0);
            turning = true;
        }
        if (turning)
        {
            transform.position = prePos;

        }
        
        
    }

    void PlayerJump()
    {
        if (onGround == true)
        {

            float v;
            v = Input.GetAxisRaw("Jump");
            vertMovement.Set(0f, v, 0f);
            vertMovement = vertMovement.normalized * jumpSpeed * Time.deltaTime;
            playerRig.AddForce(vertMovement, ForceMode.Impulse);
        }


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
            if (isDash && dashTime < dashDuration)
            {
                Vector3 dashDir;
                dashDir = new Vector3(1f, 0f, 0f);
                dashDir = dashDir.normalized;
                if (transform.rotation.y == 0)
                {
                    print("right");
                    playerRig.MovePosition(playerRig.transform.position + dashDir * dash * Time.deltaTime);
                
                }
                else if (transform.rotation.y == 180f)
                {
                    print("left");
                    playerRig.MovePosition(playerRig.transform.position - dashDir * dash * Time.deltaTime);
                }
            }
            else if (dashTime > dashDuration)
            {
                isDash = false;
                dashTime = 0f;
            }
        }
        
    }

    private void OnTriggerEnter(Collider ground)
    {
        if (ground.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider ground)
    {
        if (ground.tag == "Ground")
        {
            onGround = false;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
