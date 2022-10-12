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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
}
