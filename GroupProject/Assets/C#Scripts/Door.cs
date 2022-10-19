using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int enemiesInRoom = 1;
    public bool isBoss = false;
    //public GameObject activationBox;
    bool activeRoom = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.enemiesLeft <= 0 && activeRoom)
        {
            if (!Player.takenDamage)
            {
                if (isBoss)
                {
                    Player.maxHealth += 25;
                    Player.health = Player.maxHealth;
                }
                else
                {
                    Player.maxStamina += 1;
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            Player.enemiesLeft = enemiesInRoom;
            Player.takenDamage = false;
            activeRoom = true;
        }
    }
}
