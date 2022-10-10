using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStatements : MonoBehaviour
{
    int level = 3;
    [SerializeField]
    public int xp = 10;
    public int levelUpXP = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (xp >= levelUpXP)
    {
        level++;
        xp = xp - levelUpXP;
        levelUpXP += 10;
            Debug.Log("You've Leveled up! " + level);

    }
          
    }
}
