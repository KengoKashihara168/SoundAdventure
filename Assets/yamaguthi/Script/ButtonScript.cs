using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] RandomItem randomItem;
    public GameObject jobMain;
    bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
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

        if (!jobMain.GetComponent<JobScene>().GetCloseFlag())
        {
            jobMain.GetComponent<JobScene>().SetinfoPos();
        }
        else
        {
            jobMain.GetComponent<JobScene>().CloseScene();
        }   
    }
}
