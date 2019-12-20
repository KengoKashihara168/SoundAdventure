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
    // UI表示非表示
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCamera");
        dire.text = "北";
        // カメラをプレイヤーのポジションに移動させる
        CameraPlayer();
        // どれが一番近いか判別して保存する
        AudioClose();
        // UI
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // カメラのゲッター
    public GameObject GetCamera()
    {
        return player;
    }
    // カメラの回転
    public void CameraAddAngle(int angle)
    {
        //カメラを回転させる
        player.transform.RotateAround(player.transform.position, Vector3.up, angle);
    }
    // カメラの回転リセット
    public void CameraResetAngle()
    {
        //カメラを回転させる
        player.transform.rotation = Quaternion.identity;
    }
    // 音のゲッター
    public AudioSource GetAudio()
    {
        return audio;
    }
    // 向いている方向で方角を決める関数
    public void Direction()
    {
        Vector3 _Rotation = player.transform.localEulerAngles;
        Debug.Log(_Rotation.y);
        if (_Rotation.y==0)
        {
            dire.text = "北";
        }
        else if (_Rotation.y == 90)
        {
            dire.text = "東";
        }
        else if (_Rotation.y ==270)
        {
            dire.text = "西";
        }
        else if (_Rotation.y == 180)
        {
            dire.text = "南";
        }
    }
    // UIの表示フラグのゲッター
    public bool GetActive()
    {
        return active;
    }
    // UIの表示フラグのセッター
    public void SetActive(bool flag)
    {
        active = flag;
    }
    // 一番近い音の判別関数
    public void AudioClose()
    {
        // どれが一番近いか判別して保存する
    }
    // カメラをプレイヤーのポジションに移動させる
    public void CameraPlayer()
    {
        // カメラをプレイヤーのポジションに移動させる
    }
}
