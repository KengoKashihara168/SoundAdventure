using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] RandomItem randomItem;
    public GameObject jobMain;
    bool gameStart;
    private bool breakFlag;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        breakFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if(!gameStart)
        {

            randomItem.Dicision();
            Debug.Log("一回だけ");
            Debug.Log(gameStart);
            gameStart = true;
            Debug.Log(gameStart);
        }

        if (!jobMain.GetComponent<JobScene>().GetCloseFlag() && breakFlag == false)
        {
            jobMain.GetComponent<JobScene>().roleImagePlay(breakFlag);
            jobMain.GetComponent<JobScene>().SetinfoPos();
            breakFlag = true;
        }
        else if (!jobMain.GetComponent<JobScene>().GetCloseFlag() && breakFlag == true)
        {
          
            jobMain.GetComponent<JobScene>().roleImagePlay(breakFlag);
            breakFlag = false;
        }
        else
        {
            jobMain.GetComponent<JobScene>().CloseScene();
        }   
    }
}
