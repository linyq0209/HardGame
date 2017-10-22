using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelController : MonoBehaviour {

	public Text score;
	private int time = 0;
	void Start () {
		
	}
	
	void Update () {
		
	}

	void FixedUpdate()
	{
		time += 1;
		if(time % 5 == 0)
		{
			string value = (time/5).ToString();
			score.text = value + "hours";
		}
	}
}
