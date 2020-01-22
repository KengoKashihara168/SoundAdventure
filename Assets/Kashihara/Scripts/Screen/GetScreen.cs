using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScreen : MonoBehaviour
{
    private bool isGet;

    // Start is called before the first frame update
    void Start()
    {
        isGet = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen()
    {
        gameObject.SetActive(true);
    }

    public void OnYesButton()
    {
        isGet = true;
    }

    public void OnNoButton()
    {
        isGet = false;
    }

    public bool IsGet()
    {
        return isGet;
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}
