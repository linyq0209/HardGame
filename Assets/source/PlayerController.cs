using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject playerObj;
	
	public GameObject leftBtn;

	public GameObject rightBtn;

	public float speed = 2.5f;
	
	void Start()
	{
		leftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
		rightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);
	}

	protected void OnClickLeft()
	{
		if(playerObj.transform.localPosition.x < -2.2f ) 
		{
			return;
		}
		else{
			playerObj.transform.localPosition += new Vector3(-2.5f,0,0);
		}
	}

	protected void OnClickRight()
	{
		if(playerObj.transform.localPosition.x > 2.5f )
		{
			return;
		}
		else{
			playerObj.transform.localPosition += new Vector3(2.5f,0,0);
		}
	}
	
	public void ChangeGreenCap(bool isReduce)
	{
		
	}

	public void ChangeSpeed(float newSpeed)
	{
		speed = newSpeed;
	}
}
