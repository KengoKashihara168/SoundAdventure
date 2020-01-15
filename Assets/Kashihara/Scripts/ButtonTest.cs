using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    ScreenType type;
    [SerializeField] GameScene gameScene;

    // Start is called before the first frame update
    void Start()
    {
        type = ScreenType.Private;
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
