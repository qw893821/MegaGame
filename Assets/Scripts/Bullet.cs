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
    

    GameObject player;
    //GameObject enemy;
    bool faceLeft;
    //different bullet have different flying speed and power, charge could change bullet type.
    //Three stage charge
    public BulletType type;
    public float bulletSpeed;
    public float bulletPower;

    //camera
    GameObject cam;
    float offValue;

    EnemyHealth enemyHealth;
	// Use this for initialization
	void Awake () {
        BulletTypePick();
        player = GameObject.FindGameObjectWithTag("Player");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (player.transform.eulerAngles.y == 0)
        {
            faceLeft = true;
        }
        else if (player.transform.eulerAngles.y == 180)
        {
            faceLeft=false;
        }
        cam = GameObject.Find("Main Camera");
        offValue = 30f;
    }
	
	// Update is called once per frame
	void Update () {
        BulletMove();
        delBullet();

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
                bulletPower = 50f;
                break;
            case BulletType.large:
                bulletSpeed = 25f;
                bulletPower = 80f;
                break;
            default:
                bulletSpeed = 10f;
                bulletPower = 20f;
                break;
        }

    }

    //if bullet fly fay from cam/player view, destory bullet to save perfomance
    void delBullet()
    {
        float bulOffVlaue;
        bulOffVlaue = cam.transform.position.x - transform.position.x;
        if (Mathf.Abs(bulOffVlaue) >= offValue)
        {
            Destroy(this.gameObject);
        }
    }
}
