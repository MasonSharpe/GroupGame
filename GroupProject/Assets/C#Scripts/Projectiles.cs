using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public string type = "Player";
    float lifespan = 0f;
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
        lifespan += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && lifespan > 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
