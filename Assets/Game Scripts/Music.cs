using UnityEngine;
using System.Collections;

public class Music: MonoBehaviour {

	public AudioSource music;
	// Use this for initialization

	public void OnOff(bool mute)
	{
		music.mute =music.mute ^ mute;
	}
}
