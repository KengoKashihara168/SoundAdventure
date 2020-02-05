using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangetoTItle : MonoBehaviour
{

    bool ISFlag=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ISFlag)
        {
            //SceneManager.LoadScene("Title");
            print("Scene変わった");
        }
    }

    public void SceneChangeFlagButton()
    {
        ISFlag = true;
    }

    public bool GetFlag()
    {
        return ISFlag;
    }
}
