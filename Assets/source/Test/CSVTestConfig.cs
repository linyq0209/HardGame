using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTestConfig {

	protected int itemID = 1001;
	protected string itemName = "";
	protected int itemSort = 0;
	protected int itemEffect = 0;
	protected float itemTime = 0;

	public CSVTestConfig(CsvRecord record)
	{
		itemID = record.GetInt(0, itemID);
		itemName = record.GetString(1, itemName);
		itemSort = record.GetInt(2, itemSort);
		itemEffect = record.GetInt(3, itemEffect);
		itemTime = record.GetFloat(4, itemTime);
	}

	public void DebugInfo()
	{
		Debug.Log ("-id-" + itemID + "-name-" + itemName + "-sort-" + itemSort + "effect-" + itemEffect + "-time-" + itemTime);
	}
}
