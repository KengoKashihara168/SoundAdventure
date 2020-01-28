using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScene : MonoBehaviour
{
    public GameObject Master;
    // プレイヤー
    GameObject[] player;
    // カメラ
    private GameObject camera;
    private GameObject MainCamera;
    // マップ
    public GameObject map;
    // カメラのリセット用角度
    Vector3 strcameraRot;
    // 方角のテキスト
    public Text dire;
    // 音の位置
    public AudioSource audio;
    // UI表示非表示
    bool active;
    int nowPlayer;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("SoundCamera");
        MainCamera = GameObject.Find("Main Camera");
        dire.text = "北";
        player = Master.GetComponent<MasterScriot>().GetPlayer();
        nowPlayer = Master.GetComponent<MasterScriot>().GetNowPlayer();
        // カメラをプレイヤーのポジションに移動させる
       // CameraPlayer();
        // UI
        active = false;
        // リセット用に角度を保存
        strcameraRot = camera.transform.eulerAngles;
        // カメラを外す
        camera.GetComponent<Camera>().enabled = false;
    }
    // カメラのゲッター
    public GameObject GetCamera()
    {
        return camera;
    }
    // ゲームの主カメラのゲッター
    public GameObject GetMainCamera()
    {
        return MainCamera;
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
    public void SetDirection()
    {
        Vector3 _Rotation = camera.transform.eulerAngles;
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
        StageMap stm = map.GetComponent<StageMap>();
        GameObject top = GameObject.Find(0 + "A");
        Dictionary<string, Chip>[] olmap = stm.GetMap();
        string[] col = stm.GetColumn();
        float oldDistance = 20;
        GameObject obj;
        nowPlayer = Master.GetComponent<MasterScriot>().GetNowPlayer();
        for (int i = 0; i < olmap.Length; i++)
        {
            for (int j = 0; j < olmap[i].Count; j++)
            {
                obj = GameObject.Find(i+ col[j]);
             
                if (obj.GetComponent<Chip>().GetItem().GetKind()!=ItemKind.None)
                {
                    Debug.Log("音をとる");
                    //どれが一番近いか判別して保存する
                    MapIndex index = player[nowPlayer].GetComponent<Player>().GetPotision();
                    obj = GameObject.Find(index.row + index.column);
                    Vector2 posA = new Vector2(obj.transform.position.x, obj.transform.position.y);
                    index = player[nowPlayer].GetComponent<Player>().GetPotision();
                    obj = GameObject.Find(i + col[j]);
                    Vector2 posB = new Vector2(obj.transform.position.x, obj.transform.position.y);
                    float distance = (posA - posB).magnitude;
                    if (i != 0)
                    {
                        if (oldDistance > distance)
                        {
                            oldDistance = distance;
                            Debug.Log(obj);
                            top = obj;
                        }
                    }
                    else
                    {
                        oldDistance = distance;
                        Debug.Log(obj);
                        top = obj;
                    }
                }
            }


        }
        Debug.Log(top.GetComponent<Chip>().GetAduio());
        audio = top.GetComponent<Chip>().GetAduio();

    }
    // カメラをプレイヤーのポジションに移動させる
    public void NextPlayer()
    {
        MapIndex index = player[nowPlayer].GetComponent<Player>().GetPotision();
        GameObject pl = GameObject.Find(index.row+ index.column) ;
        // map[0]["A"];
        // カメラをプレイヤーのポジションに移動させる
        camera.transform.position = pl.transform.position;
    }
    // カメラをプレイヤーのポジションに移動させる
    public void CameraPlayer()
    {
        nowPlayer = Master.GetComponent<MasterScriot>().GetNowPlayer();
        MapIndex index = player[nowPlayer].GetComponent<Player>().GetPotision();
        GameObject pl = GameObject.Find(index.row + index.column);
        // map[0]["A"];
        // カメラをプレイヤーのポジションに移動させる
        camera.transform.position= pl.transform.position;
    }
}
