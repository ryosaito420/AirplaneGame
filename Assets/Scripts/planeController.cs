using UnityEngine;
using System.Collections;

public class planeController : MonoBehaviour {

	//public float thrust; //Speed plane moves foward
	public float maxVerticalSpeed;
	public float maxHorizontalSpeed;
	public float horizontalRotateSpeed;

	private float verticalSpeed = 0; //Move plane up & down speed
	private float horizontalSpeed = 0; // Move plane left & right speed
	private Rigidbody rb;
	private float zBound = 8f; //upperbound of plane
	private float yBound = 3f; //Lowerbound of plane
	// Use this for initialization
	void Start(){
		//rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void FixedUpdate () { 
		transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime); //Move plane upwards
		transform.Translate(Vector3.forward * horizontalSpeed * Time.deltaTime);//Move plane horizontally 
	}

	void HorizontalInputHandler(float a){
		if (a > 0 && transform.localPosition.z > -zBound) {
			horizontalSpeed = -maxHorizontalSpeed;
			//transform.Rotate(Vector3.right * Time.deltaTime * -horizontalRotateSpeed);
		}
		else if (a < 0 && transform.localPosition.z < zBound )
			horizontalSpeed = maxHorizontalSpeed;
		else
			horizontalSpeed = 0;
	}

	void VerticalInputHandler(float v){
		if (v > 0  && transform.localPosition.y < yBound ) {
			verticalSpeed = maxVerticalSpeed;
		}
		else if (v < 0 &&  transform.localPosition.y > -yBound)
			verticalSpeed = -maxVerticalSpeed;
		else
			verticalSpeed = 0;
	}

	//For futureUse
	void barrelRollHandler(){
		//?????
	}
	
	void Update (){
		float a = Input.GetAxisRaw  ("Horizontal") ;
		HorizontalInputHandler (a);

		float v = Input.GetAxisRaw  ("Vertical") ;
		VerticalInputHandler (v);
	}
}
