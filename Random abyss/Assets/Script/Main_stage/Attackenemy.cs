using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackenemy : MonoBehaviour
{
    float Cri;
    PlayerStatus thePlayerStat;
    BossStatus Boss;

    void Awake()
    {
        thePlayerStat = FindObjectOfType<PlayerStatus>();
        Boss = FindObjectOfType<BossStatus>();
        Cri = thePlayerStat.Luk * 5;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            if (Random.Range(1, 101) <= Cri)
            {
                Boss.Hit(thePlayerStat.atk * 2);
                
            }
            else
            {
                Boss.Hit(thePlayerStat.atk);
                
            }
        }
        
    }
}
