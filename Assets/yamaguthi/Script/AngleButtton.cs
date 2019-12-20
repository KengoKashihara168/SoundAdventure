using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AngleButtton : MonoBehaviour
{
    [SerializeField]
    public GameObject master;
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
        master.GetComponent<AudioScene>().CameraAddAngle(-90);
        // カメラの向きで方角を変える
        master.GetComponent<AudioScene>().Direction();
    }
    public void RightAngle()
    {
        // カメラを90度回転
        master.GetComponent<AudioScene>().CameraAddAngle(90);
        // カメラの向きで方角を変える
        master.GetComponent<AudioScene>().Direction();
    }
    public void NextScene()
    {
        // シーン遷移
        SceneManager.LoadScene("Move");
    }
}
