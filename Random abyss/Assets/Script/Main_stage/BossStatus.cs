using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public int hp;
    public int currentHp;
    public int atk;
    public int def;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
    }

    public void Hit(int PlayerAtk)
    {
        int dmg;

        if (def >= PlayerAtk)
            dmg = 1;
        else
            dmg = PlayerAtk - def;

        currentHp -= dmg;

        if (currentHp <= 0)
            Destroy(this.gameObject);

    }
}
