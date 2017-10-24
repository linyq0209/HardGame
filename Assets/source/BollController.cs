using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BollController : MonoBehaviour {
	public GameObject trustValue;

	private int time = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void FixedUpdate()
	{
		time += 1;
		
	}

	protected void InitBollInfo()
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male"))
		{
			Debug.Log("姑娘请自重");
			gameObject.active = false;
			//给女人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Famale);

		}
		if(other.tag.Equals("famale"))
		{
			Debug.Log("先生别这样");
			gameObject.active = false;
			//给男人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Male);
		}
	}
}
