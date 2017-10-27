
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoveHandler : MonoBehaviour {
	public Transform lastBg;
	public Transform bg1;
	public Transform bg2;
	public Transform bg3;

	void Start()
	{
		foreach(MoveTrigger trigger in GetComponentsInChildren<MoveTrigger>())
		{
			trigger.SetCallBack(MoveTriggerCallBack);
		}
		EventNotificationCenter.GetInstance().AddListener(BroadEvent.GAMERESET_EVENT,ResetPosition);
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener(BroadEvent.GAMERESET_EVENT,ResetPosition);
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
	//重置游戏
	protected void ResetPosition()
	{
		bg1.localPosition = new Vector3(0f,0f,0f);
		bg2.localPosition = new Vector3(0f,13.3f,0f);
		bg3.localPosition = new Vector3(0f,26.6f,0f);
		lastBg = bg3;
	}
}
