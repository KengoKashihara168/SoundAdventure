using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageController : MonoBehaviour
{
    public Image ImageUI;
    float a_color;
    bool flag_G;
    // Use this for initialization
    void Start()
    {
        a_color = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        //テキストの透明度を変更する
        ImageUI.color = new Color(1, 1, 1, a_color);
        if (flag_G)
            a_color -= Time.deltaTime;
        else
            a_color += Time.deltaTime;
        if (a_color < 0.5f)
        {
            a_color = 0.5f;
            flag_G = false;
        }
        else if (a_color > 1)
        {
            a_color = 1;
            flag_G = true;
        }
    }
}