using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Vector3 camOffset;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        camOffset = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + camOffset;
	}
}
