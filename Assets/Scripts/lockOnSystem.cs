using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class lockOnSystem : MonoBehaviour {

	public static List <GameObject> enemyTargets ;

	public GameObject missle;
	
	private LineRenderer line;	//line Renderer refrence
	private GameObject lineObj;
	private Vector3 mousePos; 
	private Vector3 mousePosPrev; //mouse pos from previous frame
	private Vector3 startPoint; //start Postion of line
	private Vector3 endPoint; 	// end position of line
	private GameObject colliderbox;
	private GameObject col;
	private BoxCollider2D lineCollider;


	// Use this for initialization
	void Start () {
		enemyTargets = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			// create a new line if none exist
			if (line == null) {
				createLine ();
			}
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //covert mouselocation to unity world location
			mousePos.z = 0; //2d game so z is irrelevant
			
			line.SetPosition (0, mousePos); // line starts at mouse down
			startPoint = mousePos; 
			endPoint = mousePos;
			line.SetPosition (1, mousePos);
			
		}
		
		
		// on letting go of leftclick
		else if (Input.GetMouseButtonUp (0)) {
			
			//if line exists
			if (line) {
				//Fix line one last frame before destorying
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //covert mouselocation to unity world location
				mousePos.z = 0; //2d game so z is irrelevant
				line.SetPosition (1, mousePos); // line ends at mouse up
				endPoint = mousePos;
				Destroy (line.gameObject);

				//remove all targetBoxes from enemy ships
				disableBox.boxOn = false;

				//fire then remove all targets from list
				for( int i =0; i< lockOnSystem.enemyTargets.Count; ++i)
					fireMissle();


				lockOnSystem.enemyTargets.Clear ();
				line = null;
			}

			//FIRE MISSLES!


		} 
		// while dragging display line but dont add collider yet
		else if (Input.GetMouseButton (0)) {
			if (line) {
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mousePos.z = 0;
				line.SetPosition (1, mousePos);
				endPoint = mousePos;
				colliderbox = addCollision ();
			}
		}
	}

	void fireMissle(){
		//Instantiate a new missle
		GameObject new_missle = Instantiate (missle, new Vector3 (transform.position.x, transform.position.y), missle.transform.localRotation) as GameObject;
		//wait for ?? seconds
	}
	
	//Creates a new red line gameobject to hold the line render in runtime
	void createLine(){
		//create line drawing
		lineObj = new GameObject ("Line");
		//SpriteRenderer spriteRenderer = lineObj.AddComponent<SpriteRenderer> ();
		line = lineObj.AddComponent<LineRenderer> ();
		Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
		line.material = whiteDiffuseMat;
		line.SetVertexCount (2);
		line.SetWidth (.2f, .2f);
		line.material.color = Color.red;
		line.useWorldSpace = true;

		
		// create collider
		col = new GameObject("Collider");
		lineCollider = col.AddComponent<BoxCollider2D> ();
		col.AddComponent<lineColliderTrigger> ();
		lineCollider.isTrigger = true;
		lineCollider.transform.parent = line.transform; //line is parent of boxcollider
		
	}

	// add a collider to line Gameobject dynamically
	GameObject addCollision(){
		float angle =0;
		float lineLength = Vector3.Distance(startPoint, endPoint);
		lineCollider.size = new Vector3(lineLength, .1f, .1f); // x, y, z
		Vector3 midPoint = (startPoint + endPoint) / 2;
		lineCollider.transform.position = midPoint;//collider position will be midpoint of line
		
		if (startPoint != endPoint) {
			angle = Mathf.Abs ((startPoint.y - endPoint.y) / (startPoint.x - endPoint.x));		
		}
		if((startPoint.y<endPoint.y && startPoint.x>endPoint.x) || (endPoint.y<startPoint.y && endPoint.x>startPoint.x))
		{
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		lineCollider.transform.rotation = Quaternion.Euler(0,0,angle);
		//Debug.Log (lineCollider.transform.rotation);
		return col;
	}

}
