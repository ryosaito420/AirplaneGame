using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float dist;
	private float counter;

	public Transform origin;
	public Transform endPoint;
	public float drawSpeed;


	// Use this for initialization
	void Start () {

		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (.45f, .45f);
		dist = Vector3.Distance( origin.position , endPoint.position);
	}
	
	// Update is called once per frame
	void Update () {
			counter += .1f / drawSpeed;
			float x = Mathf.Lerp (0, dist, counter);
			Vector3 pointA = origin.position;
			Vector3 pointB = endPoint.position;

			// length * unit vector starting at origin
			Vector3 pointAlongline = x * Vector3.Normalize (pointB - pointA) + pointA; 
			lineRenderer.SetPosition (1, pointAlongline);

		
	}
}
