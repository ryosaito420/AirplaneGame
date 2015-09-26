using UnityEngine;
using System.Collections;

public class lineColliderTrigger : MonoBehaviour {

	private SpriteRenderer renderBox;
	private Transform targetBox;

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "enemy") {
			lockOnSystem.enemyTargets.Add(col.gameObject);
			targetBox = col.transform.GetChild(0);
			renderBox =  targetBox.GetComponent<SpriteRenderer>();
			disableBox.boxOn = true;
			Animation lockOnBox = targetBox.GetComponent<Animation>();
			renderBox.enabled = true;
			lockOnBox.Play ();
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		renderBox.enabled = true;
		disableBox.boxOn = true;
	}

}
