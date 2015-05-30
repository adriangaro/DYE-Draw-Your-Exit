using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetUpJoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<HingeJoint2D> ().connectedAnchor = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
