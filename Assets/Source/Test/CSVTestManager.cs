using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTestManager :  PSingleton<CSVTestManager>{
	public const string CONFIG_PATH = "ItemsConfig";
	public List<CSVTestConfig> listConfig = new List<CSVTestConfig> ();

	public CSVTestManager()
	{
		Init();
	}

	protected void Init()
	{
		Debug.Log ("-------------");
		InitConfig();
		DebugInfo ();
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
				CSVTestConfig config = new CSVTestConfig(record);
				listConfig.Add (config);
			}
		}
	}

	public List<CSVTestConfig> GetConfigs()
	{
		return listConfig;
	}

	protected void DebugInfo()
	{
		foreach (CSVTestConfig config in listConfig) 
		{
			config.DebugInfo ();
		}
	}
}
