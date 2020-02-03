using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mfMap;
    private GameObject[] map;
    public GameObject oldobjct;
    public Player player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void SetMap()
    {
        int max = mfMap.transform.childCount;
        map = new GameObject[max];
        for (int i = 0; i < max; i++)
        {
            map[i] = mfMap.transform.GetChild(i).gameObject;
        }
        oldobjct = map[0];
    }

    public void Color(int row,string column)
    {
        ColorReset();
        //columnをintに変換
        int ascli;
        ascli =column.ToCharArray()[0];
        //渡されたの位置のオブジェクトのカラー変更    
        if(0<= row * 5 + (ascli - 65)&& row * 5 + (ascli - 65)<=24)
        {
            map[row * 5 + (ascli - 65)].GetComponent<Image>().color = new Vector4(1, 0, 1, 1);
            oldobjct = map[row * 5 + (ascli - 65)];
        }

    }
    public void Color(MapIndex rc)
    {
        ColorReset();
        //columnをintに変換
        int ascli;
        ascli = rc.column.ToCharArray()[0];
        //渡されたの位置のオブジェクトのカラー変更  
        if (0 <= rc.row * 5 + (ascli - 65) && rc.row * 5 + (ascli - 65) <= 24)
        {
            map[rc.row * 5 + (ascli - 65)].GetComponent<Image>().color = new Vector4(1, 0, 1, 1);
            oldobjct = map[rc.row * 5 + (ascli - 65)];
        }
    }
    public void ColorReset()
    {
        oldobjct.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
}
