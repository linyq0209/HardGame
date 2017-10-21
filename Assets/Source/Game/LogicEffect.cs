using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEffect : PMonoSingleton<LogicEffect> {

	protected GameObject m_selfObj;


	void Start()
	{
		EventNotificationCenter.GetInstance ().AddListener<int,GameObject,float> (BroadEvent.EFFECT_EVENT, OnDoEffect);
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance ().RemoveListener<int,GameObject,float> (BroadEvent.EFFECT_EVENT, OnDoEffect);
	}

	public void OnDoEffect(int effectId,GameObject selfObj,float buffTime)
	{
		m_selfObj = selfObj;
		switch (effectId) 
		{
		case Effect.Drink_Beer:
			OnDrinkBeer (buffTime);
			break;
		case Effect.Belive_Effect:
			OnBelive ();
			break;
		}
	}

	public void OnBelive()
	{
		Debug.Log ("--on belive--");
		int layer = m_selfObj.layer;
	}

	public void OnDrinkBeer(float buffTime)
	{
		Debug.Log ("--on drink beer--");
		PlayerController controller = m_selfObj.GetComponent<PlayerController>();
		controller.ChangeSpeed (-controller.speed);
		StartCoroutine (WaitToDoNext(buffTime,controller));
	}

	IEnumerator WaitToDoNext(float time,PlayerController controller)
	{
		yield return new WaitForSeconds (time);
		controller.ChangeSpeed (-controller.speed);
	}
}
