using UnityEngine;
using System;

public class NextLevel : MonoBehaviour {

	public int maxLevel,max=4;
	

	public void ChangeToScene()
	{
		string sceneToChangeTo = PlayerPrefs.GetString ("savedLevel");
		string [] split = sceneToChangeTo.Split (new Char [] {' '});
		
		maxLevel = extactLevelNr( PlayerPrefs.GetString ("maxLevel"));
		int level=0;
		bool isSuccess = int.TryParse (split[1] ,out level);
		if (isSuccess)
		{
			level = level + 1;
			split[1]=level.ToString();
		}
		sceneToChangeTo = String.Join (" ", split);
		PlayerPrefs.SetString ("savedLevel", sceneToChangeTo);
		
		
		Debug.Log(maxLevel+">.."+(level-1));
		if(maxLevel >= max && level>=max)
			ChangeToMenu ();
		else if (level-1 < maxLevel) 
			Application.LoadLevel (sceneToChangeTo);
		else if (level-1 >= maxLevel)
		{
			PlayerPrefs.SetString ("maxLevel", sceneToChangeTo);
			Application.LoadLevel (sceneToChangeTo);
		}
	}
	public void ChangeToMenu()
	{
		Application.LoadLevel ("menu");
	}

	public int extactLevelNr(string s)
	{
		string [] split = s.Split (new Char [] {' '});
		int level=0;
		bool isSuccess = int.TryParse (split[1] ,out level);
		if (isSuccess)
			return level;
		else
			return 0;
	}

	public void Restart()
	{
		Application.LoadLevel (PlayerPrefs.GetString ("savedLevel"));
		Time.timeScale = 1;
	}

}
