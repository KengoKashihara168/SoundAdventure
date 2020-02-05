using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Image[] background;
    private AudioScene master;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        master = this.gameObject.GetComponent<AudioScene>();
    }

    // Update is called once per frame
    void Update()
    {
        // メインのキャンバスの子のサブキャンバスから非表示にするUIを探す
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "AudioScreen")
            {
                foreach (Transform schild in child.transform)
                {
                    // UIの表示非表示のフラグを元に変更
                    if (master.GetActive())
                    {
                        child.gameObject.SetActive(master.GetActive());
                        schild.gameObject.SetActive(master.GetActive());
                    }
                    else
                    {
                        child.gameObject.SetActive(master.GetActive());
                        schild.gameObject.SetActive(master.GetActive());
                    }
                }
            }
        }
    }
    public void SetBackground(Sprite image)
    {
        // メインのキャンバスの子のサブキャンバスから非表示にするUIを探す
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "Audiosub")
            {
                foreach (Transform schild in child.transform)
                {
                    if (schild.name == "Panel")
                    {
                        schild.GetComponent<Image>().sprite = image;
                    }
                }
            }
        }
    }
}
