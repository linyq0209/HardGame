using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollController : MonoBehaviour {
	bool canMove = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove)
			transform.localPosition += new Vector3(0,-10,0);
	}

	public void OnClickBoll()
	{
		canMove = false;
	}
}
