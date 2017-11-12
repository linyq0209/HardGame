using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BollController : MonoBehaviour {
	private SpriteRenderer spriteIcon;
	private DropSort sort;
	private DropHeadConfig mConfig;

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
		mConfig = DropHeadManager.GetInstance().GetRandomConfig();
		if(mConfig == null)
		{
			Debug.LogError("配置为 null");
		}
		spriteIcon.sprite = ResourceManager.GetInstance().GetSprite(mConfig.GetIconName());
		sort = mConfig.GetItemSort();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("male") || other.tag.Equals("famale"))
		{
			if(sort == DropSort.head_icon)
			{
				int id = other.tag.Equals("male") ? GreenCap.Give_Famale : GreenCap.Give_Male;
				EventNotificationCenter.GetInstance().Broadcast<int>(BroadEvent.GREENCAPDATA_EVENT,id);
				Destroy(this.gameObject);
			}else
			{
				int id = other.tag.Equals("male") ? GreenCap.Give_Male : GreenCap.Give_Famale;
				EventNotificationCenter.GetInstance ().Broadcast<DropHeadConfig,int> (BroadEvent.EFFECT_EVENT,mConfig,id);
				Destroy(this.gameObject);
			}
		}

	
	}
}
