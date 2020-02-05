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
    float count;
    float scale;
    int num;
    bool mapScale;
    void Start()
    {
        count = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        scale += count;
        if (scale>=1||scale<=0)
        {
            count = -count;
        }
       
        if(mapScale)
            map[num].transform.localScale = new Vector3(scale, scale, scale);
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

    public void ColorCh(int row,string column)
    {
        ColorReset();
        //columnをintに変換
        int ascli;
        ascli =column.ToCharArray()[0];
        //渡されたの位置のオブジェクトのカラー変更    
        if(0<= row * 5 + (ascli - 65)&& row * 5 + (ascli - 65)<=24)
        {
            //  map[row * 5 + (ascli - 65)].GetComponent<Image>().color = Color.yellow;
            map[row * 5 + (ascli - 65)].transform.localScale = new Vector3(scale, scale, scale);
            oldobjct = map[row * 5 + (ascli - 65)];
            num = row * 5 + (ascli - 65);
            mapScale = true;
        }
       
    }
    public void ColorCh(MapIndex rc)
    {
        ColorReset();
        //columnをintに変換
        int ascli;
        ascli = rc.column.ToCharArray()[0];
        //渡されたの位置のオブジェクトのカラー変更  
        if (0 <= rc.row * 5 + (ascli - 65) && rc.row * 5 + (ascli - 65) <= 24)
        {
            //  map[rc.row * 5 + (ascli - 65)].GetComponent<Image>().color = Color.yellow;
            map[rc.row * 5 + (ascli - 65)].transform.localScale = new Vector3(scale, scale, scale); 
            oldobjct = map[rc.row * 5 + (ascli - 65)];
            num = rc.row * 5 + (ascli - 65);
            mapScale = true;
        }
    }
    public void ColorReset()
    {
        oldobjct.transform.localScale = new Vector3(1, 1, 1);
        mapScale = false;
    }
}
