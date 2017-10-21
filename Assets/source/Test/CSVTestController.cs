using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTestController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("============");
		CSVTestManager.GetInstance ();
		// ResourceManager.GetInstance().GetPrefab(string name)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
