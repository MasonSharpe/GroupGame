using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject weapon;
    float timerReload = -1;
    float timerStartup = -1;
    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            timerStartup = 0.5f;
        }
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(xInput, yInput);
        GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
        timerReload -= Time.deltaTime;
        timerStartup -= Time.deltaTime;
        if (timerReload <= 0 && weapon.GetComponent<SpriteRenderer>().enabled == true)
        {
            weapon.GetComponent<SpriteRenderer>().enabled = false;
            weapon.transform.localPosition = Vector3.zero;
        }
        if (timerStartup <= 0)
        {
            timerStartup = float.PositiveInfinity;
            weapon.GetComponent<SpriteRenderer>().enabled = true;
            weapon.transform.localPosition = Vector3.zero;
            timerReload = 0.2f;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 diff = mousePosition - weapon.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weapon.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * 10) + (moveDirection * speed);
        }
    }
}
