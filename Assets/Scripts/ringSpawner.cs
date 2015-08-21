using UnityEngine;
using System.Collections;

public class ringSpawner : MonoBehaviour {
	public float ringDistance;
	public GameObject ring;
	private float ringXpos;

	public float yBound;
	public float zBound;

	Vector3 GeneratedPosition()
	{

		float yPos = transform.position.y;
		float zPos = transform.position.z;
		float x,y,z;

		x = ringXpos;
		y = Random.Range(-yBound + yPos, yBound + yPos);
		z = Random.Range( -zBound + zPos, zBound + zPos);
		return new Vector3(x,y,z);
	}
	
	void PlaceRings()
	{
		Instantiate(ring, GeneratedPosition(), Quaternion.identity);
	}
	
	// Use this for initialization
	void Start () {
		ringXpos = ringDistance + transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		PlaceRings();
		ringXpos += ringDistance;
	}
}
