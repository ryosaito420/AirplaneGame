using UnityEngine;
using System.Collections;

public class rotateHandler : MonoBehaviour {

	public float heldTimer = 0;
	double ButtonCooler =0.5;
	int ButtonCount = 0;
	
	public void barrelRoll(){
		if (Input.GetButtonDown( "Jump") ){
			if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/) {

				transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
				Debug.Log("Barrel Roll");
			} else {
				ButtonCooler = 0.5; 
				ButtonCount += 1;
			}
		}
		if ( ButtonCooler > 0 )
		{	
			ButtonCooler -= 1 * Time.deltaTime ;
			
		}else{
			ButtonCount = 0 ;
		}
	}
	// Update is called once per frame
	void Update () {

		//This code will rotate the plane when pushing left or right
		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");
//		float j = Input.GetAxisRaw ("Jump");
		bool rotating = false;
		barrelRoll ();

		if (h > 0) {
			if(rotating)
				heldTimer = 0;
			transform.Rotate (Vector3.left);
			heldTimer++;
			rotating = true;
		} else if (h < 0) {
			if(rotating)
				heldTimer = 0;
			transform.Rotate (Vector3.right);
			heldTimer++;
			rotating = true;
		}
		//normalize the rotation to 0 if no input is detected
		else {
			rotating = false;
			Vector3 zero = new Vector3(0,0,0);
			if( Vector3.Distance(transform.eulerAngles,zero ) > 0.01f ){
				float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 0.0f, (15 + heldTimer)* Time.deltaTime);
				transform.eulerAngles = new Vector3(angle, 0, 0);
			}

			else{
				transform.eulerAngles = zero;
				heldTimer = 0;
			}

			
		}
		
		//		if (v > 0) {
//			transform.Rotate (Vector3.forward);
//		} if (v < 0) {
//			transform.Rotate (Vector3.back);
//		}
//		else {
//			float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0.0f, 15* Time.deltaTime);
//			transform.eulerAngles = new Vector3(0, angle, 0);
//		}




	}
}
