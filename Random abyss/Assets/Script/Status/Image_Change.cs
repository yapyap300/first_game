using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Change : MonoBehaviour
{
    [SerializeField]
    bool[] stat;
    [SerializeField]
    Sprite[] Change_Images;
    Image Defult_image;
    int Image_number;
    Start_stat current_stat;
    private void Start()
    {
        current_stat = FindObjectOfType<Start_stat>();
        Defult_image = GetComponent<Image>();
    }

    private void Update()
    {
        Changing_Image();
    }

    void Changing_Image()
    {
        if (stat[0])
        {
            Image_number = current_stat.Str;
            Defult_image.sprite = Change_Images[Image_number-1];
        }
        else if (stat[1])
        {
            Image_number = current_stat.Dex;
            Defult_image.sprite = Change_Images[Image_number - 1];
        }
        else
        {
            Image_number = current_stat.Luk;
            Defult_image.sprite = Change_Images[Image_number - 1];
        }
    }
}
