using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public string type = "Player";
    // Start is called before the first frame update
    void Start()
    {
        if (type == "Player")
        {
            transform.localScale = Player.swingSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            print(collision.gameObject.layer);
            Destroy(gameObject);
        }
    }
}
