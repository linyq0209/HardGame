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
		if(time % 50 == 0)
		{
			string value = (time/50).ToString();
			score.text = value + "hours";
		}
	}

}
