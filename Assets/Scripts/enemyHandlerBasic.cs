using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class enemyHandlerBasic : MonoBehaviour {

	public GameObject lockOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		Debug.Log ("Locked on!");
		lockOnSystem.enemyTargets.Add (this.gameObject);
		Debug.Log (lockOnSystem.enemyTargets.Count);
	}


}
