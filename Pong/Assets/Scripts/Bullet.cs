using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20.0f;
	public int type = 1;
	// Use this for initialization
	void Start () {
		Rigidbody2D rig = this.GetComponent<Rigidbody2D> ();
		this.transform.localPosition = new Vector3 (0, 0, 0);

		if (type == 2) {
			rig.AddForce ((transform.right + transform.up) * speed);
		}else {
			rig.AddForce ((-transform.right + transform.up) * speed);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
