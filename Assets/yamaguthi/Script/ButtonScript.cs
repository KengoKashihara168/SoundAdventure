using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] RandomItem randomItem;
    [SerializeField] ColorChange colorChange;
    [SerializeField] MasterScriot master;
    [SerializeField] GameObject audioUI;
    [SerializeField] GameObject MoveUI;
    [SerializeField] GameObject createName;
    [SerializeField] NameCreate create;
    [SerializeField] GameObject notCreate;
    public GameObject jobMain;
    private GameObject[] players; 
    bool gameStart;
    private bool breakFlag;
    bool karifalg;
    bool isNameCreate;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        breakFlag = true;
        players = master.GetPlayer();
        audioUI.SetActive(false);
        karifalg = false;
        MoveUI.SetActive(false);
        isNameCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if(!gameStart)
        {
            jobMain.GetComponent<JobScene>().newJob();
            colorChange.SetMap();
            randomItem.Dicision();

            Debug.Log(gameStart);
            gameStart = true;
         //   breakFlag = true;
           // jobMain.GetComponent<JobScene>().roleImagePlay(breakFlag);
        }
        if (jobMain.GetComponent<JobScene>().GetCloseFlag())
        {
            colorChange.ColorReset();
            audioUI.SetActive(false);
            jobMain.GetComponent<JobScene>().CloseScene();
            master.ResetNowPlayer();
            MoveUI.SetActive(true);
        }
        if (!jobMain.GetComponent<JobScene>().GetCloseFlag() && breakFlag == false)
        {
            Debug.Log("一回だけ");
            jobMain.GetComponent<JobScene>().roleImagePlay(breakFlag);
          
            if(!isNameCreate)
            {
                if(createName.activeSelf)
                {
                    isNameCreate = create.ChName();
                }
                Debug.Log(createName.activeSelf);
                createName.SetActive(true);
               
                Debug.Log(isNameCreate);
            }
            if (isNameCreate)
            {
                notCreate.SetActive(false);
                create.ResetBox();
                createName.SetActive(false);
                audioUI.SetActive(true);
                jobMain.GetComponent<JobScene>().SetinfoPos();
                breakFlag = true;
                karifalg = true;
                jobMain.GetComponent<JobScene>().playerpostion();
                if (master.GetComponent<MasterScriot>().GetNowPlayer() > 2)
                {
                    jobMain.GetComponent<JobScene>().SetCloseFlag(true);
                }
            }

        }
        else if (!jobMain.GetComponent<JobScene>().GetCloseFlag() && breakFlag == true)
        {

            audioUI.SetActive(false);
            if (karifalg == true)
            {
                jobMain.GetComponent<JobScene>().add();
                karifalg = false;
            }
            jobMain.GetComponent<JobScene>().roleImagePlay(breakFlag);
            breakFlag = false;
            isNameCreate = false;
            colorChange.ColorReset();

        }


    }
}
