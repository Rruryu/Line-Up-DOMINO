using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
    bool click = false;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(click)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    
                }
            }
        }
	}
}
