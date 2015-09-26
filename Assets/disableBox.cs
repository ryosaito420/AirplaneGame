using UnityEngine;
using System.Collections;

public class disableBox : MonoBehaviour {

	public static bool boxOn;
	// Use this for initialization
	void Start () {
		boxOn = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(!boxOn)
			GetComponent<SpriteRenderer> ().enabled = false;
	}
}
