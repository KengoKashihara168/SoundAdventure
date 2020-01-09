using UnityEngine;
using UnityEngine.UI;

public class PrivateResultManager : MonoBehaviour
{
    [SerializeField]
    ItemGetManager itemGetManager;
    //個人の結果表示---
    [SerializeField]
    private Text youMoveText;
    //しましたの表示
    [SerializeField]
    private Text text;
    //ゴールに着いたかのフラグ
    bool goalArriveFlag;
    //ゴールが開いているかのフラグ
    bool goalUnlockFlag;
    //死亡したかのフラグ
    bool deathFlag;
    //プレイヤーの今の情報を知るための変数
    string nowInformation;
    [SerializeField]
    //プレイヤーの今の状態を表示
    private Text state;
    //全体の様子を確認するボタン
    [SerializeField]
    private Button checkButton;
    //ボタンが押されたかのフラグ
    bool checkButtonFlag;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void Initialize()
    {
        //初期化
        nowInformation = "何も無かった";
        goalArriveFlag = false;
        goalUnlockFlag = false;
        checkButtonFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが知った情報を表示
        PlayerNewInformation();        
    }

    //プレイヤーが知った情報を表示
    void PlayerNewInformation()
    {
        //ゴールがあるマスに止まって鍵が開いていたら
        if (goalArriveFlag == true && goalUnlockFlag == true)
        {
            nowInformation = "ゴール";
        }
        //死亡していたら
        if (deathFlag == true)
        {
            nowInformation = "死亡";
        }
        
        //アイテムを獲得
        if (itemGetManager.GetItemGetFlag() == true)
        {
            nowInformation = "アイテムを獲得";
            state.GetComponent<RectTransform>().localPosition = new Vector3(-70, 52, 0);
        }
        //今のプレイヤーの状態を表示
        state.GetComponent<Text>().text = nowInformation.ToString();
    }
    //全体の様子を確認するボタンを押した時
    public void ClickCheckButton()
    {
        checkButtonFlag = true;
        this.gameObject.SetActive(false);
    }

    public bool GetCheckButtonFlag()
    {
        return checkButtonFlag;
    }
}
