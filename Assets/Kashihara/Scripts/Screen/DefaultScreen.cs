using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultScreen : MonoBehaviour
{
    [SerializeField] private Image jobImage;
    [SerializeField] private Sprite youthSprite;
    [SerializeField] private Sprite hauntedSprite;
    [SerializeField] private Text posText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Sprite[] itemSprite;

    [SerializeField] private Button soundButton;
    [SerializeField] private Button moveButton;

    // Start is called before the first frame update
    void Start()
    {
        jobImage.sprite = youthSprite;
        moveButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen(bool isHaunted,MapIndex index,ItemKind item)
    {
        gameObject.SetActive(true);
        if(isHaunted)
        {
            jobImage.sprite = hauntedSprite;
        }
        posText.text = "現在の居場所：" + index.row.ToString() + index.column;

        if (item == ItemKind.MaxItem) return;
        itemImage.sprite = itemSprite[(int)item];
    }

    /// <summary>
    /// 音を聞くボタンが押されたとき
    /// </summary>
    public void OnSoundButton()
    {
        soundButton.gameObject.SetActive(false);
        moveButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// 移動するボタンが押されたとき
    /// </summary>
    public void OnMoveButton()
    {
        soundButton.gameObject.SetActive(true);
        moveButton.gameObject.SetActive(false);
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}
