using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject BossVPrefab;
    public GameObject BossAPrefab;
    public GameObject BossLPrefab;

    GameObject[] BossV;
    GameObject[] BossA;
    GameObject[] BossL;
    GameObject[] targetPool;

    void Awake()
    {
        BossV = new GameObject[100];
        BossA = new GameObject[12];
        BossL = new GameObject[5];

        Generate();
    }

    void Generate()
    {
        for(int i=0; i < BossV.Length; i++)
        {
            BossV[i] = Instantiate(BossVPrefab);
            BossV[i].SetActive(false);
        }
        for (int i = 0; i < BossA.Length; i++)
        {
            BossA[i] = Instantiate(BossAPrefab);
            BossA[i].SetActive(false);
        }
        for (int i = 0; i < BossL.Length; i++)
        {
            BossL[i] = Instantiate(BossLPrefab);
            BossL[i].SetActive(false);
        }
    }
    public GameObject MakeObj(string type)
    {
        
        switch (type)
        {
            case "void":
                targetPool = BossV;
                break;
            case "arms":
                targetPool = BossA;
                break;
            case "beam":
                targetPool = BossL;
                break;
        }
        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                {
                    targetPool[i].SetActive(true);
                    return targetPool[i];
                }
            }
        }

        return null;
    }
}
