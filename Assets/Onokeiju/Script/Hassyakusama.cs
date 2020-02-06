using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hassyakusama : MonoBehaviour
{
    
    private  MapIndex position;//八尺様のposition

    public Player[] player;

    bool release;

    // Start is called before the first frame update
    void Start()
    {
        release = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetTransPostion()
    {
        GameObject chip = GameObject.Find(position.row + position.column);
        this.gameObject.transform.position = chip.gameObject.transform.position;
    }
    public Transform GetTransPostion()
    {
        return this.gameObject.transform;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public void SetPostion(int row,string column)
    {

        position.SetIndex(row, column);
    }

    public MapIndex GetPosition()
    {
       
        return position;
    }

    public bool GetRelease()
    {
        return release;
    }
    public void SetRelease(bool flag)
    {
        release = flag;
    }

    public void MoveDirection()
    {
        //アスキーコード番号
        int ascli;
        //プレイヤーのアスキーコード番号
        int playerascli;
        //計算用
        int column=0;
        //近いプレイヤーのcolumnの保存
        int saveColumn =0;
        //近いプレイヤーのrowの保存
        int saveRow =0;
        //プレイヤーとの距離
        int total;
        //距離の保存
        int saveTotal = 0;

        for (int i = 0; i < 4; i++)
        {
            if (player[i].IsHaunted()|| player[i].IsDropOut())
                continue;
            //プレイヤーとの距離の計算

            //columnをアスキーコードに変換
            ascli = (int)position.column.ToCharArray()[0];
            playerascli = (int)player[i].GetPotision().column.ToCharArray()[0];

            //東西を判別し保存
            if (0 < ascli - playerascli)
            {
                column = ascli - playerascli;
            }
            else
            {
                column = (ascli - playerascli) * -1;
            }

            
            total = player[i].GetPotision().row - position.row + column;

            //保存した距離より近かったら上書き
            if (saveTotal > total)
            {
                saveTotal = total;
                if (0 < ascli - playerascli)
                {
                    saveColumn = -column;
                }
                else
                {
                    saveColumn = column;

                }
                   
                saveRow = player[i].GetPotision().row;
            }
        }

        //移動回数
        int moveNam = Random.Range(1, 4);

        //移動方向
        Direction col;
        Direction row;

        //移動回数分繰り返す
        for (int i = 0; i < moveNam; i++)
        {
            //東西どちらか判別同じラインならNone
            if (saveColumn>0)
            {
                col = Direction.East;
            }
            else if(saveColumn == 0)
            {
                col = Direction.None;
            }
            else
            {
                col = Direction.West;
            }

            

            //北南どちらか判別同じラインならNone
            if (saveRow > 0)
            {
                row = Direction.North;
            }
            else if (saveRow == 0)
            {
                row = Direction.None;
            }
            else
            {
                row = Direction.South;
            }


            //どの方向に向かうか
            if(row==Direction.None && col!= Direction.None)
            {
                MoveAction(col);
            }
            else if (row != Direction.None && col == Direction.None)
            {
                MoveAction(row);
            }
            else if (row != Direction.None && col != Direction.None)
            {

                if(0==Random.Range(0, 1))
                {
                    MoveAction(col);
                }
                else
                {
                    MoveAction(row);
                }
            }



        }



    }

    public void MoveAction(Direction dir)
    {
       
        int ascli;
        char charascli;
        switch (dir)
        {
            case Direction.North:// 北
                if (position.row - 1 >= 0)
                    position.row -= 1;
                break;
            case Direction.South:// 南
                if (position.row + 1 <= 4)
                    position.row += 1;
                break;
            case Direction.West:// 西
                ascli = (int)position.column.ToCharArray()[0];
                if (ascli - 1 >= 65)
                {
                    ascli -= 1;
                    charascli = (char)ascli;
                    position.column = charascli.ToString();
                }
                break;
            case Direction.East:// 東
                ascli = (int)position.column.ToCharArray()[0];
                if (ascli + 1 <= 69)
                {
                    ascli += 1;
                    charascli = (char)ascli;
                    position.column = charascli.ToString();
                }
                break;
        }
    }
}
