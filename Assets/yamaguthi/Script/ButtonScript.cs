using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject jobMain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if(!jobMain.GetComponent<JobScene>().GetCloseFlag())
        {
            jobMain.GetComponent<JobScene>().SetinfoPos();
        }
        else
        {
            jobMain.GetComponent<JobScene>().CloseScene();
        }   
    }
}
