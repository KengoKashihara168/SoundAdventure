using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndButtton : MonoBehaviour
{
    public void EndScene()
    {
        SceneManager.LoadScene("Title");
    }
}
