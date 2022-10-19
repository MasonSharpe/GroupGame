using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Player.damage = damage;
                Player.swingDuration = swingDuration;
                Player.swingSpeed = swingSpeed;
                Player.swingStartup = swingStartup;
                damage = tempDamage;
                swingStartup = tempSStartup;
                swingDuration = tempSDuration;
                swingSpeed = tempSSpeed;
            }
            if (isAdditive)
            {
                Destroy(gameObject);
            }
        }
    }
}
