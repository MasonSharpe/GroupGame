using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject weapon;
    float timerReload = -1;
    float timerStartup = float.PositiveInfinity;
    float timerDash = -1;
    float timerPreDash = -1;
    Vector2 dashCurSpeed;
    public static int damage = 50;
    public static float swingStartup = 0.5f;
    public static int swingSpeed = 30;
    public static float swingDuration = 0.2f;
    Vector3 positionLastFrame;
    bool inDash = false;
    Vector3 mouseTarget;
    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(xInput, yInput);
        positionLastFrame = transform.position;
        if (Input.GetButtonDown("Jump") && Time.timeScale != 0 && timerStartup > 100 && timerPreDash < 0)
        {
            dashCurSpeed = moveDirection * speed * 3;
            inDash = true;
            timerDash = 0.1f;
            GetComponent<Rigidbody2D>().velocity = dashCurSpeed;
            if (Mathf.Abs(dashCurSpeed.x) + Mathf.Abs(dashCurSpeed.y) == 2)
            {
                GetComponent<Rigidbody2D>().velocity /= 2;
            }
        }
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0 && !inDash)
        {
            timerStartup = swingStartup;
            mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().velocity = moveDirection;
        }
        if (timerStartup > 100 && !inDash)
        {
            GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
        }
        if (inDash)
        {
            timerDash -= Time.deltaTime;
            if (timerDash <= 0)
            {
                dashCurSpeed *= 0.9f;
                if (Mathf.Abs(dashCurSpeed.x) + Mathf.Abs(dashCurSpeed.y) < 1)
                {
                    dashCurSpeed = Vector2.zero;
                    inDash = false;
                    timerPreDash = 1;
                }
            }
        }
        timerReload -= Time.deltaTime;
        timerStartup -= Time.deltaTime;
        timerPreDash -= Time.deltaTime;
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
            timerReload = swingDuration;
            Vector3 mousePosition = mouseTarget;
            Vector2 diff = mousePosition - weapon.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weapon.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * swingSpeed);
        }
    }
}
