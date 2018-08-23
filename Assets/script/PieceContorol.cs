using UnityEngine;
using System.Collections;

public class PieceContorol : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public float y = 0f;
    string objName;
    GameObject clickobj;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	    //左クリックしたら
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                /*Collider col = hit.collider;
                var v = new Vector3(0, 90f, 0);
                col.transform.Rotate(v);
                Debug.Log("test");*/
                objName = hit.collider.gameObject.name;
                clickobj = GameObject.Find(objName);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            var v = new Vector3(0, 90f, 0);
            clickobj.transform.Rotate(v);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            var v = new Vector3(0, -90f, 0);
            clickobj.transform.Rotate(v);
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
