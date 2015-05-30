using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TileTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 SS = this.gameObject.GetComponent<MeshRenderer>().materials[0].mainTextureScale;
		SS.x = transform.localScale.x / 20;
		SS.y = transform.localScale.y / 20;
		this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = SS;
	}
}
