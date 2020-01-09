using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerResultManager : MonoBehaviour
{
    [SerializeField]
    private WholeResult wholeResult;
    [SerializeField]
    private Text youthVictory;
    [SerializeField]
    private Text winner;
    [SerializeField]
    private Text hauntedText;
    string winnerSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize()
    {
        //初期化
        winnerSide = "無し";
        youthVictory.enabled = false;
        hauntedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //勝者の表示
    public void WhoWinner()
    {
        //青年勝利
        if (wholeResult.IsYouthWin() == true)
        {
            winnerSide = "青年";
            youthVictory.enabled = true;
        }

        //憑人勝利
        else if (wholeResult.IsHauntedWin() == true)
        {
            winnerSide = "憑人";
            hauntedText.enabled = true;
        }
        winner.text = "したので" + winnerSide + "の勝利です";
    }

    //青年の勝利条件
    public void YouthVictoryConditions()
    {
        //八尺様封印
        if (Input.GetKeyDown(KeyCode.A))
        {
            youthVictory.text = "八尺様を封印";
        }
        //村脱出
        else if (Input.GetKeyDown(KeyCode.D))
        {
            youthVictory.text = "村から脱出";
        }
    }
}
