using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSettingPlayerButton : MonoBehaviour
{
    
    //ボタンが押されたかのFlag
    bool IsClickButton;
    // Start is called before the first frame update
    void Start()
    {
        IsClickButton = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickButton()
    {
        IsClickButton = true;
       //S Debug.Log("aaaa");
    }

    public bool GetClickButton()
    {
        return IsClickButton;
    }
}
