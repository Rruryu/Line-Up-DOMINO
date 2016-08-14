using UnityEngine;
using System.Collections;

public class PieceContorol : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public float y = 0f;
    string objName;
    string CubeName;
    public GameObject Clickobj;
    public GameObject Ccube;
    bool click = false;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
    void Update()
    {
        //LayerMaskの宣言
        int Piece = LayerMask.GetMask(new string[] { LayerMask.LayerToName(8) });
        int ClearCube = LayerMask.GetMask(new string[] { LayerMask.LayerToName(9) });
        //Pieceの選択&回転
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Piece))
            {
                /*Collider col = hit.collider;
                var v = new Vector3(0, 90f, 0);
                col.transform.Rotate(v);
                Debug.Log("test");*/
                objName = hit.collider.gameObject.name;
                Clickobj = GameObject.Find(objName);
                click = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            var v = new Vector3(0, 90f, 0);
            Clickobj.transform.Rotate(v);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            var v = new Vector3(0, -90f, 0);
            Clickobj.transform.Rotate(v);
        }
        //pieceの移動(ClearCube戸の入れ替え)
        if (Input.GetMouseButtonUp(0) && click)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ClearCube))
            {
                CubeName = hit.collider.gameObject.name;
                Ccube = GameObject.Find(CubeName);
                Debug.Log(CubeName);
            }/*
            if()
            {
                
            }
            else
            if()
            {
            
            }*/
        }
    }
    /*
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp()
    {
        Debug.Log("");
    }*/
}
