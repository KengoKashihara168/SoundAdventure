using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScriot : MonoBehaviour
{
    // プレイヤー
    public GameObject[] Player;
    // 現在のプレイヤー
    int nowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        nowPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // プレイヤーゲッター
    public GameObject[] GetPlayer()
    {
        return Player;
    }
    /// <summary>
    /// 今のプレイヤーの番号
    /// </summary>
    /// <returns></returns>
    public int GetNowPlayer()
    {
        return nowPlayer;
    }
    // リセット
    public void ResetNowPlayer()
    {
        nowPlayer = 0;
    }
    // 次のプレイヤーへ
    public void AddNowPlayer()
    {
        nowPlayer++;
    }
}
