using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {
	public GameObject MainMenu; 
	public GameObject Settings; 
	public GameObject Starts;
	public AudioSource Music;

	void Start()
	{
		Settings.SetActive (false);
		MainMenu.SetActive (true);
		Starts.SetActive (false);
		Music.Play ();
		//	if(PlayerPrefs.SetInt("level "+i,0)=0);
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

	//this function should be added to the sound gameobject
	public void OnOff(bool mute)
	{
		Music.mute =Music.mute ^ mute;
	}
}
