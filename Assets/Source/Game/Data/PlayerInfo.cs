using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInfo : PSingleton<PlayerInfo> {

	public const string FILE_NAME = "Session/playerInfo";
	[Serializable]
	protected class PlayerData
	{
		public int highestScore = 0;
		public bool isMusicOpen = true;
		public bool isEffectOpen = true;
	}

	protected PlayerData mData = null;

	protected override void Init()
	{
		InitPlayerData();
		App.GetInstance().onApplicationQuit += Save;
	}
	
	public void Save()
	{
		string content = JsonUtility.ToJson(mData);
		FileUtility.SaveData(content, FILE_NAME);
	}

	protected void InitPlayerData()
	{
		string content = FileUtility.LoadWriteableFile(FILE_NAME);
		if(string.IsNullOrEmpty(content))
		{
			mData = new PlayerData();
		}else
		{
			mData = JsonUtility.FromJson<PlayerData>(content);
		}
	}

	public int GetPlayerHighestScore()
	{
		return mData.highestScore;
	}

	public bool GetIsMusicOpen()
	{
		return mData.isMusicOpen;
	}

	public bool GetIsEffectOpen()
	{
		return mData.isEffectOpen;
	}
}
