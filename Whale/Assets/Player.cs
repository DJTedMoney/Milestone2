using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Transform playerMesh;
	
	public Vector2 direction;
	public int speed;
	public int size;
	
	public Client commsClient;
	
	// Use this for initialization
	void Start () 
	{
		commsClient = GameObject.Find("GameClient").GetComponent<Client>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(transform.position.x + direction.x*speed, transform.position.y + direction.y*speed);
		
		
	}
	
	void setPosition(int newX, int newY)
	{
		transform.position = new Vector2(newX, newY);
	}
	
	void setDirection(int newX, int newY)
	{
		direction = new Vector2(newX, newY);
		rigidbody.velocity = direction * speed;
	}
	
	void setSpeed(int newSpeed)
	{
		speed = newSpeed;
		rigidbody.velocity = direction*speed;
	}
}
