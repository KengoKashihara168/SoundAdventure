using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPlayerScreen : MonoBehaviour
{
    [SerializeField] private Text playerCount;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScreen(int playerNum)
    {
        gameObject.SetActive(true);
        playerCount.text = playerNum.ToString() + "人目";
    }

    public void OnNextButton()
    {
        gameObject.SetActive(false);
    }
}
