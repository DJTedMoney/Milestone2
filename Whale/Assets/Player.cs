using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Transform playerMesh;
	
	public Vector2 velocity;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
	}
}
