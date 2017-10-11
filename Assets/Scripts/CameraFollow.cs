using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Vector3 camOffset;
    GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        camOffset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate () {

        transform.position = player.transform.position+new Vector3(0,3f,-10f);
	}
}
