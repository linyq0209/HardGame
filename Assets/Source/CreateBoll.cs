using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoll : MonoBehaviour {
	public GameObject pooler;
	private PoolerManager poolerManager;
	private const string GUI_NAME = "boll";
	Transform[] pArray = new Transform[9];
	
	void Awake() {
		InitPosition();
	}

	void Start () {
		//@TDSH
		// foreach (Transform p in pArray)
		// {
		// 	Debug.Log(transform.name+"===="+p.name+"===="+p.localPosition);
		// }
		poolerManager = pooler.GetComponent<PoolerManager>();
		EventNotificationCenter.GetInstance().AddListener(BroadEvent.GAMERESET_EVENT,Reset);
		//设置对象池存放对象
		
	}
	
	void Update () {
		
	}

	void OnDestroy()
	{
		EventNotificationCenter.GetInstance().RemoveListener(BroadEvent.GAMERESET_EVENT,Reset);
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

	//外部调用，创建新的item
	public void ToCreateBoll()
	{
		ReFreshPanel();
		int times = CodeGameInfo.GetInstance().GetCreateTimes();
		//记录bg创建item的次数
		if(times < 20)
		{
			CodeGameInfo.GetInstance().SetCreateTimes(1);
		} 
		int[] numberArray = new int[]{0,1,2};
		int createCount = 0;
		for(int i = 1; i < 4; i++)
		{
			//计算创建item的个数
			createCount = RandomChildCount();
			int resNum = RandomChildOrdinalNumber();
			//创建1个
			if(createCount ==1)
			{
				InitNewBollPosition(resNum,i,times);
			}
			//创建2个
			else
			{
				foreach(int j in numberArray)
				{
					if(numberArray[j] != resNum) 
					{
						InitNewBollPosition(numberArray[j],i,times); 
					}
				}
			}
		}
	}

	//控制生成item
	protected void InitNewBollPosition(int p,int line,int createTimes)
	{
		if(line == 2)
		{
			p += 3;
		}
		if(line == 3)
		{
			p += 6;
		}
		if(createTimes != 20)
		{
			GameObject obj = GameObject.Instantiate(ResourceManager.GetInstance().GetPrefab(GUI_NAME));
			obj.transform.parent = pArray[p];
			float positionY = Random.Range(-0.4f,0.4f);
			obj.transform.localPosition = new Vector3(0,positionY,0);
			obj.layer = obj.transform.parent.gameObject.layer;
		}	
		//如果创建次数等6次，不再实例化item，而是复用item
		else
		{
			Reuse(p);
		}
		
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
        		{
					poolerManager.PutPoolObj("itemPool",child.transform.gameObject);	
        		}
        		Debug.Log(child.transform.parent.gameObject.ToString());
        	}  
		}
	}

	//复用item,不再重新实例化生成
	protected void Reuse(int p)
	{
		GameObject pool = poolerManager.GetPoolObj("itemPool");
		
		foreach (Transform child in pool.transform)  
        	{  
        		if(child.name == "boll(Clone)") 
        		{
        			child.parent = pArray[p];
					float positionY = Random.Range(-0.4f,0.4f);
					child.localPosition = new Vector3(0,positionY,0);
					child.gameObject.layer = child.parent.gameObject.layer;
					child.gameObject.SetActive(true);
					return;
        		}
        	}  
	}

	//游戏重置
	protected void Reset()
	{
		ReFreshPanel();
		poolerManager.ClearPool("itemPool");
		CodeGameInfo.GetInstance().ResetCreateTimes();
	}
}
