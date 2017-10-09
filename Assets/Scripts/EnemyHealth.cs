using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    enemy1,
    enemy2,
    enemy3,
    enemy4,
    boss
}

public class EnemyHealth : MonoBehaviour {
    public float currenthealth;
    public float maxHealth;

    public EnemyType enemyType;

    //instance of the bullet


	// Use this for initialization
	void Awake () {
        HealthValuePick();
        currenthealth = maxHealth;


	}
	
	// Update is called once per frame
	void Update () {
        

    }
    private void LateUpdate()
    {
        EnemyDie();
    }

    public void HealthValuePick()
    {
        switch (enemyType)
        {
            case EnemyType.enemy1:
                maxHealth = 50f;
                break;
            case EnemyType.enemy2:
                maxHealth = 80f;
                break;
            case EnemyType.enemy3:
                maxHealth = 100f;
                break;
            case EnemyType.enemy4:
                maxHealth = 150f;
                break;
            case EnemyType.boss:
                maxHealth = 1000f;
                break;
            default:
                maxHealth = 20f;
                break;

        }
    }

    public void EnemyDie()
    {
        if (currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet;//get the bullet script of the bullet;
        if (other.tag == "Bullets")
        {
            bullet=other.GetComponentInParent<Bullet>();
            currenthealth -= bullet.bulletPower;
        }
    }
}
