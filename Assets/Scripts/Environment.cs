using UnityEngine;
using System.Collections;

public class Environment : MonoBehaviour {
    public Player1 player;
    public float x;
    public float y;
	// Use this for initialization
	void Start () {
	
	}

	public void Plays()
	{
		GameObject.Instantiate (player, new Vector2 (x, y), Quaternion.identity);
	}
}
