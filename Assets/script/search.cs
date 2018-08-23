using UnityEngine;
using System.Collections;
using System.Linq;

public class search : MonoBehaviour {
    public static bool one = false, two = false, three = false;
    public static bool four = false, five = false, six = false, none=false;
    public static GameObject nearObj = null;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    // Use this for initialization
    void Start()
    {
        //初期化
        one = false;
        two = false;
        three = false;
        four = false;
        five = false;
        six = false;
        none = false;
        nearObj = null;
        searchTime = 0;

        nearObj = serchTag(gameObject, "Respawn");
    }

    // Update is called once per frame
    void Update()
    {
      
        nearObj = serchTag(gameObject, "Respawn");
        //Debug.Log(nearObj);
    
        
       
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }
}