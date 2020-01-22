using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScreen : MonoBehaviour
{
    private bool isUse;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isUse = false;
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
        isUse = true;
    }

    public void OnNoButton()
    {
        isUse = false;
    }

    public bool IsUse()
    {
        return isUse;
    }

    public void CloseScreen()
    {
        isUse = false;
        gameObject.SetActive(false);
    }
}
