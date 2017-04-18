using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMain : MonoBehaviour {
	[SerializeField]
	private InputField inputPlayer1;
	[SerializeField]
	private InputField inputPlayer2;
	[SerializeField]
	private GameObject messageTxt;

	void Start()
	{
		PlayerPrefs.DeleteAll ();
	}

	public void ToGameBtn()
	{
		if ( inputPlayer1.text != "" && inputPlayer2.text != "" ) {
			PlayerPrefs.Save ();
			messageTxt.SetActive (false);
			SceneManager.LoadScene ("Game");
		} else {
			messageTxt.SetActive (true);
		}
	}


	public void InputPlayer1()
	{
		PlayerPrefs.SetString(Config.PLAYER_NAME_1, inputPlayer1.text);
	}

	public void InputPlayer2()
	{
		PlayerPrefs.SetString(Config.PLAYER_NAME_2, inputPlayer2.text);
	}

}
