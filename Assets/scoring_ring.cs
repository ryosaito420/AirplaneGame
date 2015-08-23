using UnityEngine;
using System.Collections;

public class scoring_ring : MonoBehaviour {

	public GameObject gameHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("+1");
		gameHandler.GetComponent<GameHandler>().gameScore += 1;

	}

	


}
