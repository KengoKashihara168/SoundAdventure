using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenButton : MonoBehaviour
{
    [SerializeField] private ScreenType screenType;
    private GameScene gameScene;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnScreenButton(screenType));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnScreenButton(ScreenType type)
    {
        gameScene.ChangeScreen(type);
    }
}
