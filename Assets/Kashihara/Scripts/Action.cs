using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private Direction direction;      // 進行方向
    private bool      isKilling;      // 刀の使用フラグ
    private Direction swordDirection; // 刀を使用する方向
    private bool      isGet;          // アイテム取得フラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 刀の使用
    /// </summary>
    /// <param name="select">使用するかしないか</param>
    /// <param name="dir">使用する方向</param>
    public void IsKill(bool select,Direction dir)
    {
        isKilling = select;
        swordDirection = dir;
    }

    /// <summary>
    /// アイテムの取得
    /// </summary>
    /// <param name="select">取得するかしないか</param>
    public void IsGet(bool select)
    {
        isGet = select;
    }
}
