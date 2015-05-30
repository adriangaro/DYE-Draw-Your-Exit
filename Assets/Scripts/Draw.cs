using UnityEngine;
using System.Collections;

public class Draw : MonoBehaviour {
	private float minX;
	private float maxX;
	private float minY;
	private float maxY;
	private bool first = true;
	private Vector3 mouse;
	private Vector3 lastMouse;
	private Texture2D objectTexture;
	private Texture2D auxiliarTexture;
	private bool isMousePressed;
	private Texture2D utilityTexture;
	public Texture2D texture;
	public int radius = 10;


	void Awake()
	{
		
		isMousePressed = false;
	}

	void Start () {
		objectTexture = new Texture2D(1, 1, TextureFormat.ARGB32, true);
		auxiliarTexture = new Texture2D(1, 1, TextureFormat.ARGB32, true);
		utilityTexture = new Texture2D(texture.width * 3, texture.height * 3);
		Color[] texturePixels = texture.GetPixels (0, 0, texture.width, texture.height);
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				utilityTexture.SetPixels (texture.width * i, texture.height * j, texture.width, texture.height, texturePixels);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		DrawObject ();
	}

	void DrawObject () {
		if(Input.GetMouseButtonDown(0))
		{
			isMousePressed = true;
			Time.timeScale = 0;
		}
		else if(Input.GetMouseButtonUp(0) && isMousePressed)
		{
			isMousePressed = false;
			Time.timeScale = 1;
		}
		if (isMousePressed) {
			if(first){
				mouse = Input.mousePosition;
				mouse.z = 10;
				mouse = Camera.main.ScreenToWorldPoint (mouse);
				mouse.z = 0;
				lastMouse = mouse;
				minX = mouse.x - radius * 0.01f;
				maxX = mouse.x + radius * 0.01f;
				minY = mouse.y - radius * 0.01f; 
				maxY = mouse.y + radius * 0.01f;
				first = false;
			}
			else{
				mouse = Input.mousePosition;
				mouse.z = 10;
				mouse = Camera.main.ScreenToWorldPoint (mouse);
				mouse.z = 0;
				float ofX = 0;
				float ofY = 0;
				if(minX > mouse.x){
					ofX = minX - (mouse.x) ;
					minX = mouse.x; 
				}
				if(maxX < mouse.x){
					maxX = mouse.x;
				}
				if(minY > mouse.y){
					ofY = minY - (mouse.y); 
					minY = mouse.y;
				}
				if(maxY < mouse.y){
					maxY = mouse.y;
				}
				
				print((int)((maxY - minY) / 0.01f));
				auxiliarTexture = new Texture2D((int)((maxX - minX) / 0.01f) + radius * 2, (int)((maxY - minY) / 0.01f) + radius * 2, TextureFormat.ARGB32, true);
				Color[] originalPixels = objectTexture.GetPixels (0, 0, objectTexture.width, objectTexture.height);
				auxiliarTexture.SetPixels((int)(ofX / 0.01f), (int)(ofY / 0.01f), objectTexture.width, objectTexture.height, originalPixels);
				int steps = (int)(Vector3.Distance(mouse, lastMouse) / 0.01f);
				for(int i = 0; i < steps; i += 5){
					SetPixelsFromTexture(radius, (int)((mouse.x * (steps - i) / steps + lastMouse.y * i / steps - minX) / 0.01f), (int)((mouse.y * (steps - i) / steps + lastMouse.y * i / steps - minY) / 0.01f));
				}
				objectTexture = auxiliarTexture;
				lastMouse = mouse;
				this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(auxiliarTexture, new Rect(0, 0, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100);
				Destroy(this.gameObject.GetComponent<PolygonCollider2D>());
				this.gameObject.AddComponent<PolygonCollider2D>();
			}

		}
	}

	void SetPixelsFromTexture(int radius, int x, int y){
		// Creating a texture triple the size of the original 3x3 tile

		// Converting x, y to texture coordinates
		int auxX = x;
		int auxY = y;
		while(auxX < texture.width || auxX > 2 * texture.width) {
			if(auxX < texture.width)
				auxX += texture.width;
			if(auxX > 2 * texture.width)
				auxX -= texture.width;
		}
		while(auxY < texture.height || auxY > 2 * texture.height) {
			if(auxY < texture.height)
				auxY += texture.height;
			if(auxY > 2 * texture.height)
				auxY -= texture.height;
		}
		// Getting pixels that should be drawn
		Color[] drawPixels = utilityTexture.GetPixels (auxX - radius, auxY - radius, 2 * radius, 2 * radius);
		print (auxiliarTexture.width + " " + auxiliarTexture.height + " " + x + " " + y);
		auxiliarTexture.SetPixels (x, y, 2 * radius, 2 * radius, drawPixels);

	}	
}