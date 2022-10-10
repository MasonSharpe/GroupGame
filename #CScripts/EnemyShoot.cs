using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBullet;
    public float bulletSpeed = 10.0f;
    public float bulletLifeTime = 1.5f;
    public GameObject player;
    public float close = 5.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 shootDir = player.transform.position - transform.position;
        float shootDist = shootDir.magnitude;
        shootDir.Normalize();
        if (shootDist <= close)
        {
            if (timer >= shootDelay)
            {
                //shoot
                timer = 0;
                GameObject bulletSpawn = Instantiate(EnemyBullet,
                    transform.position, Quaternion.identity);
                bulletSpawn.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
                Destroy(bulletSpawn, bulletLifeTime);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if (otherTag == "EBulletDamage")
        {
            Destroy(EnemyBullet);
        }
    }
}
