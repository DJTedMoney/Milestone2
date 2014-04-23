using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour {
	public Transform pelletMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setPos(int newX, int newY)
	{
		transform.position = new Vector2(newX, newY);
	}
}
