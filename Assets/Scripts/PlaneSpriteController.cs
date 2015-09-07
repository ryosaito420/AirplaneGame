using UnityEngine;
using System.Collections;

public class PlaneSpriteController : MonoBehaviour {
	public float maxHorizontalSpeed;
	public float maxVerticalSpeed;
	public float trimDist;

	public float xBound; //horizontal bound of plane
	public float yBound; // vertical bound
	private float verticalSpeed = 0; //Move plane up & down speed
	private float horizontalSpeed = 0; // Move plane left & right speed

	private BoxCollider2D collider;
	private Rigidbody2D plane;

	//Gets world Coordiantes of screen bounds and sets xbound and ybound for plane boundaries;
	void getScreenBounds(){
		Vector3 screenBounds = new Vector3 ((float)Screen.width, (float)Screen.height, 10);
		screenBounds = Camera.main.ScreenToWorldPoint (screenBounds);
		xBound = screenBounds.x;
		yBound = screenBounds.y;
	}

	void HorizontalInputHandler(float a){
		if (a > 0) {
			horizontalSpeed = maxHorizontalSpeed;
		} else if (a < 0)
			horizontalSpeed = -maxHorizontalSpeed;
		else
			horizontalSpeed = 0;
	}
	void VerticalInputHandler(float b){
		if (b > 0 ) {
			verticalSpeed = maxVerticalSpeed;
		}
		else if (b < 0)
			verticalSpeed = -maxVerticalSpeed;
		else
			verticalSpeed = 0;
	}
	//Need to clamp input of plane to prevent it going offscreen
	void clampInput(float trimDist){
		//Get size of plane's collider rectangle
		Vector2 planeSize = collider.size;
		
		// Need to clamp xCoordiantes and zCoordiantes to screen boundary
		Vector3 clampedPosition = transform.position; 
		clampedPosition.x = Mathf.Clamp (transform.localPosition.x, -xBound + planeSize.x*2+ trimDist, xBound - planeSize.x*2- trimDist);
		clampedPosition.y = Mathf.Clamp (transform.localPosition.y, -yBound + planeSize.y *2+ trimDist, yBound - planeSize.y*2 -trimDist);
		// re-assigning the transform's position will clamp it
		transform.position = clampedPosition;
	}

	// Use this for initialization
	void Start () {
		plane = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
		getScreenBounds ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float a = Input.GetAxisRaw  ("Horizontal") ;
		HorizontalInputHandler (a);
		float b = Input.GetAxisRaw("Vertical");
		VerticalInputHandler (b);
	
		plane.AddForce(Vector2.right * horizontalSpeed) ;//Move plane horizontally 
		plane.AddForce(Vector2.up * verticalSpeed) ;//Move plane horizontally 
		clampInput (trimDist);
	}
	
	void Update(){
	}
}
