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
			if(!hitTop)
			{
				if (Input.GetKey (KeyCode.S)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0f);
				}
			} 

			if (!hitBottom) {
				if (Input.GetKey (KeyCode.W)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime, 0f);
				}
			}
		}

		if (type == 2) {
			if (!hitTop) {
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - speed * Time.deltaTime, 0f);
				}
			}

			if (!hitBottom) {
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime, 0f);
				}
			}
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "TopWall"){
			hitTop = true;
		}

		if (col.tag == "BottomWall") {
			hitBottom = true;
		}
	}


	void OnTriigerExit2D(Collider2D col)
	{
		if(col.tag == "TopWall"){
			hitTop = false;
		}

		if (col.tag == "BottomWall") {
			hitBottom = false;
		}
	}
}
