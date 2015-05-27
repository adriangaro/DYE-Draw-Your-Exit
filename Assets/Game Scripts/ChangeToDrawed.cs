using UnityEngine;
using System.Collections;

public class ChangeToDrawed : MonoBehaviour {

	private int time = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		if (time >= 5) {
			this.gameObject.tag = "Drawed";
		} else {
			time++;
		}
	}
}
