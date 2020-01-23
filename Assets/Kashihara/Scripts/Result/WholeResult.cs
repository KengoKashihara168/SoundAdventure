using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WinType
{
    None,
    Youth,
    Haunted,
}

public struct Result
{
    public List<string> deadNames; // 死亡したプレイヤー達
    public List<string> goalNames; // 脱出したプレイヤー達
    public bool isGetItem;         // アイテム獲得フラグ
    public WinType winer;          // 勝利タイプ
}

public class WholeResult : MonoBehaviour
{
    [SerializeField] private ResultDebug debug;

    private Result result;

    [SerializeField] private Text deadList;
    [SerializeField] private Text goalList;
    [SerializeField] private Text itemGet;
    [SerializeField] private Image youthWin;
    [SerializeField] private Image HauntedWin;

    // Start is called before the first frame update
    void Start()
    {
        result = debug.GetResult();
    }

    // Update is called once per frame
    void Update()
    {
        WriteResult();
    }

    /// <summary>
    /// 全体結果の表示
    /// </summary>
    public void WriteResult()
    {
        // 勝者の表示
        WriteWiner();

        // 死亡リストの表示
        WriteList(deadList, result.deadNames);
        // 脱出リストの表示
        WriteList(goalList, result.goalNames);
        // アイテム獲得の表示
        if (result.isGetItem)
        {
            // テキストの表示
            VisibleText(itemGet);
        }
    }

    /// <summary>
    /// 勝者の表示
    /// </summary>
    private void WriteWiner()
    {
        switch (result.winer)
        {
            case WinType.None: // 勝者なし
                // 何も表示しない
                break;
            case WinType.Youth: // 青年の勝利
                // 青年の画像を表示
                WriteImage(youthWin);
                break;
            case WinType.Haunted: // 憑人の勝利
                // 憑人の表示
                WriteImage(HauntedWin);
                break;
        }
    }

    /// <summary>
    /// 画像の表示
    /// </summary>
    /// <param name="image">表示したい画像</param>
    private void WriteImage(Image image)
    {
        if (image == null) return;

        image.enabled = true;
    }

    /// <summary>
    /// 結果リストの表示
    /// </summary>
    /// <param name="texts">表示されるテキスト</param>
    /// <param name="list">表示するリスト</param>
    private void WriteList(Text texts, List<string> list)
    {
        if (list.Count <= 0) return; // リストがなければ何もしない
        // テキストを表示
        VisibleText(texts);

        for (int i = 0; i < list.Count; i++)
        {
            // テキストにリストを設定
            Text text = texts.transform.GetChild(i).GetComponent<Text>();
            Debug.Assert(text != null, "Textがありませんでした。");
            text.text = list[i];
        }
    }

    /// <summary>
    /// テキストの表示
    /// </summary>
    /// <param name="text">表示させるテキスト</param>
    private void VisibleText(Text text)
    {
        if (text == null) return;
        text.gameObject.SetActive(true);
    }


}
