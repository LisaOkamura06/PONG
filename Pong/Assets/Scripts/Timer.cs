using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {
	[SerializeField] 
	private Text timer = null; 

	private float nTime = 0;
	// Use this for initialization
	void Start () {
		timer.text = nTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		nTime = nTime+ 1 * Time.deltaTime;
		timer.text = nTime.ToString("0");
	}
}
