using UnityEngine;
using System;

public class InLevelFunctions : MonoBehaviour {
	
	bool paused = false;
	public GameObject UI;
	public GameObject LevelGUI;

	void Start()
	{
		paused = false;
		UI.SetActive (false);
		LevelGUI.SetActive (true);

	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) == true)
		if (paused == false)
			Pause (true);
		else
			Pause(false);
	}

	public void ChangeToMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("menu");
	}
	public void Restart()
	{
		Application.LoadLevel (PlayerPrefs.GetString ("savedLevel"));
		Time.timeScale = 1;
	}

	public void Pause(bool p)
	{
		if(p==true)Time.timeScale = 0;
		else Time.timeScale = 1;
		UI.SetActive (p);
		LevelGUI.SetActive (!p);
		paused = !paused;
	}

	public void YouWin(GameObject c)
	{
		Time.timeScale = 0;
		c.SetActive (true);
	}
	public void YouLose(GameObject c)
	{
		Time.timeScale = 0;
		c.SetActive (true);
	}
}