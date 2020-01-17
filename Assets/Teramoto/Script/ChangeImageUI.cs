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

    //ボタンのオブジェの取得
    [SerializeField]
    private GameObject MainObj;

    SettingPlayerJob script;
    // Start is called before the first frame update
    void Start()
    {
        script = MainObj.GetComponent<SettingPlayerJob>();

    }

    // Update is called once per frame
    void Update()
    {
        SetImageUI(script.GetYouth());
    }

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
