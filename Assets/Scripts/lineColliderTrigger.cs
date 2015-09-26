using UnityEngine;
using System.Collections;

public class lineColliderTrigger : MonoBehaviour {

	private Animation lockOnBox;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "enemy") {
			lockOnSystem.enemyTargets.Add(col.gameObject);
			lockOnBox = col.gameObject.GetComponentInChildren<Animation>();
			//lockOnBox.Play();
			Debug.Log(lockOnSystem.enemyTargets.Count);

			
		
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "enemy") {
			Debug.Log ("Enemy lost!");
			lockOnSystem.enemyTargets.Remove(col.gameObject);
		}
	}


}
