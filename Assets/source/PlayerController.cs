using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject playerObj;
	public GameObject leftBtn;
	public GameObject rightBtn;
	public float speed = 2.5f;
	private bool isStartGame = false;
	
	void Start()
	{
		leftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
		rightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.PAUSE_EVENT,PauseGame);
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
		EventNotificationCenter.GetInstance().AddListener(BroadEvent.GAMERESET_EVENT,ResetGame);
	}

	void StartGame(bool eventVO)
	{
		isStartGame = eventVO;
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.PAUSE_EVENT,PauseGame);
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
		EventNotificationCenter.GetInstance().RemoveListener(BroadEvent.GAMERESET_EVENT,ResetGame);
	}
	
	protected void OnClickLeft()
	{
		if(!isStartGame) return;
		if(playerObj.transform.localPosition.x < -2.2f ) 
		{
			return;
		}
		else{
			playerObj.transform.localPosition += new Vector3(-speed,0,0);
		}
	}

	protected void OnClickRight()
	{
		if(!isStartGame) return;
		if(playerObj.transform.localPosition.x > 2.5f )
		{
			return;
		}
		else{
			playerObj.transform.localPosition += new Vector3(speed,0,0);
		}
	}
	
	public void ChangeGreenCap(bool isReduce)
	{
		
	}

	public void ChangeSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	protected void PauseGame(bool eventVO)
	{
		isStartGame = eventVO;
	}

	protected void ResetGame()
	{
		for (int i = 0; i < playerObj.transform.childCount; i++) {  
            Destroy (playerObj.transform.GetChild (i).gameObject);  
        }  
        playerObj.transform.localPosition = new Vector3(0.25f,-4.01f,200f);
	}
}
