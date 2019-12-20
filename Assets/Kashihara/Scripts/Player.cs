using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの番号
//public enum PlayerNum
//{
//    Player1 = 0,
//    Player2,
//    Player3,
//    Player4,
//    MaxPlayer,
//}

public enum PlayerType
{
    Youth,   // 青年
    Haunted, // 憑人
    None,    // 何もなし
}



public class Player : MonoBehaviour
{
    public PlayerNum  playerNum { get; set; } // プレイヤー番号
    public PlayerType playerType{ get; set; } // プレイヤーの種類
 

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize()
    {
        playerNum = PlayerNum.MaxPlayer;
        playerType = PlayerType.None;
    }
}
