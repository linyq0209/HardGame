using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BollController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void FixedUpdate()
	{
		
	}

	protected void InitBollInfo()
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male"))
		{
			// Debug.Log("姑娘请自重");
			//给女人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Famale);
			Destroy(this.gameObject);

		}
		if(other.tag.Equals("famale"))
		{
			// Debug.Log("先生别这样");
			//给男人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Male);
			Destroy(this.gameObject);
		}
	}
}
