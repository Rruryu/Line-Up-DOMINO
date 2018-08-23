using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFlg : MonoBehaviour {
    public GameObject clearObj;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (lighton.allswitch)
        {
            clearObj.SetActive(true);
        }
	}
}
