using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceMove : MonoBehaviour
{
    bool putswitch;
    static public int cnt=0;
    GameObject PosMane;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // Use this for initialization
    void Start()
    {
        PosMane = GameObject.Find("PositionManeger");
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (GetComponent<lighton>().put_switch&&this.name==obj.name&&cnt<14) {
                    mover();
                }
            }
        }
    }
    void mover()
    {
        Vector3 manepos = PosMane.transform.position;
        manepos.y = 0;
        audioSource.PlayOneShot(audioClip[0]);
        if (cnt < 2||(cnt>=7&&cnt<11))//→→におく
        {
            if (search.nearObj.name == transform.GetChild(1).name)//子の名前で判断　回転方向
            {
                transform.eulerAngles += new Vector3(0f,-90f, 0f);
                transform.position = manepos;

            }
            else
            {
                transform.eulerAngles += new Vector3(0f, 90, 0f);
                manepos.x++;
                transform.position = manepos;
                manepos.x--;
            }

            for (int i=0; i < 3; i++)
            {
                transform.GetChild(i).eulerAngles += new Vector3(0.0f, -90.0f, 0.0f);//子を全て回転 数字の向きがおかしくなるため
            }
            //maneger 
            if (cnt == 0||(cnt>=7&&cnt<10))//→→
            {
                PosMane.transform.position += new Vector3(2.0f, 0.0f, 0.0f);
                PosMane.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            }
            else if(cnt == 1)//→↓にいく　ライトずれるので角度も変える
            {
                PosMane.transform.position += new Vector3(1.0f, 0.0f, -1.0f);
                PosMane.transform.eulerAngles += new Vector3(0.0f, 90.0f, 0.0f);
            }
            else if (cnt == 10)//→↑
            {
                PosMane.transform.position += new Vector3(1.0f, 0.0f, 1.0f);
                PosMane.transform.eulerAngles += new Vector3(0.0f, -90.0f, 0.0f);
            }
            
        }
        if (cnt==2||cnt==3||cnt==6)//↓↓におく
        {
            if (search.nearObj.name == transform.GetChild(1).name)//子の名前で判断　回転方向
            {
                transform.position = manepos;
            }
            else
            {
                transform.eulerAngles += new Vector3(0f, 180f, 0f);
                manepos.z--;
                transform.position = manepos;
                manepos.z++;
            }
            //maneger ←↓ 
            if(cnt==2||cnt==3)
            {
                PosMane.transform.position += new Vector3(-1.0f, 0.0f, -1.0f);
            }else if (cnt == 6)//maneger ↓↓
            {
                    PosMane.transform.position += new Vector3(0.0f, 0.0f, -2.0f);
                    for (int i = 0; i < 3; i++)
                    {
                        transform.GetChild(i).eulerAngles += new Vector3(0.0f, -90.0f, 0.0f);//子を全て回転 数字の向きがおかしくなるため
                    }
            }
            

            if (cnt == 2)//ライト用
            {
                PosMane.transform.eulerAngles += new Vector3(0.0f, 90.0f, 0.0f);//マネージャー回転
            }
        }
        if(cnt==4||cnt==5)//←←
        {
            if (search.nearObj.name == transform.GetChild(1).name)//子の名前で判断　回転方向
            {
                transform.position = manepos;
                transform.eulerAngles += new Vector3(0f, 90f, 0f);
            }
            else
            {
                manepos.x--;
                transform.position = manepos;
                transform.eulerAngles += new Vector3(0f, -90f, 0f);
                manepos.x++;
            }
            //maneger ←↓
            PosMane.transform.position += new Vector3(-1.0f, 0.0f, -1.0f);
            if (cnt == 4)
            {
                PosMane.transform.eulerAngles += new Vector3(0.0f, -90.0f, 0.0f);//ライト用
            }
        }
        if (cnt >= 11 && cnt < 14)
        {
            //↑↑
            if (search.nearObj.name == transform.GetChild(1).name)//子の名前で判断　回転方向　
            {
                transform.eulerAngles += new Vector3(0f, 180f, 0f);
                transform.position = manepos;
            }
            else
            {
                manepos.z++;
                transform.position = manepos;
                manepos.z--;
            }
            PosMane.transform.position += new Vector3(0.0f, 0.0f, 2.0f);


        }
        Debug.Log("カウント" + cnt);
        cnt++;
    }
    void bettermover()
    {

    }
}
