using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeResult : MonoBehaviour
{
    [SerializeField] private List<string> deadPlayers; // 死亡したプレイヤー配列
    [SerializeField] private List<string> goalPlayers; // 脱出したプレイヤー配列
    [SerializeField] private bool     isGetItem;   // アイテム獲得フラグ
    [SerializeField] private bool     youthWinFlag;    // 青年の勝利フラグ
    [SerializeField] private bool     hauntedWinFlag;  // 憑人の勝利フラグ

    [SerializeField] private Text deadList;
    [SerializeField] private Text goalList;
    [SerializeField] private Text itemGet;
    [SerializeField] private Image youthWin;
    [SerializeField] private Image HauntedWin;


    // Start is called before the first frame update
    void Start()
    {
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
        // 青年の勝利
        if(youthWinFlag)
        {
            WriteImage(youthWin);
            return;
        }

        // 憑人の勝利
        if(hauntedWinFlag)
        {
            WriteImage(HauntedWin);
            return;
        }

        // 死亡リストの表示
        WriteList(deadList, deadPlayers);
        // 脱出リストの表示
        WriteList(goalList, goalPlayers);
        // アイテム獲得の表示
        if (isGetItem)
        {
            VisibleText(itemGet);
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
