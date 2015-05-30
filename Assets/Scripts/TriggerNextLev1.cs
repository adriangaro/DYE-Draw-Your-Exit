using UnityEngine;
using System.Collections;

public class TriggerNextLev1 : MonoBehaviour {
	public string scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D player)
    {
		if (player.tag == "Player")
		{
			Application.LoadLevel(scene);

		}
    }
}
