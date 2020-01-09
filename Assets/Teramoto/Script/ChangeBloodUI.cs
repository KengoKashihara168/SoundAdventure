using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBloodUI : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    private Image m_Image;
    // スプライトオブジェクトを格納する配列
    public Sprite[] m_Sprite;
    // スプライトオブジェクトを変更するためのフラグ
    bool Change;

    // ゲーム開始時に実行する処理
    void Start()
    {
        // スプライトオブジェクトを変更するためのフラグを false に設定
        Change = false;
        // Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();
    }

    // ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
        if(Change)
        {
            return;
        }
        else
        {

            Change = true;

            //乱数を回す
            int index = UnityEngine.Random.Range(0, 7);

            //配列に乱数を入れる。
            int ransu = index;

            rurret(ransu);
        }
    }

    void rurret(int a)
    {
        switch (a)
        {
            case 0:
                m_Image.sprite= m_Sprite[0];
                break;

            case 1:
                m_Image.sprite = m_Sprite[1];

                break;

            case 2:
                m_Image.sprite = m_Sprite[2];

                break;

            case 3:
                m_Image.sprite = m_Sprite[3];

                break;
            case 4:
                m_Image.sprite = m_Sprite[4];

                break;

            case 5:
                m_Image.sprite = m_Sprite[5];

                break;

            case 6:
                m_Image.sprite = m_Sprite[6];

                break;

            case 7:
                m_Image.sprite = m_Sprite[7];

                break;

            default:
                print("ねぇよ");
                break;

        }

    }

}