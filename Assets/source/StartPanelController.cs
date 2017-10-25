using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelController : MonoBehaviour {
	public GameObject playBtn;
	
	void Start () {
		playBtn.GetComponent<Button>().onClick.AddListener(PlayBtnOnClick);
	}
	
	
	void Update () {
		
	}

	protected void PlayBtnOnClick()
	{
		gameObject.active = false;
		EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.GAMESTART_EVENT,Pause.Game_Start);
	}
}
