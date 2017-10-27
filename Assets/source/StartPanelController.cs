using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelController : MonoBehaviour {
	public GameObject playBtn;
	public Text inputMale;
	public Text inputFamale;
	private bool isInitPanel = false;
	public Image maleHeadImp;
	public Image famaleHeadImp;
	public GameObject setMaleHeadBtn;
	public GameObject setfamaleHeadBtn;
	public GameObject setHeadView;
	public GameObject setHeadViewMask;
	private int sex = -1;
	public GameObject takePhotoBtn;
	public GameObject selectPhotoBtn;

	void Start () {
		playBtn.GetComponent<Button>().onClick.AddListener(PlayBtnOnClick);
		setMaleHeadBtn.GetComponent<Button>().onClick.AddListener(SetMaleHeadBtnOnClick);
		setfamaleHeadBtn.GetComponent<Button>().onClick.AddListener(SetFamaleHeadBtnOnClick);
		setHeadViewMask.GetComponent<Button>().onClick.AddListener(SetHeadViewMaskOnClick);
		// takePhotoBtn.GetComponent<Button>().onClick.AddListener(TakePhoto(sex,0));
		// selectPhotoBtn.GetComponent<Button>().onClick.AddListener(TakePhoto(sex,1));
	}
	
	void Update () {
		
	}

	protected void PlayBtnOnClick()
	{
		string maleName = inputMale.text;
		string famaleName = inputFamale.text;
		inputMale.text = "";
		inputFamale.text = "";
		if(!isInitPanel){
			if(maleName == string.Empty && famaleName == string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,Name.SysMale,Name.SysFamale);
			}
			else if(maleName != string.Empty && famaleName == string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,maleName,Name.SysFamale);
			}
			else if(maleName == string.Empty && famaleName != string.Empty)
			{
				EventNotificationCenter.GetInstance().Broadcast<string,string>(BroadEvent.INPUTNAME_EVENT,Name.SysMale,famaleName);
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

	protected void SetHeadViewMaskOnClick()
	{
		setHeadView.SetActive(false);
		sex = -1;
	}

	protected void SetMaleHeadBtnOnClick()
	{
		setHeadView.SetActive(true);
		setHeadView.transform.localPosition = new Vector3(-197f,-19.9f,0f);
		sex = GreenCap.Give_Male;
	}

	protected void SetFamaleHeadBtnOnClick()
	{
		setHeadView.SetActive(true);
		setHeadView.transform.localPosition = new Vector3(198f,-19.9f,0f);
		sex = GreenCap.Give_Famale;
	}
	//调用图片处理 当choose = 0 的时候打开相机拍照  ||  choose=1的时候打开相册 
	// public void TakePhoto(int sex ,int choose){
 // 	      ImgManage.TakePhoto(choose);
	// }
}

