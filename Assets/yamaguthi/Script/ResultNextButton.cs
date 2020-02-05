using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultNextButton : MonoBehaviour
{
    [SerializeField] MasterScriot master;
    [SerializeField] GameScene gameScene;
    [SerializeField] private PrivateResult privateResultScreen;
    [SerializeField] private Activ activ;
    [SerializeField] GameObject audioUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextResult()
    {
        master.AddNowPlayer();
        if (master.GetNowPlayer()<4)
        {
            if (!master.GetPlayer()[master.GetNowPlayer()].GetComponent<Player>().IsDropOut())
                gameScene.OnScreenButton(ScreenType.Move);
            else
                nextResult();
        }
        else
        {
            master.ResetNowPlayer();
            foreach (Transform child in privateResultScreen.gameObject.transform)
            {
                child.gameObject.SetActive(false);
                if (child.name == "NextButton")
                {
                    foreach (Transform text in child)
                    {
                        text.gameObject.SetActive(false);
                    }
                }
            }
            audioUI.SetActive(true);
            gameScene.GetDeadPlayers().Clear();
            activ.OnNextMoveUI();
        }
    }
}
