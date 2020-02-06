using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterScriot : MonoBehaviour
{
    // プレイヤー
    public GameObject[] Player;
    // 現在のプレイヤー
    int nowPlayer;
    string[] texts;
    // Start is called before the first frame update
    void Start()
    {
        nowPlayer = 0;
        texts = new string[4];
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i] = "";
        }
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
    public bool CheckPosition(MapIndex a,MapIndex b)
    {
        if (a.row == b.row && a.column == b.column)
        {
            return true;
        }
        return false;
    }
    public void SetName(int num,string text)
    {
        texts[num] = text;
    }
    public string[] GetName()
    {
        return texts;
    }
    public bool CheckName(string str)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if(texts[i]== str)
            {
                Debug.Log("被った");
                return false;
            }
        }
        return true;
    }
}
