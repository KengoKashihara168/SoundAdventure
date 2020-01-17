using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultScreen : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private Button moveButton;

    // Start is called before the first frame update
    void Start()
    {
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
}
