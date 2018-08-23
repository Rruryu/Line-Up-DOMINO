using UnityEngine;
using System.Collections;

public class lighton : MonoBehaviour
{
    string now_pos;
    string piece_pos;
    GameObject piece_light;
    bool putswitch;
    public static bool allswitch;
    public bool put_switch {
        get { return putswitch; }
        private set { putswitch = value; }

    }

    // Use this for initialization
    void Start()
    {
        allswitch = false;
        now_pos = "";
        piece_pos = "";
        piece_pos = this.gameObject.name;
        if (search.nearObj == null) now_pos = "3";//ステージ1の最初の数字
        else now_pos = search.nearObj.name;
        Debug.Log(now_pos + "," + piece_pos);
        piece_light=gameObject.transform.Find("light").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        now_pos = search.nearObj.name;
        if (PieceMove.cnt != 14)
        {
            if ((now_pos[0] == piece_pos[0] || now_pos[0] == piece_pos[2]) && transform.position.x > 9)
            {
                piece_light.GetComponent<Light>().enabled = true;
                put_switch = true;
            }
            else
            {
                piece_light.GetComponent<Light>().enabled = false;
                put_switch = false;
            }
        }
        else//クリアしたら全部光らせる
        {
            piece_light.GetComponent<Light>().enabled = true;
            put_switch = true;
            allswitch = true;

        }
        
    
      
    }
}

