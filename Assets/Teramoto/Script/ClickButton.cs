
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickButton : MonoBehaviour
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
        if (IsClickButton==true)
        {
            SceneManager.LoadScene("Sound");
        }
    }

    public void OnClickButton()
    {
        IsClickButton = true;
    }

    public bool GetClickButton()
    {
        return IsClickButton;
    }
}
