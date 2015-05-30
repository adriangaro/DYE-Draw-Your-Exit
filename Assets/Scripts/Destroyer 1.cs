using UnityEngine;
using System.Collections;

public class Destroyer2 : MonoBehaviour {
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		float ratio = 0.15f / 0.003f;
		float dx = coll.gameObject.transform.localScale.x / ratio;
		float dy = coll.gameObject.transform.localScale.y / ratio;
		if (dx < 0.003f)
			dx = 0.003f;
		if (dy < 0.003f)
			dy = 0.003f;
		x = coll.gameObject.transform.localScale.x - dx;
		y = coll.gameObject.transform.localScale.y - dy;
		coll.gameObject.transform.localScale = new Vector2(x,y);
		if (x <= 0 || y <= 0)
			Destroy (coll.gameObject);
	}
	void OnCollisionStay2D(Collision2D coll) {
		float ratio = 0.15f / 0.0005f;
		float dx = coll.gameObject.transform.localScale.x / ratio;
		float dy = coll.gameObject.transform.localScale.y / ratio;
		if (dx < 0.0005f)
			dx = 0.0005f;
		if (dy < 0.0005f)
			dy = 0.0005f;
		x = coll.gameObject.transform.localScale.x - dx;
		y = coll.gameObject.transform.localScale.y - dy;
		coll.gameObject.transform.localScale = new Vector2(x,y);
		if (x <= 0 || y <= 0)
			Destroy (coll.gameObject);
	}
}
