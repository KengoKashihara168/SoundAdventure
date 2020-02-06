using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivateResult : MonoBehaviour
{
    [SerializeField] private Image resultImage;
    [SerializeField] private Text deadList;
    [SerializeField] private Text goalList;
    [SerializeField] private Sprite hassyaku; // 八尺様
    [SerializeField] private Sprite kill; // 八尺様
    [SerializeField] private Sprite exit;     // 出口
    [SerializeField] private Sprite notGoal;     // 出口
    [SerializeField] private Sprite none;     // 何もなし
    [SerializeField] private Sprite key;      // 鍵
    [SerializeField] private Sprite amulet;   // 御札
    [SerializeField] private Sprite cutter;   // カッター
    [SerializeField] private Sprite sword;    // 刀
    [SerializeField] private Sprite escape;    // 刀
    [SerializeField] GameObject[] text;
    [SerializeField] private Text  name;    //
    [SerializeField] private MasterScriot nowPlayer;    //
    [SerializeField] Hassyakusama hassyakuRe;
    private Player player;                    // プレイヤー
    private Image image;                      // 画像


    // Start is called before the first frame update
    void Start()
    {
        image = resultImage.GetComponent<Image>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenScreen(Player p,List<string> deadPlayers, List<string> GoalPlayers)
    {
        gameObject.SetActive(true);
        player = p;
        ChangeImage(player);

        ResetText("");

        foreach (var name in deadPlayers)
        {
            AddDeadText(name + ",");
            text[0].SetActive(true);
        }
        foreach (var name in GoalPlayers)
        {
            AddGoalText(name + ",");
            text[1].SetActive(true);
        }
    }

    /// <summary>
    /// 画像の切り替え
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public void ChangeImage(Player player)
    {
        name.text = nowPlayer.GetName()[nowPlayer.GetNowPlayer()]+ "が移動した先は";
        Debug.Log(player.GetPotision().row+ player.GetPotision().column);
        if(nowPlayer.CheckPosition(player.GetPotision(),hassyakuRe.GetPosition())&&player.IsHaunted())
        {
            image.sprite = hassyaku;
            return;
        }
        if(player.IsDead())
        {
            image.sprite = kill;
            Debug.Log("死んでる");
            player.SetDropOut(true);
            return;
        }
        if (player.IsGoalKey() && player.IsHaunted())
        {
            image.sprite = exit;
            player.SetGoalKey(false);
            return;
        }
        if (player.IsGoalKey())
        {
            image.sprite = notGoal;
            player.SetGoalKey(false);
            return;
        }
        if (player.IsGoal())
        {
            image.sprite = escape;
            player.SetDropOut(true);
            return;
        }
        
        if(player.IsTake())
        {
            switch (player.GetItemKind())
            {
                case ItemKind.Key:
                    image.sprite = key;
                    player.SetTake(false);
                    return;
                case ItemKind.Amulet:
                    image.sprite = amulet;
                    player.SetTake(false);
                    return;
                case ItemKind.Cutter:
                    image.sprite = cutter;
                    player.SetTake(false);
                    return;
                case ItemKind.Sword:
                    player.SetTake(false);
                    image.sprite = sword;
                    return;
                case ItemKind.None:
                    image.sprite = none;
                    break;
            }
        }
        image.sprite = none;
    }

    /// <summary>
    /// 死亡リストにプレイヤー名を追加
    /// </summary>
    /// <param name="name">死亡したプレイヤー名</param>
    private void AddDeadText(string name)
    {
        deadList.text += name;
    }
    /// <summary>
    /// ゴールリストにプレイヤー名を追加
    /// </summary>
    /// <param name="name">死亡したプレイヤー名</param>
    private void AddGoalText(string name)
    {
        goalList.text += name;
    }
    /// <summary>
    /// リストを空にする
    /// </summary>
    /// <param name="name">死亡したプレイヤー名</param>
    private void ResetText(string name)
    {
        deadList.text = name;
        goalList.text = name;
        for(int i=0;i< text.Length;i++)
        {
            text[i].SetActive(false);
        }
    }
}
