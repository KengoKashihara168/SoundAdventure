using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobScreen : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Sprite youthImage;
    [SerializeField] private Sprite hauntedImage;
    [SerializeField] private Image jobImage;
=======
    [SerializeField] private Image jobImage;
    [SerializeField] private Sprite youthSprite;
    [SerializeField] private Sprite hauntedSprite;
>>>>>>> Kashihara_PUN2

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        //gameObject.SetActive(false);
=======
        
>>>>>>> Kashihara_PUN2
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
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
=======
    public void OpenScreen(bool isHaunted)
    {
        gameObject.SetActive(true);
        if(isHaunted)
        {
            jobImage.sprite = hauntedSprite;
        }
        else
        {
            jobImage.sprite = youthSprite;
        }
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }


>>>>>>> Kashihara_PUN2
}
