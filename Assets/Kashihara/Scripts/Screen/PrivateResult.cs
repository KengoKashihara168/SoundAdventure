using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivateResult : MonoBehaviour
{
    
    [SerializeField] private Image image;     // 画像
    [SerializeField] private Sprite hassyaku; // 八尺様
    [SerializeField] private Sprite exit;     // 出口
    [SerializeField] private Sprite none;     // 何もなし
    [SerializeField] private Sprite key;      // 鍵
    [SerializeField] private Sprite amulet;   // 御札
    [SerializeField] private Sprite cutter;   // カッター
    [SerializeField] private Sprite sword;    // 刀

    private Player player;   // プレイヤー


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 画像の切り替え
    /// </summary>
    /// <param name="player">プレイヤー</param>
    public void OpenScreen(Player player)
    {
        gameObject.SetActive(true);
        
        //if(player.isDead)
        //{
        //    image.sprite = hassyaku;
        //    return;
        //}

        //if(player.isGoal)
        //{
        //    image.sprite = exit;
        //    return;
        //}

        //switch(player.GetItemKind())
        //{
        //    case ItemKind.Key:
        //        image.sprite = key;
        //        break;
        //    case ItemKind.Amulet:
        //        image.sprite = amulet;
        //        break;
        //    case ItemKind.Cutter:
        //        image.sprite = cutter;
        //        break;
        //    case ItemKind.Sword:
        //        image.sprite = sword;
        //        break;
        //    case ItemKind.MaxItem:
        //        image.sprite = none;
        //        break;
        //}
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}
