using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGameInfo : PSingleton<CodeGameInfo> {

	private int bgCreateTimes = 0;

	public void SetCreateTimes(int vo)
	{
		bgCreateTimes += vo;
	}

	public int GetCreateTimes()
	{
		return bgCreateTimes;
	}

	public void ResetCreateTimes()
	{
		bgCreateTimes = 0;
	}
}
