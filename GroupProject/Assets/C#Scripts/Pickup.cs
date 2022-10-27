using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pickup : MonoBehaviour
{
    public string type = "Sword";
    public int damage = 5;
    public float swingStartup = 0.5f;
    public float swingDuration = 0.5f;
    public int swingSpeed = 15;
    public Vector2 swingSize = new Vector2(1.2f, 0.3f);
    public Sprite swingSprite;
    public Sprite groundSprite;
    public bool isAdditive = false;
    public GameObject player;
    public GameObject panel;

    public TextMeshProUGUI damText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI typeText;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = groundSprite;
    }

    // Update is called once per frame
    void Update()
    {
        damText.text = "Damage: " + damage;
        rangeText.text = "Range: " + Mathf.Round(swingDuration * swingSpeed);
        speedText.text = "Speed: " + swingSpeed;
        if (!isAdditive)
        {
            typeText.text = type;
            weightText.text = "Weight: " + swingStartup;
        }
        else
        {
            typeText.text = "Upgrade";
            weightText.text = "Weight: " + -swingStartup;
        }
        Vector3 playerDir = player.transform.position - transform.position;
        float playerDist = playerDir.magnitude;
        if (playerDist <= 3)
        {
            panel.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            panel.GetComponent<Canvas>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isAdditive)
            {
                Player.damage += damage;
                Player.swingDuration += swingDuration;
                Player.swingSpeed += swingSpeed;
                Player.swingStartup -= swingStartup;
                damage = Player.damage;
                swingStartup = Player.swingStartup;
                swingDuration = Player.swingDuration;
                swingSpeed = Player.swingSpeed;
            }
            else
            {
                int tempDamage = Player.damage;
                float tempSStartup = Player.swingStartup;
                float tempSDuration = Player.swingDuration;
                int tempSSpeed = Player.swingSpeed;
                Vector2 tempSSize = Player.swingSize;
                Sprite tempSSprite = Player.swingSprite;
                Player.swingSprite = swingSprite;
                Player.damage = damage;
                Player.swingDuration = swingDuration;
                Player.swingSpeed = swingSpeed;
                Player.swingStartup = swingStartup;
                Player.swingSize = swingSize;
                swingSprite = tempSSprite;
                damage = tempDamage;
                swingStartup = tempSStartup;
                swingDuration = tempSDuration;
                swingSpeed = tempSSpeed;
                swingSize = tempSSize;
                GetComponent<SpriteRenderer>().sprite = swingSprite;
            }
            if (isAdditive)
            {
                Destroy(gameObject);
            }
        }
    }
}
