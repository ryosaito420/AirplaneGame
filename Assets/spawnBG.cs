using UnityEngine;
using System.Collections;

public class spawnBG : MonoBehaviour {

	public GameObject bg;
	float tileHeight;
	static public bool spawnNew;
	static public float dissapearDist;
	//float bgHeight = bg.GetComponent<Mesh> ().bounds.size.y;

	// Use this for initialization
	void Start () {
		spawnNew = false;
		tileHeight = bg.GetComponent<Renderer> ().bounds.size.y;
		Instantiate (bg, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		Instantiate (bg, new Vector3(transform.position.x, transform.position.y + tileHeight, transform.position.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (bg.GetComponent<scrollBG> ().dissapeared);
		if( spawnNew){
		    Debug.Log("Spawn New tile");
			//float tileDist = tileHeight - 
			Instantiate (bg, new Vector3 (transform.position.x, transform.position.y + tileHeight -10 , transform.position.z), Quaternion.identity);
			spawnNew = false;
			dissapearDist = 0;
		}
	}
}
