using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobScreen : MonoBehaviour
{
    [SerializeField] private Sprite youthImage;
    [SerializeField] private Sprite hauntedImage;
    [SerializeField] private Image jobImage;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 役職の画像を設定
    /// </summary>
    /// <param name="job">プレイヤーの憑人フラグ</param>
    public void SetJobImage(bool job)
    {
        //gameObject.SetActive(true);
        if(job)
        {
            jobImage.sprite = hauntedImage;
        }
        else
        {
            jobImage.sprite = youthImage;
        }
    }
}
