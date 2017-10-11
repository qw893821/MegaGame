using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2SpawnManagement : MonoBehaviour {

    public GameObject m2;
    Transform m2SpawnPos;
    Collider col;
    // Use this for initialization
    void Awake()
    {
        col = GetComponent<Collider>();
        m2SpawnPos = transform.Find("SpawnPos").gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(m2,m2SpawnPos);
            col.enabled = false;
        }
    }
}
