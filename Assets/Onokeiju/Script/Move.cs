using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    // MapDate a;
    int num;
    int save;
   
    // Start is called before the first frame update
    void Start()
    {
        num = Control.Instance.GetPlayerPosition(0);
        save = num;
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetNum()
    {
        return num - 1;
    }


    public void MoveNorth()
    {

        if (save > 5)
        {
            num = save - 5;

        }

    }


    public void MoveSouth()
    {

        if (save < 21)
        {
            num = save + 5;

        }

    }
    public void MoveWest()
    {

        if (save > 1 && 1 != save % 5)
        {
            num = save - 1;

        }

    }
    public void MoveEast()
    {

        if (save < 25 && 0 != save % 5)
        {
            num = save + 1;

        }

    }

    public void SceneChange()
    {
        Control.Instance.SetPosition(0,num);
        SceneManager.LoadScene("Result");
    }
}