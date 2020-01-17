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
    public static readonly  int[]    Row     = { 0, 1, 2, 3, 4 };           // 行の添え字用配列
    public static readonly  string[] Column  = { "A", "B", "C", "D", "E" }; // 列の添え字用配列
    public static readonly  int      MapSize = 5;                           // マップの大きさ
    public static readonly float ChipDistance = 2.0f;

    // メンバ変数
    private Dictionary<string, Chip>[]  map;          // マップの2次元配列
    [SerializeField] private GameObject chip;         // チップ
    private MapIndex[] playerPosition;

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
                Vector3 pos = new Vector3(ChipDistance * j, -ChipDistance * i, 0.0f);
                value.SetPosition(pos);
            }
        }

        playerPosition = new MapIndex[4];
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

    public MapIndex GetPosition()
    {
        MapIndex index;

        // ------- 初期配置 ------- //
        index.row = 0;
        index.column = "A";
        // ------- 初期配置 ------- //

        return index;
    }

    public ItemInfo GetItemInfo(int playerNum)
    {
        ItemInfo info = new ItemInfo();
        info.position.SetIndex(6, "MapItem");
        return info;
    }

    public void GetNextChip(int playerNum,Direction dir)
    {
        MapIndex pos = playerPosition[playerNum];
        MapIndex chip = pos;



    }

    /// <summary>
    /// インデックスがマップの範囲内か調べる
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static bool CheckRange(MapIndex index)
    {
        if (index.row >= MapSize) return false; // 行の上限をチェック
        if (index.row < 0) return false;        // 行の下限をチェック

        bool columnResult = false;
        foreach(var column in Column)
        {
            if(index.column == column)
            {
                columnResult = true;
            }
        }

        return columnResult;
    }

    public static Vector3 ConvertToVector(MapIndex index)
    {
        Vector3 vec = Vector3.zero;

        for(int i = 0;i < Row.Length;i++)
        {
            if (index.row != Row[i]) continue;
            vec.y = -ChipDistance * i;
        }

        for (int i = 0; i < Column.Length; i++)
        {
            if (index.column != Column[i]) continue;
            vec.x = ChipDistance * i;
        }

        return vec;
    }
}
