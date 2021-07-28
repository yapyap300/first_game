using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice_Button : MonoBehaviour
{
    [SerializeField]
    Text point;
    Start_stat current_stat;

    private void Start()
    {
        current_stat = FindObjectOfType<Start_stat>();
    }
    private void Update()
    {
        point.text = current_stat.Stat_point.ToString();
    }
    public void Random_Dice()
    {
        if (current_stat.Stat_point == 0)
            return;
        current_stat.Stat_point--;
        current_stat.Str = Random.Range(1, 11);
        current_stat.Dex = Random.Range(1, 11);
        current_stat.Luk = Random.Range(1, 11);

    }

    
}
