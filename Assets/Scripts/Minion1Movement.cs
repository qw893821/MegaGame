using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion1Movement : MonoBehaviour {
    //minion 1 move spped;
    float m1speed;

    //minion type 1's position
    Rigidbody m1;

    Vector3 direction;
	// Use this for initialization
	void Start () {
        m1speed = 5f;
        m1 = GetComponent<Rigidbody>();
        direction = new Vector3(-1f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 m1Move;
        m1Move = direction * m1speed * Time.deltaTime;
        m1.MovePosition(transform.position + m1Move);
	}


}
