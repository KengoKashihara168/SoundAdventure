using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDebug : MonoBehaviour
{
    [SerializeField] private List<string> deadPlayers;     // 死亡したプレイヤー配列
    [SerializeField] private List<string> goalPlayers;     // 脱出したプレイヤー配列
    [SerializeField] private bool isGetItem;       // アイテム獲得フラグ
    [SerializeField] private bool youthWinFlag;    // 青年の勝利フラグ
    [SerializeField] private bool hauntedWinFlag;  // 憑人の勝利フラグ

    private Result result;

    // Start is called before the first frame update
    void Start()
    {
        result.deadNames = deadPlayers;
        result.goalNames = goalPlayers;
        result.isGetItem = isGetItem;
        result.winer = WinType.None;
        if (youthWinFlag)
        {
            result.winer = WinType.Youth;
        }
        if (hauntedWinFlag)
        {
            result.winer = WinType.Haunted;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Result GetResult()
    {
        return result;
    }
}
