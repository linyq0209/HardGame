using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEffect : PMonoSingleton<LogicEffect> {

	public PlayerController maleController;
	public PlayerController famaleController;
	private int colliderId;

	void Start()
	{
		EventNotificationCenter.GetInstance ().AddListener<DropHeadConfig,int> (BroadEvent.EFFECT_EVENT, OnDoEffect);
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance ().RemoveListener<DropHeadConfig,int> (BroadEvent.EFFECT_EVENT, OnDoEffect);
	}

	public void OnDoEffect(DropHeadConfig config,int id)
	{
		colliderId = id;
		Debug.Log(Effect.Drink_Beer+"---------------"+config.GetEffectId());
		switch (config.GetEffectId()) 
		{
		case Effect.Drink_Beer:
			OnDrinkBeer (config.GetTime());
			break;
		case Effect.Belive_Effect:
			OnBelive ();
			break;
		}
	}

	public void OnBelive()
	{
		Debug.Log ("--on belive--");
		// int layer = m_selfObj.layer;
	}

	public void OnDrinkBeer(float buffTime)
	{
		Debug.Log ("--on drink beer--");
		PlayerController controller = colliderId == GreenCap.Give_Male ? maleController : famaleController;
		controller.ChangeSpeed (-controller.speed);
		StartCoroutine (WaitToDoNext(buffTime,controller));
	}

	IEnumerator WaitToDoNext(float time,PlayerController controller)
	{
		yield return new WaitForSeconds (time);
		controller.ChangeSpeed (-controller.speed);
	}
}
