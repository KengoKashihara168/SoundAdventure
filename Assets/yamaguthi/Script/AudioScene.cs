using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScene : MonoBehaviour
{
    public GameObject player;
    private GameObject camera;
    public GameObject map;
    Vector3 strcameraRot;
    // 方角のテキスト
    public Text dire;
    // 音の位置
    public AudioSource audio;
    // UI表示非表示
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera");
        dire.text = "北";
        // カメラをプレイヤーのポジションに移動させる
        CameraPlayer();
        // どれが一番近いか判別して保存する
        AudioClose();
        // UI
        active = false;
        strcameraRot = camera.transform.eulerAngles;
        Debug.Log(strcameraRot);
        camera.GetComponent<Camera>().enabled = false;
    }
    // カメラのゲッター
    public GameObject GetCamera()
    {
        return camera;
    }
    // カメラの回転
    public void CameraAddAngle(int angle)
    {
        //カメラを回転させる
        camera.transform.Rotate(-angle, 0.0f, 0.0f);
       // camera.transform.RotateAround(camera.transform.position, Vector3.up, angle);
    }
    // カメラの回転リセット
    public void CameraResetAngle()
    {
        camera.transform.rotation = Quaternion.Euler(strcameraRot.x, strcameraRot.y, strcameraRot.z);
    }
    // 音のゲッター
    public AudioSource GetAudio()
    {
        return audio;
    }
    // 向いている方向で方角を決める関数
    public void Direction()
    {
        Vector3 _Rotation = camera.transform.eulerAngles;
        Debug.Log(_Rotation.x);
        Debug.Log(_Rotation.y);
        if (_Rotation.x == 270 && _Rotation.y==90)
        {
            dire.text = "北";
        }
        else if (_Rotation.x == 0 && _Rotation.y == 270)
        {
            dire.text = "西";
        }
        else if (_Rotation.x == 0 && _Rotation.y ==90)
        {
            dire.text = "東";
        }
        else if (_Rotation.x == 90 && _Rotation.y == 90)
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
        /*
        GameObject top;
        float oldDistance=0;
        for (int i=0;i<map.Lenge;i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if ( その場所に音がなるものがあれば)
                {
                    // どれが一番近いか判別して保存する
                    Vector2 posA = new Vector2(player.GetComponent<Player>().postion, player.GetComponent<Player>().postion);
                    Vector2 posB = new Vector2(map[i].Column[j], map[i].Column[j]);

                    float distance = (posA - posB).magnitude;
                    if (i != 0)
                    {
                        if (oldDistance > distance)
                        {
                            oldDistance = distance;
                            top = Map.();
                        }
                    }
                    else
                    {
                        oldDistance = distance;
                        top = map[i].Column[j];
                    }
                }
            }


        }
      
        audio = top;
    */
    }
    // カメラをプレイヤーのポジションに移動させる
    public void CameraPlayer()
    {
        // カメラをプレイヤーのポジションに移動させる
      //  camera.transform.position= player.GetComponent<Player>().postion;
    }
}
