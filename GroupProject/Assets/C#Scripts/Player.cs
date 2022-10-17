using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthText;
	public float speed = 10f;
    public GameObject weapon;
    float timerReload = -1;
    float timerStartup = float.PositiveInfinity;
    float timerDash = -1;
    float timerPreDash = -1;
    float timerInvincibility = -1;
    Vector2 dashCurSpeed;
    public static int damage = 50;
    public static float swingStartup = 0.5f;
    public static int swingSpeed = 30;
    public static float swingDuration = 0.2f;
    bool inDash = false;
    Vector3 mouseTarget;
    public int health = 10;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		healthText.text = "Health: " + health;
		timerReload -= Time.deltaTime; // TIMERS
        timerStartup -= Time.deltaTime;
        timerPreDash -= Time.deltaTime;
        timerInvincibility -= Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal"); // GETTING MOVEMENT INFO
        float yInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(xInput, yInput);
        if (Input.GetButtonDown("Jump") && Time.timeScale != 0 && timerStartup > 100 && timerPreDash < 0) //DASH INITILIZATION
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
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0 && !inDash && timerStartup > 100) // ATTACK INITILIZATION
        {
            timerStartup = swingStartup;
            mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().velocity = moveDirection;
        }
        if (timerStartup > 100 && !inDash) // BASIC MOVEMENT
        {
            GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
            GetComponent<Animator>().SetFloat("xInput", moveDirection.x);
            GetComponent<Animator>().SetFloat("yInput", moveDirection.y);
        }
        if (inDash) // DASH COUNTDOWN/ENDING
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
        if (timerStartup <= 0) // ATTACK SENDOUT
        {
            timerStartup = float.PositiveInfinity;
            GameObject weaponSpawn = Instantiate(weapon, transform.position, Quaternion.identity);
            timerReload = swingDuration;
            Vector3 mousePosition = mouseTarget;
            Vector2 diff = mousePosition - weaponSpawn.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            weaponSpawn.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            weaponSpawn.GetComponent<Rigidbody2D>().velocity = (new Vector2(diff.x, diff.y) * swingSpeed);
            Destroy(weaponSpawn, timerReload);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timerInvincibility <= 0 && collision.gameObject.tag == "Enemy")
        {
            health--;
            timerInvincibility = 1;
            checkHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timerInvincibility <= 0 && collision.gameObject.tag == "Damage")
        {
            health--;
            timerInvincibility = 0.5f;
            Destroy(collision.gameObject);
            checkHealth();
        }
    }
    private void checkHealth()
    {
        if (health <= 0)
        {
            gameOverScreen.GetComponent<Canvas>().enabled = true;
        }
    }
}
