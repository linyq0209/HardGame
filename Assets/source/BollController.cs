using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BollController : MonoBehaviour {
	private SpriteRenderer spriteIcon;
	void Start () {
		spriteIcon = GetComponent<SpriteRenderer>();
	}

	protected void InitBollInfo()
	{
		
	}

	void OnEnable()
	{
		StartCoroutine(NextFrameDo());
	}

	IEnumerator NextFrameDo()
	{
		yield return 1;
		DropHeadConfig config = DropHeadManager.GetInstance().GetRandomConfig();
		spriteIcon.sprite = ResourceManager.GetInstance().GetSprite(config.GetIconName());
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male"))
		{
			// Debug.Log("姑娘请自重");
			//给女人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Famale);
			Destroy(this.gameObject);

		}
		if(other.tag.Equals("famale"))
		{
			// Debug.Log("先生别这样");
			//给男人加一顶绿帽子
			EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,GreenCap.Give_Male);
			Destroy(this.gameObject);
		}
	}
}
