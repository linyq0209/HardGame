using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollFactory : MonoBehaviour {
	public GameObject[] posArray = new GameObject[3];
	public GameObject boll;
	public float repeatTime = 1;

	void Start()
	{
		InvokeRepeating("CreateBoll", 0,repeatTime);
	}

	protected void CreateBoll()
	{
		GameObject obj = Instantiate(boll);
		obj.SetActive(true);
		obj.transform.parent = transform;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
	}
}
