using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方角
/// </summary>
public enum Direction
{
    None,  // なし
    East,  // 東
    West,  // 西
    South, // 南
    North, // 北
}

/// <summary>
/// マップの座標に使用する構造体
/// </summary>
public struct MapIndex
{
    public int    row;    // 行
    public string column; // 列

    public void SetIndex(int r,string c)
    {
        row = r;
        column = c;
    }
}

public class StageMap : MonoBehaviour
{
    // 定数
    private readonly string[] Column = { "A", "B", "C", "D", "E" }; // 列の添え字用配列
    private readonly int      MapSize = 5;                          // マップの大きさ

    // メンバ変数
    private Dictionary<string, Chip>[]  map;          // マップの2次元配列
    [SerializeField] private GameObject chip;         // チップ
    [SerializeField] private float      chipDistance; // 各チップの距離
    private MapIndex[] playerPosition;
    private List<MapIndex>itemPostion;
    private Item[] allItem;

    // Start is called before the first frame update
    void Start()
    {
        // マップの初期化
        map = new Dictionary<string, Chip>[MapSize];
        for(int i = 0;i < MapSize;i++)
        {
            // 行の生成
            map[i] = new Dictionary<string, Chip>();
        }

        // 列の生成
        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                // マップへチップを登録
                var key = Column[j];
                var value = ChipCreate();
                map[i].Add(key, value);

                // 各チップに値を設定
                map[i][key].SetName(i, key);
                Vector3 pos = new Vector3(chipDistance * j, -chipDistance * i, 0.0f);
                value.SetPosition(pos);
            }
        }

        itemPostion = new List<MapIndex>();
        playerPosition = new MapIndex[4];
        allItem = new Item[4];
        for(int i=0;i<allItem.Length;i++)
        {
            allItem[i] = new Item();
        }
    }

    private Chip ChipCreate()
    {
        // チップの生成
        GameObject obj = Instantiate(chip, Vector3.zero, Quaternion.identity);

        // 生成したチップを子に追加
        obj.transform.SetParent(transform);

        return obj.GetComponent<Chip>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public MapIndex GetPosition(int row,string column)
    {
        MapIndex index;

        // ------- 初期配置 ------- //
        index.row = row;
        index.column = column;
        // ------- 初期配置 ------- //

        return index;
    }
    public void SetItem(int row, string column,AudioClip audio, ItemKind kind)
    {
        MapIndex index;
        index.row = row;
        index.column = column;
        GameObject obj = GameObject.Find(index.row + index.column);

        obj.GetComponent<Chip>().SetAduio(audio);
        obj.GetComponent<Chip>().SetItem(kind);
    }

    public Item GetItemInfo(MapIndex player)
    {
        GameObject obj = GameObject.Find(player.row + player.column);
        return obj.GetComponent<Chip>().GetItem();
    }

    public void GetNextChip(int playerNum,Direction dir)
    {
        MapIndex pos = playerPosition[playerNum];
        MapIndex chip = pos;



    }
    public Dictionary<string, Chip>[] GetMap()
    {
        return map;
    }
    public string[] GetColumn()
    {
        return Column;
    }

    public void ItemChip()
    {
        GameObject chip = new GameObject();
        for(int i=0;i<map.Length;i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                chip = GameObject.Find(i + Column[j]);
                if(chip.GetComponent<Chip>().GetItem().GetKind()!=ItemKind.None)
                {
                    itemPostion.Add(chip.GetComponent<Chip>().GetMapindex());
                }
            }
        }
    }
    public List<MapIndex> GetItemPostion()
    {
        return itemPostion;
    }

    public void SetItemInfo(ItemKind kind,AudioClip clip,int num)
    {
        allItem[num].SetInfo(kind, clip);
    }
    public Item[] GetItemInfo()
    {
        return allItem;
    }
}
