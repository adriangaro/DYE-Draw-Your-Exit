using UnityEngine;
using System.Collections;

public class InLevelFunctions : MonoBehaviour {
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("menu");
	}
	
	
	public void ChangeToScene(string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}
}
