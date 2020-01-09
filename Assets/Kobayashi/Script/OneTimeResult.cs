using UnityEngine;

public class OneTimeResult : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    WholeResult wholeResult;

    [SerializeField]
    ItemGetManager itemGetManager;

    [SerializeField]
    PrivateResultManager privateResultManager;

    [SerializeField]
    AllStatesManager allStatesManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Initialize()
    {
        //初期化
        itemGetManager.Initialize();
        itemGetManager.gameObject.SetActive(false);

        privateResultManager.Initialize();
        privateResultManager.gameObject.SetActive(false);

        allStatesManager.Initialize();
        allStatesManager.gameObject.SetActive(false);
    }
    //移動先にアイテムがあった用
    public void InitializeItem()
    {
        Initialize();
        itemGetManager.gameObject.SetActive(true);
    }
    //移動先にアイテムがなかった用
    public void InitializePrivate()
    {
        Initialize();
        privateResultManager.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //移動先にアイテムがあったら
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeItem();
        }
        //移動先にアイテムがなかったら
        if (Input.GetKeyDown(KeyCode.S))
        {
            InitializePrivate();

        }
        //アイテムを拾うかを選んだら
        if (itemGetManager.GetPushButtonFlag() == true)
        {
            //個人の結果を表示
            privateResultManager.gameObject.SetActive(true);
            itemGetManager.Initialize();
        }
        //個人の結果を確認したら
        if (privateResultManager.GetCheckButtonFlag() == true)
        {
            //全体の結果を表示
            allStatesManager.gameObject.SetActive(true);
            privateResultManager.Initialize();
            //--ここで誰がどの状態かをもらう
            for (int i = 0; i < 4; i++)
            {
                if (player.IdDead() == true)
                {
                    allStatesManager.ActivePlayerName(true, wholeResult.DeadPlayers()[i]);
                }
                if (player.IsGoal() == true)
                {
                    allStatesManager.ActivePlayerName(false, wholeResult.GoalPlayers()[i]);
                }
            }
           // allStatesManager.ActivePlayerName(true, "T");
            //------------------------------
        }
        //全体の結果を確認したら
        if (allStatesManager.GetNextButtonFlag() == true)
        {
            //他の場面へ
            allStatesManager.Initialize();
        }

    }
}
