using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activ : MonoBehaviour
{
    [SerializeField] GameObject direction;
    [SerializeField] GameObject moveDecision;
    [SerializeField] GameObject swordDecision;
    [SerializeField] GameObject yesButton;
    [SerializeField] GameObject noButton;
    [SerializeField] GameObject mapButton;
    [SerializeField] GameObject moveButton;
    [SerializeField] Image Image;

    // Start is called before the first frame update
    void Start()
    {
        //方角ボタンだけ表示
        direction.SetActive(true);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        Image.enabled = false;
    }
    
    public void MovePlay()
    {
        direction.SetActive(true);
        moveDecision.SetActive(true);
    }
    public void MoveHide()
    {
        direction.SetActive(false);
        moveDecision.SetActive(false);
    }
    public void SwordPlay()
    {
        direction.SetActive(true);
        swordDecision.SetActive(true);
    }
    public void SwordHide()
    {
        direction.SetActive(false);
        swordDecision.SetActive(false);
    }
    
    //移動の決定ボタンを押したら
    public void MoveDecisionPush()
    {
        //移動系UIを非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        //刀系UIを表示
        yesButton.SetActive(true);
        noButton.SetActive(true);
        Image.enabled = true;
    }

    //刀の決定ボタンを押したら
    public void SwordDecisionPush()
    {
        //全て非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        mapButton.SetActive(false);
        moveButton.SetActive(false);
        Image.enabled = false;
    }

    //はいのボタン
    public void YesPush()
    {
        //方角を表示
        direction.SetActive(true);
    }
    //いいえのボタン
    public void NoPush()
    {
        //全て非表示
        direction.SetActive(false);
        moveDecision.SetActive(false);
        swordDecision.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        mapButton.SetActive(false);
        moveButton.SetActive(false);
        Image.enabled = false;
    }
    //方角のボタンを押したら
    public void DirectiomPush()
    {
        //刀の画像が表示されたら(2つの決定ボタンを分けるため)
        if (Image.enabled == false)
        {
            //移動の決定ボタンを表示
            moveDecision.SetActive(true);
        }
        else
        {
            //刀の決定ボタンを表示
            swordDecision.SetActive(true);
        }
    }
}