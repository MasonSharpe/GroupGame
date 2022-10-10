using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDestroy : MonoBehaviour
{
    public GameObject bullet;
    void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if (otherTag == "Slime")
        {
            GameObject.Destroy(bullet);
        }
    }
}
