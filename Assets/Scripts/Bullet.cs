using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//3 type/size of bullet
public enum BulletType
{
    normal,
    mid,
    large
}
public class Bullet : MonoBehaviour {
    public float bulletSpeed;

    GameObject player;
    bool faceLeft;
    public BulletType type;

    EnemyHealth enemyHealth;
	// Use this for initialization
	void Awake () {
        BulletTypePick();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.eulerAngles.y == 0)
        {
            faceLeft = true;
        }
        else if (player.transform.eulerAngles.y == 180)
        {
            faceLeft=false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        BulletMove();
	}
    //bullet move;
    public void BulletMove()
    {
        if (faceLeft)
        {
            transform.position += new Vector3(bulletSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (!faceLeft)
        {
            transform.position -= new Vector3(bulletSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    //bullet speed is based on bullet type
    public void BulletTypePick()
    {
        switch (type)
        {
            case BulletType.mid:
                bulletSpeed = 20f;
                break;
            case BulletType.large:
                bulletSpeed = 25f;
                break;
            default:
                bulletSpeed = 10f;
                break;
        }

    }

    private void OnTriggerEnter(Collider enemy)
    {
        if(enemy.tag=="Enemy")
        {
            he
        }
    }
}
