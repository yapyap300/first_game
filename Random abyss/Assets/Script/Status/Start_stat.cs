using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Start_stat : MonoBehaviour
{
    
    public int Stat_point = 3;
    public int Str = 1;
    public int Dex = 1;
    public int Luk = 1;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
}
