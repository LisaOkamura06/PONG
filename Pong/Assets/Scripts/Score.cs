using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	[SerializeField]
	private Text score = null;
	[SerializeField]
	public int type;
	[SerializeField]
	private Text playerTxt;


	public bool isEnd{ get; private set; }
	public bool isBulletSet{ get; set; }

	public const int SCORE_MAX = 11;
	private int nScore;
	// Use this for initialization
	void Start () {

		if (type == 1) {
			playerTxt.text = PlayerPrefs.GetString (Config.PLAYER_NAME_1);
		} else {
			playerTxt.text = PlayerPrefs.GetString (Config.PLAYER_NAME_2);
		}
		nScore = 0;
		isEnd = false;
		score.text = nScore.ToString ();
		isBulletSet = false;
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
