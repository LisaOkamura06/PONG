using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour {

	[SerializeField]
	private Score playerScore = null;
	[SerializeField]
	private Score playerScore1 = null;

	[SerializeField]
	private GameObject stopObj = null;
	[SerializeField]
	private Text stopTxt = null;
	[SerializeField]
	private GameObject bulletObj = null;

	[SerializeField]
	private Button topBtn = null;
	[SerializeField]
	private Button reStartBtn = null;
	[SerializeField]
	private GameObject bulletParent = null;

	const string RESULT = "PLAYER{0}\nWINNER!!";
	const string STOP = "STOP";

	private Vector3 force;
	private float count;
	private bool isStart;
	private bool firstBullet;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		stopObj.SetActive (false);
		isStart = false;
		count = 0;
		this.firstBullet = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isStart) {
			// ゲームスタート表示
			GameStart ();
		} else {
			if (this.firstBullet) {
				firstBullet = false;
				GameObject b = Instantiate (bulletObj);
				b.transform.SetParent (bulletParent.transform,false);
				b.GetComponent<Bullet> ().type = 1;
			}
			// 弾生成
			CreateBullet (playerScore);
			CreateBullet (playerScore1);


			// Game終了
			this.GameEnd ();
		}
	}

	private void CreateBullet(Score score)
	{
		if (score.isBulletSet) {
			GameObject b = Instantiate (bulletObj);
			b.transform.SetParent (bulletParent.transform, false);
			if(score.type == 1)
				b.GetComponent<Bullet> ().type = 2;
			if(score.type == 2)
				b.GetComponent<Bullet> ().type = 1;

			score.isBulletSet = false;
		}
	}

	private void GameEnd()
	{
		if (playerScore.isEnd) {
			stopObj.SetActive (true);
			stopTxt.text = string.Format (RESULT, playerScore1.type.ToString ());
			Time.timeScale = 0;
			return;
		}
		if (playerScore1.isEnd) {
			stopObj.SetActive (true);
			stopTxt.text = string.Format (RESULT, playerScore.type.ToString ());
			Time.timeScale = 0;
			return;
		}
	}


	private void GameStart()
	{
		stopObj.SetActive (true);
		stopTxt.text = "GAME START!!";
		count = count + 1 * Time.deltaTime;
		if (count >= 1) {
			stopObj.SetActive (false);
			isStart = true;
		}
	}



	// 一時停止ボタン
	public void StopGame()
	{
		if (Time.timeScale != 0) {
			stopObj.SetActive (true);
			stopTxt.text = STOP;
			topBtn.enabled = false;
			reStartBtn.enabled = false;
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1.0f;
			topBtn.enabled = true;
			reStartBtn.enabled = true;
			stopObj.SetActive (false);
		}
	}


	public void Top()
	{
		//Topへ遷移
		SceneManager.LoadScene("Title");
	}

	public void ReStart()
	{
		//再スタート
		SceneManager.LoadScene("Game");
	}
}
