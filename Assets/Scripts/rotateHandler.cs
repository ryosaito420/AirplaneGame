using UnityEngine;
using System.Collections;

public class rotateHandler : MonoBehaviour {

	public float heldTimer = 0;
	double ButtonCooler =0.5;
	int ButtonCount = 0;
	bool rotating = false;
	public Animation anim;

	public float xRotMax;
	public float yRotMax;

	public void barrelRoll(Vector3 savedAngle ){
		if (Input.GetButtonDown( "Jump") ){
			if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/) {
				anim.Play("roll");
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(savedAngle) ,  .0625f);
             }
			 else {
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
	
	void Start(){
	    anim = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update () {

		//This code will rotate the plane when pushing left or right
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Vector3 savedAngle = transform.eulerAngles;

		float xRot = transform.eulerAngles.x;
        if (xRot > 180f) { xRot -= 360f; }
		float yRot = transform.eulerAngles.y;

		barrelRoll (savedAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-h * xRotMax, yRot, 0)), .0625f);

		//normalize the rotation to 0 if no input is detected
		if(h != 0) {
			Vector3 zero = new Vector3(0,yRot,0);
			if( Vector3.Distance(transform.eulerAngles,zero ) > 0.01f ){
				float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 0.0f, (25)* Time.deltaTime);
				transform.eulerAngles = new Vector3(angle, yRot, 0);
			}

			else{
				transform.eulerAngles = zero;
			}
		}
	}

}
