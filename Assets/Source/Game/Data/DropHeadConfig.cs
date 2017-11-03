using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHeadConfig  {

	protected int itemID = 1001;
	protected string itemName = "";
	protected int itemSort = 0;
	protected int itemEffect = 0;
	protected float itemTime = 0;
	protected int weight = 0;

	public DropHeadConfig(CsvRecord record)
	{
		itemID = record.GetInt(0, itemID);
		itemName = record.GetString(1, itemName);
		itemSort = record.GetInt(2, itemSort);
		itemEffect = record.GetInt(3, itemEffect);
		itemTime = record.GetFloat(4, itemTime);
		weight = record.GetInt(5, weight);
	}

	public int GetID()
	{
		return itemID;
	}

	public int GetWeight()
	{
		return weight;
	}

	public string GetIconName()
	{
		return itemName;
	}
}
