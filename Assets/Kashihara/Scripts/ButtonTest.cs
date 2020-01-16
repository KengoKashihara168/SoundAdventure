using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] ScreenType type;
    [SerializeField] GameScene gameScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScreenButton()
    {
        gameScene.OnScreenButton(type);
    }
}
