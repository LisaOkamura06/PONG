using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	[SerializeField]
	private Text score = null;
	[SerializeField]
	public int type;

	public bool isEnd{ get; private set; }
	public bool isBulletSet{ get; set; }

	public const int SCORE_MAX = 11;
	private int nScore;
	// Use this for initialization
	void Start () {
		nScore = 0;
		isEnd = false;
		score.text = nScore.ToString ();
		isBulletSet = false;
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void AddScore()
	{
		nScore++;
		if (nScore >= SCORE_MAX) {
			isEnd = true;
		} else {
			isBulletSet = true;
		}
		score.text = nScore.ToString ();

	}
}
