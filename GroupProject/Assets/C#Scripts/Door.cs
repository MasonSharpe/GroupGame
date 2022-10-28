using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int enemiesInRoom = 1;
    public bool isBoss = false;
    public bool isGifter = false;
    //public GameObject activationBox;
    bool activeRoom = false;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    // Start is called before the first frame update
    void Start()
    {
        activeRoom = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.enemiesLeft <= 0 && activeRoom)
        {
            if (isGifter)
            {
                Player.roomCleared = true;
                if (Player.health < Player.maxHealth)
                {
                    Player.health += 1;
                }
                if (!Player.takenDamage)
                {
                    if (isBoss)
                    {
                        Player.maxHealth += 5;
                        Player.health += 5;
                    }
                    else
                    {
                        Player.maxStamina += 20;
                        Player.health += 1;
                        if (Player.health > Player.maxHealth)
                        {
                            Player.health = Player.maxHealth;
                        }
                    }
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
            activeRoom = true;
            if (isGifter)
            {
                Player.enemiesLeft = enemiesInRoom;
                Player.takenDamage = false;
                enemy1.SetActive(true);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                enemy4.SetActive(true);
                enemy5.SetActive(true);
            }
        }
    }
}
