using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoveTrigger : MonoBehaviour {

	private Action<Transform> callBack;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male") || other.tag.Equals("famale"))
		{
			if(callBack != null)
			{
				callBack(transform.parent);
			}
		}
	}

	public void SetCallBack(Action<Transform> back)
	{
		callBack = back;
	}
}
