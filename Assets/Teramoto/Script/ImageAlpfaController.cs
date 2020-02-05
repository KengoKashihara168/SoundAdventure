using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAlpfaController : MonoBehaviour
{
    public Image ImageUI;
    [SerializeField]
    private float a_color = 0.0f;

    //アルファ値
    [SerializeField, Range(0, 1)]
    private float AlpfaNode = 0.0f;
    bool flag_G;
    [SerializeField]
    Color c;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Imageの透明度を変更する
        this.ImageUI.color = new Color(c.r, c.g, c.b, a_color);
        if (flag_G)
        {
            a_color -= Time.deltaTime;

        }
        else
        {
            a_color += Time.deltaTime;
        }

        if (a_color < AlpfaNode)
        {
            a_color = AlpfaNode;
            flag_G = false;
        }
        else if (a_color > 1)
        {
            a_color = 1;
            flag_G = true;
        }
    }

}