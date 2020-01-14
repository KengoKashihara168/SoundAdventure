using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapDate : MonoBehaviour
{
    private int num;
    public Image[] image;
    public Move move;
    public Material []material;
    // Start is called before the first frame update
    void Start()
    {
        num = 25;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < num; i++)
        {
            if (i == move.GetNum())
            {
                image[i].material = material[0];
            }
            else
            {

                image[i].material = material[1];
            }
        }


    }
}