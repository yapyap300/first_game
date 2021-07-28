using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    Start_stat Get_Stat;
    public int hp;
    public int currentHP;
    public int Str;
    public int Dex;
    public int Luk;
    public bool HitDelay = false;
    public int atk;


    void Awake()
    {
        Get_Stat = FindObjectOfType<Start_stat>();
        Str = Get_Stat.Str;
        Dex = Get_Stat.Dex;
        Luk = Get_Stat.Luk;
        hp = 100 + 20 * Str;
        atk = 10 + 2 * Str;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHP = hp;
    }

    public void Hit(int Enenmy_Atk)
    {
        HitDelay = true;
        currentHP -= Enenmy_Atk;

        if (currentHP <= 0)
            SceneManager.LoadScene("Finish");

        StopAllCoroutines();
        StartCoroutine(HitCoroutine());
    }

    IEnumerator HitCoroutine()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.5f);
        HitDelay = false;
    }
    
}
