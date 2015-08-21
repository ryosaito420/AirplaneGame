using UnityEngine;
using System.Collections;

public class proceduralRings : MonoBehaviour {

	public int min = -500;
	public int max = 500;
	public GameObject ring;
	public float  numberOfCubes = 1000;

	Vector3 GeneratedPosition()
	{
		int x,y,z;
		x = Random.Range(min,max);
		y = Random.Range(min,max);
		z = Random.Range(min,max);
		return new Vector3(x,y,z);
	}

	void PlaceCubes()
	{
		for(int i = 0; i < numberOfCubes; i++)
		{
			Instantiate(ring, GeneratedPosition(), Quaternion.identity);
		}
	}

	// Use this for initialization
	void Start () {
		PlaceCubes ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
