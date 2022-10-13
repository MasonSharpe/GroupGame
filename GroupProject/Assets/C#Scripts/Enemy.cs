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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDir = player.transform.position - transform.position;
        float playerDist = playerDir.magnitude;
        playerDir.Normalize();
        if (playerDist <= close && timerStartup <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerDir = Vector3.zero;
            timerStartup = 1;
            weapon.GetComponent<SpriteRenderer>().enabled = true;
            weapon.transform.localPosition = Vector3.zero;
            timerReload = swingDuration;
            Vector2 diff = player.transform.position - weapon.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weapon.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * swingSpeed);

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = playerDir * speed;
        }
        timerReload -= Time.deltaTime;
        timerStartup -= Time.deltaTime;
        if (timerReload <= 0 && weapon.GetComponent<SpriteRenderer>().enabled == true)
        {
            weapon.GetComponent<SpriteRenderer>().enabled = false;
            weapon.transform.localPosition = Vector3.zero;
        }
    }
}
