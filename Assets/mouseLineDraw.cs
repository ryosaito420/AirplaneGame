using UnityEngine;
using System.Collections;

public class mouseLineDraw : MonoBehaviour {

	private LineRenderer line;	//line Renderer refrence
	private Vector3 mousePos; 
	private Vector3 startPoint; //start Postion of line
	private Vector3 endPoint; 	// end position of line

	// Use this for initialization
	void Start () {
	
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
		}

		// on letting go of leftclick
		else if (Input.GetMouseButtonUp (0)) {

			//if line exists
			if (line) {
//				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //covert mouselocation to unity world location
//				mousePos.z = 0; //2d game so z is irrelevant
//				line.SetPosition (1, mousePos); // line ends at mouse up
//				endPoint = mousePos;
//				addCollision (); 
				Destroy(line.gameObject);
				line = null;

			}
		} 
		// while dragging display line but dont add collider yet
		else if (Input.GetMouseButton (0)) {
			if (line) {
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mousePos.z = 0;
				endPoint = mousePos;
				line.SetPosition (1, mousePos);
				addCollision (); 

			}
		}
	
	}

	//Creates a new red line gameobject to hold the line render in runtime
	void createLine(){
		line = new GameObject ("Line").AddComponent<LineRenderer> ();
		line.material = new Material (Shader.Find ("Diffuse"));
		line.SetVertexCount (2);
		line.SetWidth (.2f, .2f);
		line.SetColors (Color.red, Color.red);
		line.useWorldSpace = true;
	}

	// add a collider to line Gameobject dynamically
	void addCollision(){

		BoxCollider2D lineCollider = new GameObject ("Collider").AddComponent<BoxCollider2D> ();
		lineCollider.transform.parent = line.transform; //line is parent of boxcollider
		float lineLength = Vector3.Distance(startPoint, endPoint);
		lineCollider.size = new Vector3(lineLength, .1f, .1f); // x, y, z
		Vector3 midPoint = (startPoint + endPoint) / 2;
		lineCollider.transform.position = midPoint;//collider position will be midpoint of line
		float angle = Mathf.Abs ((startPoint.y - endPoint.y) / (startPoint.x - endPoint.x));

		if((startPoint.y<endPoint.y && startPoint.x>endPoint.x) || (endPoint.y<startPoint.y && endPoint.x>startPoint.x))
		{
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		lineCollider.transform.Rotate (0, 0, angle);
	}








}
