using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHeadManager : PSingleton<DropHeadManager> {

	public const string CONFIG_PATH = "ItemsConfig";
	public Dictionary<int,DropHeadConfig> dicConifg = new Dictionary<int,DropHeadConfig> ();
	protected int allWeight = 0;

	public DropHeadManager()
	{
		Init();
		DebugConfig();
	}

	protected void Init()
	{
		InitConfig();
	}

	protected void InitConfig()
	{
		CsvFile file = FileUtility.LoadCsvFile(CONFIG_PATH);
		if(file != null)
		{
			int head = file.HeaderCount;
			int row = file.RecordCount;
			for (int i = 0; i < row; i++)
			{
				CsvRecord record = file[i];
				DropHeadConfig config = new DropHeadConfig(record);
				dicConifg[config.GetID()] = config;
				allWeight += config.GetWeight();
			}
		}
	}

	public DropHeadConfig GetRandomConfig()
	{
		if(allWeight <= 0)
		{
			Debug.LogError("权重等于0，无法随机，请先确认表格读取无误");
		}
		int randomNum = Random.Range(1,allWeight+1);
		Debug.Log("----random:------------"+randomNum);
		int weight = 0;
		foreach(DropHeadConfig config in dicConifg.Values)
		{
			weight += config.GetWeight();
			if(weight -config.GetWeight() < randomNum && randomNum <= weight)
			{
				return config;
			}
		}
		return null;
	}

	void DebugConfig()
	{
		foreach(DropHeadConfig config in dicConifg.Values)
		{
			// Debug.Log("----id:------------"+config.GetID());
		}
	}
}
