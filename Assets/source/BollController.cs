using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BollController : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	public void OnInitBollInfo(int bollConfig)
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male"))
		{
			Debug.Log("姑娘请自重");
			gameObject.active = false;
		}
		if(other.tag.Equals("famale"))
		{
			Debug.Log("先生别这样");
			gameObject.active = false;
		}
	}
}
