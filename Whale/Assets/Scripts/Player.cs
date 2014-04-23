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
		size = 40;
		speed = -50;
		direction = new Vector2(0,1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(transform.position.x + direction.x*speed, transform.position.y + direction.y*speed);
	}
	
	public void setPosition(int newX, int newY)
	{
		transform.position = new Vector2(newX, newY);
	}
	
	public void setDirection(int newX, int newY)
	{
		direction = new Vector2(newX, newY);
		//rigidbody.velocity = direction * speed;
	}
	
	public void setSpeed(int newSpeed)
	{
		speed = newSpeed;
		//rigidbody.velocity = direction*speed;
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10, 65, 40, 20), "Size : ");
		GUI.Label(new Rect(55, 65, 40, 20), size.ToString() );
		GUI.Label(new Rect(10, 90, 40, 20), "Speed : ");
		GUI.Label(new Rect(55, 90, 40, 20), speed.ToString() );
	}
}
