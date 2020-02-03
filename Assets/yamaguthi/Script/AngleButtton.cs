using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleButtton : MonoBehaviour
{
    [SerializeField]
    public GameObject master;
    [SerializeField] Text audioText;
    public void Audio()
    {
        // 一番近い音のミュート ON OFF
        if(master.GetComponent<AudioScene>().GetAudio().mute)
        {
            Debug.Log("on");
            master.GetComponent<AudioScene>().GetAudio().mute = false;
            master.GetComponent<AudioScene>().GetAudio().Play();
        }
        else
        {
            Debug.Log("off");
            master.GetComponent<AudioScene>().GetAudio().mute = true;
            master.GetComponent<AudioScene>().GetAudio().Stop();
        }
    }
    public void LeftAngle()
    {
        // カメラを90度回転
        master.GetComponent<AudioScene>().CameraAddAngle(90);
        // カメラの向きで方角を変える
        master.GetComponent<AudioScene>().SetDirection();
    }
    public void RightAngle()
    {
        // カメラを90度回転
        master.GetComponent<AudioScene>().CameraAddAngle(-90);
        // カメラの向きで方角を変える
        master.GetComponent<AudioScene>().SetDirection();
    }
    public void NextScene()
    {
        if (master.GetComponent<AudioScene>().GetActive())
        {
            audioText.text = "音を聞く";
            master.GetComponent<AudioScene>().BGMONOFF();
            // UIを非表示に
            master.GetComponent<AudioScene>().SetActive(false);
            // カメラの回転リセット
            master.GetComponent<AudioScene>().CameraResetAngle();
            // 音が流れていたら止める
            if (!master.GetComponent<AudioScene>().GetAudio().mute)
            {
                Audio();
            }
        }
        else if (!master.GetComponent<AudioScene>().GetActive())
        {
            audioText.text = "閉じる";
            master.GetComponent<AudioScene>().BGMONOFF();
            // カメラをプレイヤーのポジションに移動させる
            master.GetComponent<AudioScene>().CameraPlayer();
            // 一番近い音の判別関数
            master.GetComponent<AudioScene>().AudioClose();
            // カメラの回転リセット
            master.GetComponent<AudioScene>().CameraResetAngle();
            // カメラの向きで方角を変える
            master.GetComponent<AudioScene>().SetDirection();
            // UIを表示する
            master.GetComponent<AudioScene>().SetActive(true);
        }
    }
}
