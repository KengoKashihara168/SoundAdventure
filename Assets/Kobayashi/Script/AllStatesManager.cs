using UnityEngine;
using UnityEngine.UI;


public class AllStatesManager : MonoBehaviour
{
    [SerializeField]
    private WholeResult WholeResult;
    
    [SerializeField]
    private PlayerNameManager playerGoalManager;
    [SerializeField]
    private PlayerNameManager playerDeathManager;
    //誰かがアイテムを獲得していますを表示
    [SerializeField]
    private Text whoItemGetText;
    //ボタンが押されたかのフラグ
    bool nextButtonFlag;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initialize()
    {
        //初期化
        nextButtonFlag = false;
        whoItemGetText.enabled = false;
        playerGoalManager.AllUnActive();
        playerDeathManager.AllUnActive();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //プレイヤーの今の状態を管理する
    public void ActivePlayerName(bool death, string name)
    {
        //死亡していたら
        if (death == true)
        {
            //死亡欄に表示
            playerDeathManager.ActivePlayerName(name);
        }
        else　//ゴールしていたら
        {
            //ゴール欄に表示
            playerGoalManager.ActivePlayerName(name);
        }
        //アイテムを獲得した人がいたら
        if (WholeResult.IsGetItem() == true)
        {
            //アイテムを獲得と表示
            whoItemGetText.enabled = true;
        }
    }

    //次に行くボタンを押した時
    public void NextButton()
    {
        this.gameObject.SetActive(false);
        nextButtonFlag = true;
    }

    public bool GetNextButtonFlag()
    {
        return nextButtonFlag;
    }
}
