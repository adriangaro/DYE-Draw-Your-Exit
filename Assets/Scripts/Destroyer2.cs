using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider OtherObject){
		Debug.Log("We hit "+ OtherObject.name);
		if(OtherObject.tag=="Player"){
			//Destroy(OtherObject.gameObject);
			Debug.Log("We hit "+ OtherObject.tag);
		}
	}
}
