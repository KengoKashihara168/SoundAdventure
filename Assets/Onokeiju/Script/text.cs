using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class text : MonoBehaviour
{
    public Image image;
   // public Text  textname;
    int count;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 255|| count <= 0)
        {
            a = -a;
        }
        count += a;
        image.material.color = new Vector4(130, 130, 130,(float)count/255);
        // 左クリックされた瞬間にif文の中を実行
        if (Input.GetMouseButtonDown(0))
        {
            // 処理
            SceneManager.LoadScene("MainScene");
        }

        // textname.color = new Vector4(255, 255, 255, (float)count/255);
    }
}