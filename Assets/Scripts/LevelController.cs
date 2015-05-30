using UnityEngine;
using System;


public class LevelController : MonoBehaviour {

	public GameObject itemPref;
	public GameObject levelPanel;
	public int levels = 4;
	const int maxLevel=4;

	public void ChangeToScene(string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}
	// Use this for initialization
	void Start () {

		int curentLevel,maxLevel;
		float x = 80, space=80;
		for (int i=1; i<= levels; i++) 
		{
			GameObject item=(GameObject)Instantiate(itemPref);

			item.transform.SetParent(levelPanel.transform);
			item.transform.localScale=Vector3.one;
			item.transform.localPosition=new Vector3(x,0,0);
			RectTransform rt = (RectTransform)item.transform;
			x=x + rt.rect.width + space;
			ItemView s = item.GetComponent<ItemView>();

			curentLevel = extactLevelNr(PlayerPrefs.GetString("savedLevel"));
			maxLevel = extactLevelNr(PlayerPrefs.GetString("maxLevel"));

			if(i>maxLevel)
				s.but.interactable=false;
			else if(maxLevel<curentLevel)
				PlayerPrefs.SetString("savedLevel",PlayerPrefs.GetString("maxLevel"));

			s.textButton.text="LEVEL "+ i;
			s.Nume="Level "+i;
			UnityEngine.Events.UnityAction action1 = () => { this.ChangeToScene(s.Nume);PlayerPrefs.SetString("savedLevel",s.Nume);Debug.Log(s.Nume+"_");};
			s.but.onClick.AddListener(action1);
		}
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
