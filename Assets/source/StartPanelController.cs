using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelController : MonoBehaviour {
	public GameObject playBtn;
	public Text inputMale;
	public Text inputFamale;
	private bool isInitPanel = false;
	
	void Start () {
		playBtn.GetComponent<Button>().onClick.AddListener(PlayBtnOnClick);
	}
	
	
	void Update () {
		
	}

	protected void PlayBtnOnClick()
	{
		string maleName = inputMale.text;
		string famaleName = inputFamale.text;
		if(!isInitPanel){
			if(maleName == string.Empty && famaleName == string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,Name.SysMale,Name.SysFamale);
			}
			else if(maleName != string.Empty && famaleName == string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,inputMale.text,Name.SysFamale);
			}
			else if(maleName == string.Empty && famaleName != string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,Name.SysMale,inputFamale.text);
			}
			else
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,maleName,famaleName);
			}
			Debug.Log(maleName);
			Debug.Log(famaleName);
			isInitPanel = true;
		}
		gameObject.active = false;
		EventNotificationCenter.GetInstance().Broadcast<bool>(BroadEvent.GAMESTART_EVENT,Pause.Game_Start);
	}
}

