using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;
    public float close = 2.0f;
    float timerStartup = 1;
    public GameObject weapon;
    float timerReload = -1;
    public float swingStartup = 0.5f;
    public int swingSpeed = 30;
    public float swingDuration = 0.2f;
    public int health = 10;
    float timerInvincibility = -1;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerInvincibility -= Time.deltaTime;
        Vector3 playerDir = player.transform.position - transform.position;
        float playerDist = playerDir.magnitude;
        playerDir.Normalize();
        if (playerDist <= close && timerStartup <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerDir = Vector3.zero;
            timerStartup = 1;
            GameObject weaponSpawn = Instantiate(weapon, transform.position, Quaternion.identity);
            timerReload = swingDuration;
            Vector2 diff = player.transform.position - weaponSpawn.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weaponSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weaponSpawn.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * swingSpeed);
            Destroy(weaponSpawn, timerReload);

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = playerDir * speed;
        }
        timerReload -= Time.deltaTime;
        timerStartup -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timerInvincibility <= 0 && collision.gameObject.tag == "Damage")
        {
            health -= Player.damage;
            timerInvincibility = 0.5f;
           // Destroy(collision.gameObject);
        }
    }
}
