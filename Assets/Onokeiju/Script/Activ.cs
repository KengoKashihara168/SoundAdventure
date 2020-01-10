using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activ : MonoBehaviour
{
    [SerializeField] GameObject direction;
    [SerializeField] GameObject moveDecision;
    [SerializeField] GameObject swordDecision;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void MovePlay()
    {

        direction.SetActive(true);
        moveDecision.SetActive(true);

    }
    public void MoveHide()
    {

        direction.SetActive(false);
        moveDecision.SetActive(false);

    }
    public void SwordPlay()
    {

        direction.SetActive(true);
        swordDecision.SetActive(true);

    }
    public void SwordHide()
    {

        direction.SetActive(false);
        swordDecision.SetActive(false);

    }
}