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
	public Text maleName;
	public Text famaleName;
	public AudioSource bgMusic;
	private int greenCapCount = 0;
	public GameObject gameOverSprite;
	

	void Start () {
		pauseBtn.GetComponent<Button>().onClick.AddListener(OnClickPauseBtn);
		exitBtn.GetComponent<Button>().onClick.AddListener(OnClickExitBtn);
		//监听添加绿帽子事件
		EventNotificationCenter.GetInstance().AddListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		//监听游戏开始事件
		EventNotificationCenter.GetInstance().AddListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
		//监听登陆画面输入的姓名
		EventNotificationCenter.GetInstance().AddListener<string,string>(BroadEvent.INPUTNAME_EVENT,InputName);
	}
	
	//控制游戏结束
	void Update () {
		// if(greenCapCount == 10 && isStartGame)
		// {
		// 	isStartGame = false;
		// 	//派发游戏暂停事件
		// 	EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Pause);
		// 	bgMusic.GetComponent<AudioSource>().Pause();
		// 	gameOverSprite.SetActive(true);
		// }
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
		//移除监听
		EventNotificationCenter.GetInstance().RemoveListener<int>(BroadEvent.GREENCAPDATA_EVENT,AddGreenCap);
		EventNotificationCenter.GetInstance().RemoveListener<bool>(BroadEvent.GAMESTART_EVENT,StartGame);
		EventNotificationCenter.GetInstance().RemoveListener<string,string>(BroadEvent.INPUTNAME_EVENT,InputName);
	}

	//开始游戏
	void StartGame(bool eventVO)
	{
		isStartGame = eventVO;
		bgMusic.gameObject.SetActive(eventVO);
	}

	//暂停按钮点击事件
	protected void OnClickPauseBtn()
	{
		if(!isStartGame)
		{
			isStartGame = true;
			bgMusic.GetComponent<AudioSource>().Play(); 
			gameState.text = "Pause"; 
			//派发游戏继续事件
			EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Continue);
		}
		else
		{
			isStartGame = false;
			bgMusic.GetComponent<AudioSource>().Pause();
			gameState.text = "Start"; 
			EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Pause);
		}
	}

	//结束游戏按钮点击事件 重置所有参数
	protected void OnClickExitBtn()
	{
		greenCapCount = 0;
		isStartGame = false;
		EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.PAUSE_EVENT,Pause.Game_Pause);
		EventNotificationCenter.GetInstance().Broadcast(BroadEvent.GAMERESET_EVENT);
		bgMusic.gameObject.SetActive(false);
		gameOverSprite.SetActive(false);
		maleStatusBar.text = "";
		famaleStatusBar.text = "";
		score.text = "";
		maleCapCount = 0;
		famaleCapCount = 0;
		time = 0;
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
		greenCapCount++;
	}

	//改名
	protected void InputName(string male,string famale)
	{
		maleName.text = male;
		famaleName.text = famale;
	}
}
