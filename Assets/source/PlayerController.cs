using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public GameObject playerObj;

	public GameObject leftBtn;

	public GameObject rightBtn;

	void Start()
	{
		leftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
		rightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);
	}

	protected void OnClickLeft()
	{
		playerObj.transform.localPosition += new Vector3(-2.5f,0,0);
	}

	protected void OnClickRight()
	{
		playerObj.transform.localPosition += new Vector3(2.5f,0,0);
	}
}
