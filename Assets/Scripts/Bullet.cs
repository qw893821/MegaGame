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

    public BulletType type;
	// Use this for initialization
	void Awake () {
        BulletTypePick();
    }
	
	// Update is called once per frame
	void Update () {
        BulletMove();
	}
    //bullet move;
    void BulletMove()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
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

}
