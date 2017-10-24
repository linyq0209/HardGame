
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoveHandler : MonoBehaviour {
	public Transform lastBg;
	void Start()
	{
		foreach(MoveTrigger trigger in GetComponentsInChildren<MoveTrigger>())
		{
			trigger.SetCallBack(MoveTriggerCallBack);
		}
	}

	protected void MoveTriggerCallBack(Transform tarns)
	{
		tarns.localPosition = lastBg.localPosition + new Vector3(0,13.3f,0);
		//@TDSH
		// if(tarns.GetComponent<CreateBoll>() == null)
		// {
		// 	Debug.Log("is null"+tarns.name);		
		// }
		tarns.GetComponent<CreateBoll>().ToCreateBoll();
		Debug.Log("============Trigger Collision!============");
		lastBg = tarns;
	}
}
