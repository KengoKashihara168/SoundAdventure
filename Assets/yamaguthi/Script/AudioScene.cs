using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScene : MonoBehaviour
{
    private GameObject player;
    // 方角のテキスト
    public Text dire;
    // 音の位置
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCamera");
        dire.text = "北";
        // カメラをプレイヤーのポジションに移動させる
        player.transform.position=new Vector3( Control.Instance.GetPlayerPosition(0)%5,0, (Control.Instance.GetPlayerPosition(0) - 1) / 5);
        //// どれが一番近いか判別して保存する
        //audio = MapControl.Instance.GetAudio(15);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public GameObject GetCamera()
    {
        return player;
    }
    public void CameraAddAngle(int angle)
    {
        //カメラを回転させる
        player.transform.RotateAround(player.transform.position, Vector3.up, angle);
    }
    public AudioSource GetAudio()
    {
        return audio;
    }
    public void Direction()
    {
        Vector3 _Rotation = player.transform.localEulerAngles;
        Debug.Log(_Rotation.y);
        if (_Rotation.y==0)
        {
            Debug.Log("通る北");
            dire.text = "北";
        }
        else if (_Rotation.y == 90)
        {
            Debug.Log("通る東");
            dire.text = "東";
        }
        else if (_Rotation.y ==270)
        {
            Debug.Log("通る西");
            dire.text = "西";
        }
        else if (_Rotation.y == 180)
        {
            Debug.Log("通る南");
            dire.text = "南";
        }
    }
}
