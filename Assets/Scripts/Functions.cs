using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {
	public GameObject MainMenu; 
	public GameObject Settings; 
	public GameObject Starts;
	public AudioSource Music;
	void Awake()
	{
		//PlayerPrefs.SetString("maxLevel","level 1");
	//	PlayerPrefs.SetString("savedLevel","level 1");
	}

	void Start()
	{
		Settings.SetActive (false);
		MainMenu.SetActive (true);
		Starts.SetActive (false);
		Music.Play ();

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		if (MainMenu.activeSelf == true)
			Application.Quit ();
		else 
		{
			Settings.SetActive (false);
			MainMenu.SetActive (true);
			Starts.SetActive (false);
		}
	}


	public void ChangeToScene(string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

	public void ChangeToSettings()
	{
		Settings.SetActive (true);
		MainMenu.SetActive (false);
		Starts.SetActive (false);
		//	settingsPanel.SetActive (true);
	}
	
	public void ChangeToMainMenu()
	{
		Settings.SetActive (false);
		MainMenu.SetActive (true);
		Starts.SetActive (false);
	}
	public void ChangeToStarts()
	{
		Settings.SetActive (false);
		MainMenu.SetActive (false);
		Starts.SetActive (true);
	}
	public void Exit()
	{
		Application.Quit();
	}
	public void OnOff(bool mute)
	{
		Music.mute =Music.mute ^ mute;
	}
	public void Activate(GameObject c)
	{
		c.SetActive (!c.activeSelf);

	}
}
