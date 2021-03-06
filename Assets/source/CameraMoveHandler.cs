﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMoveHandler : MonoBehaviour {
	public GameObject player;
	private bool isMoveCamera = false;
	private const string GUI_NAME = "greenCap";
	private float initPositionY = 0.571f;
	private int maleOrderLayer = 2;

	void Start () {
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.PAUSE_EVENT,PauseMove);
		EventNotificationCenter.GetInstance().AddListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
		EventNotificationCenter.GetInstance().AddListener(BroadEvent.GAMERESET_EVENT,ResetPosition);
	}
	
	void LateUpdate () {
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
		EventNotificationCenter.GetInstance().RemoveListener(BroadEvent.GAMERESET_EVENT,ResetPosition);
	}

	//开始游戏
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
			obj.transform.parent = player.transform;
			obj.transform.localPosition = new Vector3(-0.027f,initPositionY,0);
			obj.layer = obj.transform.parent.gameObject.layer;
			obj.GetComponent<SpriteRenderer>().sortingOrder = maleOrderLayer;
			maleOrderLayer++;
			initPositionY += 0.3f;
		}

		//给女人一顶绿帽子
		if(gameObject.transform.name == "Camera_2" && sex == 1)
		{
			GameObject obj = GameObject.Instantiate(ResourceManager.GetInstance().GetPrefab(GUI_NAME));
			obj.transform.parent = player.transform;
			obj.transform.localPosition = new Vector3(-0.027f,initPositionY,0);
			obj.layer = obj.transform.parent.gameObject.layer;
			initPositionY += 0.3f;
		}
	}

	//重置初始位置
	protected void ResetPosition()
	{
		if(gameObject.transform.name == "Camera_1")
		{
			gameObject.transform.localPosition = new Vector3(-5.5f,-1.15f,90f);
		}
		if(gameObject.transform.name == "Camera_2")
		{
			gameObject.transform.localPosition = new Vector3(6f,-1.3f,90f);
		}
		initPositionY = 0.571f;
	}
}
