using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Debug.Log("test");
	    string test;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    public void SceneLoad()
    {
        SceneManager.LoadScene("scene1");
    }
}
