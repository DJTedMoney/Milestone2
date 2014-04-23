using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Client activeClient;
	public string command;
	public string serverCommand;
	public Player player;
	char delim = '$';
	public bool move;
	
	// Use this for initialization
	void Start () 
	{
		activeClient = GameObject.Find("GameClient").GetComponent<Client>();
		player = GameObject.Find ("Player").GetComponent<Player>();
		command = "";
		move = false;
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
		
		else if(Input.GetKeyDown(KeyCode.DownArrow) )
		{
			command = "D$";
		}
		
		else if(Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			command = "L$";
		}
		
		else if(Input.GetKeyDown(KeyCode.RightArrow) )
		{
			command = "R$";
		}
		//default command, means no change
		else
		{
			command = "X$";
		}
		
		//finishes the command with player data (Position x and y, speed, and size)
		command = command + player.transform.position.x.ToString() + "$" + player.transform.position.y.ToString() 
			      + "$" + player.speed.ToString() + "$" + player.size.ToString();
		activeClient.requestMove(command);
	}
	
	void applyMove()
	{
		if(move == true)
		{
			//sets player position to match server
			int tempX  =  int.Parse(serverCommand.Substring(0,serverCommand.IndexOf(delim)));
			serverCommand= serverCommand.Substring(serverCommand.IndexOf(delim)+1);
			int tempY  =  int.Parse(serverCommand.Substring(0,serverCommand.IndexOf(delim)));
			player.transform.position = new Vector2(tempX, tempY);
			serverCommand= serverCommand.Substring(serverCommand.IndexOf(delim)+1);
			
			//sets player direction to match server
			tempX = int.Parse(serverCommand.Substring(0,serverCommand.IndexOf(delim)));
			serverCommand= serverCommand.Substring(serverCommand.IndexOf(delim)+1);
			tempY = int.Parse(command.Substring(0,command.IndexOf(delim)));
			serverCommand = serverCommand.Substring(serverCommand.IndexOf(delim)+1);
			player.setDirection(tempX, tempY);
			//sets player speed
			player.setSpeed(int.Parse(serverCommand.Substring(0,serverCommand.IndexOf(delim))));
			serverCommand = serverCommand.Substring(serverCommand.IndexOf(delim)+1);
			
			//sets player size
			player.size = int.Parse(serverCommand);
			move = false;
		}
	}
}
