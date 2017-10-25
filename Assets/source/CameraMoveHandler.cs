using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMoveHandler : MonoBehaviour {
	private bool isMoveCamera = false;
	private const string GUI_NAME = "greenCap";
	private float initPositionY = -3.39f;

	void Start () {
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.PAUSE_EVENT,PauseMove);
		EventNotificationCenter.GetInstance().AddListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
	}
	
	void Update () {
		if(isMoveCamera)
		{
			CameraOnMove();
		}
	}

	void FixedUpdate()
	{

	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.PAUSE_EVENT,PauseMove);
		EventNotificationCenter.GetInstance().RemoveListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
	}

	//开始有游戏
	void StartGame(bool eventVO)
	{
		isMoveCamera = eventVO;
	}

	public void CameraOnMove()
	{
		transform.position += Vector3.up *0.1f;
	}

	protected void PauseMove(bool eventVO)
	{
		isMoveCamera = eventVO;
	}

	protected void AddGreenCap(int sex)
	{
		//给男人一顶绿帽子
		if(gameObject.transform.name == "Camera_1" && sex == 0)
		{
			GameObject obj = GameObject.Instantiate(ResourceManager.GetInstance().GetPrefab(GUI_NAME));
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = new Vector3(0.2f,initPositionY,200f);
			obj.layer = obj.transform.parent.gameObject.layer;
			initPositionY += 0.3f;
		}

		//给女人一顶绿帽子
		if(gameObject.transform.name == "Camera_2" && sex == 1)
		{
			GameObject obj = GameObject.Instantiate(ResourceManager.GetInstance().GetPrefab(GUI_NAME));
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = new Vector3(0.2f,initPositionY,200f);
			obj.layer = obj.transform.parent.gameObject.layer;
			initPositionY += 0.3f;
		}
	}
}
