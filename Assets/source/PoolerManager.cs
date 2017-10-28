using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerManager : MonoBehaviour {
	public GameObject pool;

	void Start () {
		Pooler.SetPooler(gameObject);
		//新建对象池
		Pooler.CreatePool("itemPool",pool);
	}
	
	void Update () {
		
	}

	public void PutPoolObj(string name, GameObject go)
	{
		Pooler.PutPoolObj(name,go);
	}

	public GameObject GetPoolObj(string name)
	{
		return Pooler.GetPoolObj(name);
	}

	public void ClearPool(string name)
	{
		Pooler.ClearPool(name);
	}
}
