using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI stamText;
    public GameObject healthBar;
    public GameObject stamBar;
    public float speed = 10f;
    public GameObject weapon;
    Vector2 dashCurSpeed;
    public static int enemiesLeft;

    float timerReload = -1; //TIMERS
    float timerStartup = float.PositiveInfinity;
    float timerDash = -1;
    float timerPreDash = -1;
    float timerInvincibility = -1;
    
    
    public static int damage = 5;
    public static Vector2 swingSize = new Vector2(1.2f, 0.3f);
    public static Sprite swingSprite;
    public static float swingStartup = 0.5f; //CHANGABLE STATS
    public static int swingSpeed = 30;
    public static float swingDuration = 0.2f;
    
    bool inDash = false;
    public Sprite defaultSprite;
    Vector3 mouseTarget;
    public static float health = 10;
    public static float maxHealth = 10;
    public GameObject gameOverScreen;
    public static float stamina = 100;
    public static float maxStamina = 100;
    public static bool takenDamage = false;

    public RuntimeAnimatorController playerWalk;
    public RuntimeAnimatorController playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        stamina = 100;
    }

    // Update is called once per frame
    void Update()
    {
        stamText.text = Mathf.Round(stamina).ToString();
        healthText.text = health.ToString();
        //healthBar.GetComponent<RectTransform>().rect.Set(0, 0, 189f * (h / a), 11.51f);
        healthBar.GetComponent<RectTransform>().localScale = new Vector2(health / maxHealth, 1);
        stamBar.GetComponent<RectTransform>().localScale = new Vector2(stamina / maxStamina, 1);
        timerReload -= Time.deltaTime; // TIMERS
        timerStartup -= Time.deltaTime;
        timerPreDash -= Time.deltaTime;
        timerInvincibility -= Time.deltaTime;
        timerDash -= Time.deltaTime;
        float xInput = Input.GetAxis("Horizontal"); // GETTING MOVEMENT INFO
        float yInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(xInput, yInput);
        if (timerInvincibility > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && Time.timeScale != 0 && timerStartup > 100 && timerPreDash < 0 && stamina >= 10 && !inDash) //DASH INITILIZATION
        {
            dashCurSpeed = moveDirection * speed * 3;
            inDash = true;
            timerDash = 0.1f;
            stamina -= timerDash * 100;
            timerInvincibility = timerDash;
            GetComponent<Rigidbody2D>().velocity = dashCurSpeed;
            if (Mathf.Abs(dashCurSpeed.x) + Mathf.Abs(dashCurSpeed.y) == 2)
            {
                GetComponent<Rigidbody2D>().velocity /= 2;
            }
        }
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0 && !inDash && timerStartup > 100 && stamina >= swingStartup * 50) // ATTACK INITILIZATION
        {
            timerStartup = swingStartup;
            GetComponent<Animator>().runtimeAnimatorController = playerAttack;
            mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().velocity = moveDirection;
            stamina -= swingStartup * 50;
        }
        if (timerStartup > 100 && !inDash) // BASIC MOVEMENT
        {
            if (timerDash < -2)
            {
                stamina += Time.deltaTime * 20;
            }
            GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
        }
        GetComponent<Animator>().SetFloat("xInput", moveDirection.x);
        GetComponent<Animator>().SetFloat("yInput", moveDirection.y);
        if (inDash) // DASH COUNTDOWN/ENDING
        {
            if (timerDash <= 0)
            {
                dashCurSpeed *= 0.9f;
                if (Mathf.Abs(dashCurSpeed.x) + Mathf.Abs(dashCurSpeed.y) < 1)
                {
                    dashCurSpeed = Vector2.zero;
                    inDash = false;
                    timerPreDash = 0.5f;
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
            GetComponent<Animator>().runtimeAnimatorController = playerWalk;
            Destroy(weaponSpawn, timerReload);
        }
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision) //COLLIDE WITH ENEMY
    //{
        //if (timerInvincibility <= 0 && collision.gameObject.tag == "Enemy")
        //{
            //health--;
            //timerInvincibility = 1;   mechanic kinda sucks with the dash, might add in later
            //checkHealth();
       // }
   // }

    private void OnTriggerEnter2D(Collider2D collision) //COLLIDE WITH BULLET
    {
        if (timerInvincibility <= 0 && collision.gameObject.tag == "Damage")
        {
            health -= collision.GetComponent<Projectiles>().damage;
            takenDamage = true;
            timerInvincibility = 0.5f;
            Destroy(collision.gameObject);
            checkHealth();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timerInvincibility <= 0 && collision.gameObject.tag == "SpikeDamage")
        {
            health -= 3;
            takenDamage = true;
            timerInvincibility = 0.5f;
            checkHealth();
        }
    }
    private void checkHealth() //ON DAMAGE TAKEN
    {
        if (health <= 0)
        {
            gameOverScreen.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
}
