using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoll : MonoBehaviour {

	private const string GUI_NAME = "boll";
	Transform[] pArray = new Transform[9];
	public Transform itemPool;

	void Awake() {
		InitPosition();
	}
	void Start () {
		//@TDSH
		// foreach (Transform p in pArray)
		// {
		// 	Debug.Log(transform.name+"===="+p.name+"===="+p.localPosition);
		// }
		// ToCreateBoll();
	}
	
	void Update () {
		
	}

	//初始化9个位置，用pArray来统一管理9个位置
	protected void InitPosition()
	{
		string str = "";
		for(int i = 1;i < 10;i++)
		{
			str = "p";
			str += i.ToString();
			InitChildrenPosition(str,i);
		}
	}

	//拿到每一个位置
	protected void InitChildrenPosition(string name,int i)
	{
		foreach (Transform p in GetComponentsInChildren<Transform>())
  		{
			if(p.name == name){
				pArray[i-1] = p;
  			}
  		}
	}

	//  外部调用，创建新的item
	public void ToCreateBoll()
	{
		ReFreshPanel();
		int[] numberArray = new int[]{0,1,2};
		int createCount = 0;
		for(int i = 1; i < 4; i++)
		{
			createCount = RandomChildCount();
			int resNum = RandomChildOrdinalNumber();
			if(createCount ==1)
			{
				InitNewBollPosition(resNum,i);
			}
			else{
				foreach(int j in numberArray)
				{
					if(numberArray[j] != resNum) 
					{
						InitNewBollPosition(numberArray[j],i); 
					}
				}
			}
		}
	}

	//控制生成item
	protected void InitNewBollPosition(int p,int line)
	{
		Debug.Log("====" + p);
		if(line == 2)
		{
			p += 3;
		}
		if(line == 3)
		{
			p += 6;
		}
		GameObject obj = GameObject.Instantiate(ResourceManager.GetInstance().GetPrefab(GUI_NAME));
		obj.transform.parent = pArray[p];
		obj.transform.localPosition = new Vector3(0,0,0);
		obj.layer = obj.transform.parent.gameObject.layer;
		
	}
	//随机生成的物体是1个还是2个
	protected int RandomChildCount()
	{
		int res = Random.Range(1,3);
		return res;
	}
	//如果随机生成的物体是1个，取以下生成的序号作为生成序号 || 如果随机生成的是2个，排除掉以下生成的序号，生成另外两个
	protected int RandomChildOrdinalNumber()
	{
		int res = Random.Range(0,3);
		return res;
	}
	//在bg移动到顶层的时候，把9个位置上的item移动到对象池里
	protected void ReFreshPanel()
	{
		foreach(Transform i in pArray)
		{
			foreach (Transform child in i)  
        	{  
        		if(child != null)
           		child.transform.gameObject.active = false; 
        	}  
		}
	}
}
