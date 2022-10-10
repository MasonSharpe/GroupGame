using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour

{
    public GameObject EnemyBullet;
    void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if (otherTag == "Player")
        {
            GameObject.Destroy(EnemyBullet);
        }
    }

}
