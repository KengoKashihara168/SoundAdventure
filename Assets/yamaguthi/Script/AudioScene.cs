using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScene : MonoBehaviour
{
    [SerializeField] Hassyakusama hassyaku;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioUI audioUI;
    public GameObject Master;
    public Sprite[] background;
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
        camera = GameObject.Find("Main Camera");
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
        camera.transform.Rotate(0.0f, -angle, 0.0f);
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
        if ( _Rotation.y==0)
        {
            dire.text = "北";
           audioUI.SetBackground(background[0]);
        }
        else if ( _Rotation.y == 270)
        {
            dire.text = "西";
            audioUI.SetBackground(background[1]);
        }
        else if (_Rotation.y == 90)
        {
            dire.text = "東";
           audioUI.SetBackground(background[2]);
        }
        else if ( _Rotation.y == 180)
        {
            dire.text = "南";
            audioUI.SetBackground(background[3]);
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
        MapIndex index =new MapIndex();
        nowPlayer = Master.GetComponent<MasterScriot>().GetNowPlayer();
        hassyaku.SetTransPostion();
        Debug.Log(nowPlayer+"音をとる");
        index = player[nowPlayer].GetComponent<Player>().GetPotision();
        obj = GameObject.Find(index.row + index.column);
        Vector2 A = new Vector2(obj.transform.position.x, obj.transform.position.y);
        Vector2 B = new Vector2(hassyaku.GetTransPostion().position.x, hassyaku.GetTransPostion().position.y);
        float distance2 = (A - B).magnitude;
        Debug.Log(distance2);
        Debug.Log("八尺");
        oldDistance = distance2;
        top = hassyaku.GetGameObject();
        audio = top.GetComponent<AudioSource>();
        for (int i = 0; i < olmap.Length; i++)
        {
            for (int j = 0; j < olmap[i].Count; j++)
            {
                obj = GameObject.Find(i+ col[j]);
             
                if (obj.GetComponent<Chip>().GetItem().GetKind()!=ItemKind.None)
                {
                    //どれが一番近いか判別して保存する
                    index = player[nowPlayer].GetComponent<Player>().GetPotision();
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
                            top = obj;
                        }
                        else
                        {
                            if (oldDistance == distance)
                            {
                                int rm = Random.Range(0, 1);
                                switch (rm)
                                {
                                    case 0:
                                        oldDistance = distance;
                                        top = obj;
                                        break;
                                    case 1:
                                        // 何もしない
                                        break;
                                }
                            }
                        }    
                    }
                    else
                    {
                        oldDistance = distance;
                        top = obj;
                    }
                }
            }
        }
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
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
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
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }
    public void BGMONOFF()
    {
        Debug.Log(bgm.mute);
        bgm.mute = !bgm.mute;
    }
}
