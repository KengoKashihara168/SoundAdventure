using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNum
{
    Player1 = 0,
    Player2,
    Player3,
    Player4,
    MaxPlayer,
}

public class PlayerDT : MonoBehaviour
{
    private int num; // X座標
    public PlayerNum playerNum; // プレイヤー番号

    public void SetPosition(int num)
    {
        this.num = num;
      
    }

    /// <summary>
    /// X座標の取得
    /// </summary>
    /// <returns></returns>
    public int GetPos()
    {
        return num;
    }

}
