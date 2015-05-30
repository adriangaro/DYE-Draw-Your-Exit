using UnityEngine;
using System.Collections;

public class AttachToSelf : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.transform.parent.tag == "Draw" &&
		    this.gameObject.tag == "Point" && coll.gameObject.transform.parent.parent == null) {
			coll.gameObject.transform.parent.transform.parent = this.gameObject.transform;
			Destroy (coll.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D> ());
		}
	}
}
