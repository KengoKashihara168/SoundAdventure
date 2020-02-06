using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NameCreate : MonoBehaviour
{
    [SerializeField] MasterScriot masterScript;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject notCreate;
    // Start is called before the first frame update
    void Start()
    {
        notCreate.SetActive(false);
    }
    
    public bool ChName()
    {
        if (masterScript.CheckName(inputField.text))
        {
            masterScript.SetName(masterScript.GetNowPlayer(), inputField.text);
            return true;
        }
        else
        {
            notCreate.SetActive(true);
            return false;
        }

    }
    public void ResetBox()
    {
        inputField.text = "";
    }
}
