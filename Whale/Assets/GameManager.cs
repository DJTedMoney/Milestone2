using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Client activeClient;
	public string command;
	public Player player;
	
	// Use this for initialization
	void Start () 
	{
		activeClient = GameObject.Find("GameClient").GetComponent<Client>();
		player = GameObject.Find ("Player").GetComponent<Player>();
		command = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		sendMove();
		applyMove();
	}
	
	public void sendMove()
	{
		//starts command with new direction (U = up, D = down
		//L = left, and R = right)
		if(Input.GetKeyDown(KeyCode.UpArrow) )
		{
			command = "U$"; 
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow) )
		{
			command = "D$";
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			command = "L$";
		}
		
		if(Input.GetKeyDown(KeyCode.RightArrow) )
		{
			command = "R$";
		}
		//finishes the command with player data (Position x and y, speed, and size)
		command = command + player.transform.position.x.ToString() + "$" + player.transform.position.y.ToString() 
			      + "$" + player.speed.ToString() + "$" + player.size.ToString();
		activeClient.requestMove(command);
	}
	
	void applyMove()
	{
	}
}
