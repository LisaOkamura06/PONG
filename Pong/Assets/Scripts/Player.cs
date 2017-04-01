using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	private int type = 0;
	[SerializeField]
	private float speed = 0.0f;

	private bool hitTop;
	private bool hitBottom;
	// Use this for initialization
	void Start () {
		hitTop = hitBottom = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (type == 1) {
			if(!this.hitBottom)
			{
				if (Input.GetKey (KeyCode.S)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0f);
				}
			} 

			if (!this.hitTop) {
				if (Input.GetKey (KeyCode.W)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime, 0f);
				}
			}
		}

		if (type == 2) {
			if (!this.hitBottom) {
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0f);
				}
			}

			if (!this.hitTop) {
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime, 0f);
				}
			}
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "TopWall"){
			this.hitTop = true;
			return;
		}

		if (col.gameObject.tag == "BottomWall") {
			this.hitBottom = true;
			return;
		}
	}


	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "TopWall"){
			this.hitTop = false;
			return;
		}

		if (col.gameObject.tag == "BottomWall") {
			this.hitBottom = false;
			return;
		}
	}
}
