using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	private float x, y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void SetPosition(float x,float y) {
		transform.position = new Vector2(x, y);
	}
	public void destroyPlayer(){
		Destroy (gameObject);
	}
	public void Spawn(){
		x = -6.7f;
		y = 6.3f;
		transform.position = new Vector2 (x, y);
	}
}
