using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signpost : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public float close = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDir = player.transform.position - transform.position;
        float playerDist = playerDir.magnitude;
        playerDir.Normalize();
        if (playerDist <= close)
        {
            panel.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            panel.GetComponent<Canvas>().enabled = false;
        }
    }
}
