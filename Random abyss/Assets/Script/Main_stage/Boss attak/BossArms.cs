using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArms : MonoBehaviour
{
    PlayerStatus stat;
    int Max_Hit;
    bool timer;

    void Awake()
    {
        stat = FindObjectOfType<PlayerStatus>();
    }
    void OnEnable()
    {
        Max_Hit = 3;
        timer = false;
        StartCoroutine(TimeOut());
    }

    void Update()
    {
        if (Max_Hit == 0)
            gameObject.SetActive(false);
        else if (timer)
        {
            stat.Hit(10);
            gameObject.SetActive(false);
        }
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(25f);
        timer = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attack")
        {
            Max_Hit--;
        }
    }
}
