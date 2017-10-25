using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour {

	public Text score;
	private int time = 0;
	public GameObject pauseBtn;
	public GameObject exitBtn;
	public GameObject startPanel;
	public Text gameState;
	private bool isStartGame = false;
	public Text maleStatusBar;
	public Text famaleStatusBar;
	private int maleCapCount = 0;
	private int famaleCapCount = 0;

	void Start () {
		pauseBtn.GetComponent<Button>().onClick.AddListener(OnClickPauseBtn);
		exitBtn.GetComponent<Button>().onClick.AddListener(OnClickExitBtn);
		EventNotificationCenter.GetInstance().AddListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
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
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
	}

	//开始游戏
	void StartGame(bool eventVO)
	{
		isStartGame = eventVO;
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
		isStartGame = false;
		EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Pause);
		startPanel.SetActive(true);
	}

	//得分栏添加绿帽子
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
