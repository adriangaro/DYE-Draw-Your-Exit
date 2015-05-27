using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DrawLine : MonoBehaviour 
{
	private bool isMousePressed;
	private List<Vector3> pointsList;
	private Vector3 mousePos;
	private Vector3 mouse;
	public GameObject obj;
	public GameObject type;
	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
		
		
	};
	//	-----------------------------------	


	void Awake()
	{
		
		isMousePressed = false;
		pointsList = new List<Vector3>();
	}
	//	-----------------------------------	

	void Update () 
	{
		// If mouse button down, remove old line and set its color to green
		if(Input.GetMouseButtonDown(0))
		{
			isMousePressed = true;
			pointsList.Clear();
			Time.timeScale = 0;
		}
		else if(Input.GetMouseButtonUp(0) && isMousePressed)
		{
			isMousePressed = false;
			Time.timeScale = 1;
			GameObject clone = Instantiate(type);
			clone.GetComponent<DrawLine>().enabled = true;
			clone.GetComponent<DrawLine>().type = type;
			this.GetComponent<ChangeToDrawed>().enabled = true;
			Destroy(this.gameObject.GetComponent<DrawLine>());
		}
		// Drawing line when mouse is moving(presses)
		if (isMousePressed) {
			mouse = Input.mousePosition;
			mouse.z = 20;
			mousePos = Camera.main.ScreenToWorldPoint (mouse);
			mousePos.z = 0;
			if (pointsList.Count == 0) {
				pointsList.Add (mousePos);
			}
			
			if (Vector3.Distance (mousePos, pointsList [pointsList.Count - 1]) >= 0.1) {
				pointsList.Add (mousePos);
				if (pointsList.Count >= 2) {
					Vector3 position = pointsList [pointsList.Count - 2];
					int dir = 1;
					
					dir = Math.Sign (pointsList [pointsList.Count - 2].x - pointsList [pointsList.Count - 1].x);
					
					float angle = (float)(Mathf.Atan ((pointsList [pointsList.Count - 2].y - pointsList [pointsList.Count - 1].y) / (pointsList [pointsList.Count - 2].x - pointsList [pointsList.Count - 1].x)) * 180.0 / Mathf.PI);
					if (float.IsNaN (angle)) {
						angle = 0;
					}
					Quaternion rotation = Quaternion.identity;
					rotation.eulerAngles = new Vector3 (0, 0, angle);
					GameObject clone = (GameObject)Instantiate (obj);
					clone.transform.parent = this.transform;
					clone.transform.position = position;
					clone.transform.rotation = rotation;
					clone.transform.localScale = new Vector3 (Vector3.Distance (pointsList [pointsList.Count - 2], pointsList [pointsList.Count - 1]) / obj.GetComponent<BoxCollider2D> ().size.x / (float)0.8, 0.2f, 1);
				}
			}
		}
	}
}