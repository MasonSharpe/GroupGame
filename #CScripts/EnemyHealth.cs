using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public GameObject Slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if(otherTag == "BulletDamage")
        {
            health -= 3;
            if (health <= 0)
            {
                Debug.Log("Enemy Killed");
                GameObject.Destroy(Slime);
            }
        }
    }
}
