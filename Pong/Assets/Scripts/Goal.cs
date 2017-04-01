using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	[SerializeField]
	private Score score = null;
 	
	public bool isBulletSet{ get; set; }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Bullet")
		{
			score.AddScore ();
			// 弾削除
			GameObject.Destroy (col.gameObject);
		}
	}
}
