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
    float timerTell = 1;
    float swingTell = 0.4f;
    float timerAccuracy = 1;
    public float swingStartup = 0.5f;
    public int swingSpeed = 30;
    public float swingDuration = 0.2f;
    public float swingAccuracy = 0.3f;
    public int health = 10;
    float timerInvincibility = -1;
    public int damage;
    public GameObject dCollidor;
    Vector3 ppos = Vector3.zero;
    bool unnoticed = true;
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
        if (unnoticed && playerDist <= close * 2)
        {
            unnoticed = false;
        }
        if (timerStartup <= 0 && playerDist <= close)
        {
            timerTell -= Time.deltaTime;
            timerAccuracy -= Time.deltaTime;
            if (timerAccuracy <= 0 && ppos == Vector3.zero)
            {
                ppos = player.transform.position;
            }
        }
        if (timerTell <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerDir = Vector3.zero;
            timerStartup = 1;
            GameObject weaponSpawn = Instantiate(weapon, transform.position, Quaternion.identity);
            timerReload = swingDuration;
            timerTell = swingTell;
            timerAccuracy = swingAccuracy;
            Vector2 diff = ppos - weaponSpawn.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weaponSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weaponSpawn.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * swingSpeed);
            ppos = Vector3.zero;
            Destroy(weaponSpawn, timerReload);
        }
        else if ((timerStartup >= 0 || playerDist >= close) && !unnoticed)
        {
            GetComponent<Rigidbody2D>().velocity = playerDir * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Player.enemiesLeft--;
                Destroy(gameObject);
            }
        }
    }
}
