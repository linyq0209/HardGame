using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour {

	public Text score;
	private int time = 0;
	public GameObject pauseBtn;
	public GameObject exitBtn;
	public Text gameState;
	private bool isStartGame = true;
	public Text maleStatusBar;
	public Text famaleStatusBar;
	private int maleCapCount = 0;
	private int famaleCapCount = 0;

	void Start () {
		pauseBtn.GetComponent<Button>().onClick.AddListener(OnClickPauseBtn);
		exitBtn.GetComponent<Button>().onClick.AddListener(OnClickExitBtn);
		EventNotificationCenter.GetInstance().AddListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
	}
	
	void Update () {
		
	}

	//游戏积分
	void FixedUpdate()
	{	
		if(isStartGame){
			time += 1;
			if(time % 50 == 0)
			{
				string value = (time/50).ToString();
				score.text = string.Format("{0}hours",value);
			}
		}
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
	}

	//暂停按钮点击事件
	protected void OnClickPauseBtn()
	{
		if(!isStartGame)
		{
			isStartGame = true;
			gameState.text = "Pause"; 
			EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Start);
		}
		else
		{
			isStartGame = false;
			gameState.text = "Start"; 
			EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Pause);
		}
	}

	//结束游戏按钮点击事件
	protected void OnClickExitBtn()
	{
		Debug.Log("Exit Game");
	}

	protected void AddGreenCap(int sex)
	{
		if(sex == 0)
		{
			maleCapCount++;
			maleStatusBar.text = string.Format("GreenCap X {0}", maleCapCount);
		}
		if(sex == 1)
		{
			famaleCapCount++;
			famaleStatusBar.text = string.Format("GreenCap X {0}", famaleCapCount);
		}
	}
}
