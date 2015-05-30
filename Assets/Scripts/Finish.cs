using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	public GameObject c;
	
	public void YouWin()
	{
		Time.timeScale = 0;
		c.SetActive (true);
	}
	public void YouLose()
	{
		Time.timeScale = 0;
		c.SetActive (true);
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		YouWin ();
	}

}
