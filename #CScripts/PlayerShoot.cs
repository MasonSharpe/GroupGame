using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float bulletLifeTime = 2.0f;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bulletSpawn = Instantiate(bullet, transform.position, Quaternion.identity);
                //bulletSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 shootDir = mousePosition - transform.position;
                shootDir.Normalize();
                bulletSpawn.GetComponent<Rigidbody2D>().velocity = shootDir * speed;
                Destroy(bulletSpawn, bulletLifeTime);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
            }
        }
    }
}
