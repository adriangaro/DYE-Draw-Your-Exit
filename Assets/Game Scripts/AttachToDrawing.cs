using UnityEngine;
using System.Collections;

public class AttachToDrawing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print (this.gameObject.transform.parent.gameObject.tag);
		if (coll.gameObject.tag == "Drawed" && this.gameObject.transform.parent.gameObject.tag == "Draw") {
			foreach(Transform child in this.gameObject.transform.parent){
				child.parent = coll.gameObject.transform;
			}
			this.gameObject.transform.parent = coll.gameObject.transform;
		}		
	}

}
