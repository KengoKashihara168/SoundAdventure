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
<<<<<<< HEAD
      //  IsClickButton = false;

=======
>>>>>>> 7ac25e5d7cb54caa41700c4abd16c7c2ac05b743

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
