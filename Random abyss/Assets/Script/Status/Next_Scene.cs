using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Main_Scene()
    {
        SceneManager.LoadScene("Main_stage");
    }
}
