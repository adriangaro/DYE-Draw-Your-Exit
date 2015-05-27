using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject itemPref;
	public GameObject levelPanel;

	public void ChangeToScene(string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
		Debug.Log (sceneToChangeTo);
	}
	// Use this for initialization
	void Start () {
		int levels = 3;
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
			s.textButton.text="LEVEL "+ i;
			s.Nume="level"+i;
			UnityEngine.Events.UnityAction action1 = () => { this.ChangeToScene(s.Nume); };
			s.but.onClick.AddListener(action1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
