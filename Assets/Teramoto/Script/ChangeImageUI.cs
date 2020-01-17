using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageUI : MonoBehaviour
{
    //青年のImageセット
    [SerializeField]
    private Sprite YouthSprite;
    //憑人のImageセット
    [SerializeField]
    private Sprite ScooldSprite;

    //Panel
    [SerializeField]
    private Image panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Iamgeを青年か憑人かをboolで変更
        SetImageUI(true);
    }

    //Iamgeを青年か憑人かをboolで変更するscript
    public void SetImageUI(bool job)
    {
        //trueの場合青年表示
        if (job)
        {
            //青年の画像
            print("青年");
            panel.sprite = YouthSprite;

        }

        //falseの場合青年表示
        if (!job)
        {
            //憑人の画像    
            print("憑人");
            panel.sprite = ScooldSprite;
        }
    }
}
