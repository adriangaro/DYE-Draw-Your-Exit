using UnityEngine;
using System.Collections;

public class Environment2ToRest : MonoBehaviour {
	public Player1 player;
	public float x;
	public float y;
	// Use this for initialization
	void Start () {
		GameObject.Instantiate (player, new Vector2 (x, y), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
