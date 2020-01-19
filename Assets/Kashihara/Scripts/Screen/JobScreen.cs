using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobScreen : MonoBehaviour
{
    [SerializeField] private Image jobImage;
    [SerializeField] private Sprite youthSprite;
    [SerializeField] private Sprite hauntedSprite;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetJobSprite(bool isHaunted)
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
}
