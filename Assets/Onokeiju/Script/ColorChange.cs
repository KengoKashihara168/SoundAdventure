using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] map;
    public Player player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Color(int row,string column)
    {
        //columnをintに変換
        int ascli;
        ascli =column.ToCharArray()[0];
        //渡されたの位置のオブジェクトのカラー変更    
        map[row + (ascli-65) * 5].GetComponent<Image>().color = new Vector4(1, 0, 1, 1);
    }
}
