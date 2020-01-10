using UnityEngine;
using UnityEngine.UI;

public class ItemGetManager : MonoBehaviour
{
    //アイテムの獲得---
    //画像の表示
    [SerializeField]
    private Image itemImage;
    //画像のデータ
    [SerializeField]
    private Sprite[] itemSprite;
    //アイテム名の表示
    string itemText;
    //アイテムを獲得しますか？を表示
    [SerializeField]
    private Text itemGetText;
    //ボタンの表示
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    //ボタンが押されたかのフラグ
    bool pushButtonFlag;
    //アイテム獲得のフラグ
    bool itemGetFlag;
    //-----------------

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initialize()
    {
        //初期化
        itemText = "ネコ";
        itemGetFlag = false;
        pushButtonFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        ItemImageGet();
        //アイテムの画像情報を取得
        ItemGet();
    }

    //アイテムの画像情報を取得
    void ItemImageGet()
    {
        // アイテムの画像を変更
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            itemImage.sprite = itemSprite[0];
            itemText = "ネコ";
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            itemImage.sprite = itemSprite[1];
            itemText = "ワシ";
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            itemImage.sprite = itemSprite[2];
            itemText = "キツネ";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            itemImage.sprite = itemSprite[3];
            itemText = "ラッコ";
        }
     
    }

    //アイテムを見つけた時の処理
    void ItemGet()
    {
        //(アイテム名)を獲得しますか？を表示
        itemGetText.text = itemText + "を獲得しますか？";
    }

    //いいえのボタンを押した時
    public void NoButton()
    {
        Debug.Log("クリックされた");
        //アイテムを獲得していない
        itemGetFlag = false;
        //ボタンが押された
        pushButtonFlag = true;
        this.gameObject.SetActive(false);
    }

    //はいのボタンを押した時
    public void YesButton()
    {
        Debug.Log("クリックされた");
        //アイテムを獲得した
        itemGetFlag = true;
        //ボタンが押された
        pushButtonFlag = true;
        this.gameObject.SetActive(false);
    }

    public bool GetItemGetFlag()
    {
        return itemGetFlag;
    }

    public bool GetPushButtonFlag()
    {
        return pushButtonFlag;
    }
}
