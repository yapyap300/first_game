using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform[] armsPoints;
    public GameObject Player;
    public ObjectManager manager;
    public Slider HpSlider;
    BossStatus mystat;
    int patternIndex;
    bool attacking = true;
    void Awake()
    {
        mystat = GetComponent<BossStatus>();
        HpSlider.maxValue = mystat.hp;
        StartCoroutine(patternDelay());
    }
    

    // Update is called once per frame
    void Update()
    {
        HpSlider.value = mystat.currentHp;
        if (!attacking)
            Think();
    }
    void Think()
    {
        

        attacking = true;
        patternIndex = Random.Range(0, 3);
        switch (patternIndex)
        {
            case 0:
                StartCoroutine(Firevoid());
                break;
            case 1:
                StartCoroutine(LaserPattern());
                break;
            case 2:
                SummonArms();
                break;
        }
        StartCoroutine(patternDelay());
    }
    IEnumerator Firevoid()
    {
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject BossVoid = manager.MakeObj("void");
            BossVoid.transform.position = new Vector2(Random.Range(-17, 17), Random.Range(-9, 9));

            Rigidbody2D rigid = BossVoid.GetComponent<Rigidbody2D>();
            Vector2 dirVec = Player.transform.position - BossVoid.transform.position;
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }

    }
    void SummonArms()
    {
        GameObject BossArms1 = manager.MakeObj("arms");
        BossArms1.transform.rotation = armsPoints[0].rotation;
        BossArms1.transform.position = armsPoints[0].position;
        GameObject BossArms2 = manager.MakeObj("arms");
        BossArms2.transform.rotation = armsPoints[1].rotation;
        BossArms2.transform.position = armsPoints[1].position;
        GameObject BossArms3 = manager.MakeObj("arms");
        BossArms3.transform.position = armsPoints[2].position;
        GameObject BossArms4 = manager.MakeObj("arms");
        BossArms4.transform.position = armsPoints[3].position;
    }
        IEnumerator patternDelay()
    {
        yield return new WaitForSeconds(15f);
        attacking = false;
    }
    IEnumerator LaserPattern()
    {
        GameObject Bossbeam = manager.MakeObj("beam");
        Vector3 target = Bossbeam.transform.position - Player.transform.position;
        float angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
        Bossbeam.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        yield return new WaitForSeconds(4f);
        Bossbeam.SetActive(false);
        yield return new WaitForSeconds(1f);
        Bossbeam = manager.MakeObj("beam");
        target = Bossbeam.transform.position - Player.transform.position;
        angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
        Bossbeam.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        yield return new WaitForSeconds(4f);
        Bossbeam.SetActive(false);
        Bossbeam = manager.MakeObj("beam");
        target = Bossbeam.transform.position - Player.transform.position;
        angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
        Bossbeam.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        yield return new WaitForSeconds(4f);
        Bossbeam.SetActive(false);
    }

    

    
}
