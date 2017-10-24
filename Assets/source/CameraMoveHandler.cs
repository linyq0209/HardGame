using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveHandler : MonoBehaviour {
	private bool isMoveCamera = true;

	void Start () {

		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.PAUSE_EVENT,PauseMove);
	}
	
	void Update () {
		if(isMoveCamera)
		{
			CameraOnMove();
		}
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.PAUSE_EVENT,PauseMove);
	}

	public void CameraOnMove()
	{
		transform.position += Vector3.up *0.1f;
	}

	protected void PauseMove(bool eventVO)
	{
		isMoveCamera = eventVO;
	}
}
