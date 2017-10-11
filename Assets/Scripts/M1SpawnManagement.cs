using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1SpawnManagement : MonoBehaviour {
    public GameObject m1;
    Transform m1SpawnPos;
    Collider col;
	// Use this for initialization
	void Awake () {
        col = GetComponent<Collider>();
        m1SpawnPos = transform.Find("SpawnPos").gameObject.transform;
        col.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(m1, m1SpawnPos);
            col.enabled = false;
        }
    }
}
