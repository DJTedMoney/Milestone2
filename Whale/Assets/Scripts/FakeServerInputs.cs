using UnityEngine;
using System.Collections;

//make an array of pairs (4) to keep track of the x, y for each pellet
//in update: if player's new position collides with a pellet, that pellet gets repositioned
//player's size++ and speed-- change
//this info gets added to the "message" which gets passed to "client" -> "GameManager" (which then parses the message)
//(only need to add the X, Y position of each pellet to the message)

public class FakeServerInputs : MonoBehaviour 
{
	public Client activeClient;
	public string message;
	public Vector2[] pelletPos;
	public Vector2 p1Pos;
	public Vector2 p1Dir;
	public int p1Speed;
	public int p1Size;
	public char delim = '$';	
	
	//test for push
	// Use this for initialization
	void Start() 
	{
		activeClient = GameObject.Find("GameClient").GetComponent<Client>();
		pelletPos = new Vector2[4];
	//	foreach (Vector2 pos in pelletPos)
	//		{pos. =  new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );}
		
		for (int i = 0; i < 4 ; i++){
			pelletPos[i] =  new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
		}
		
		p1Pos = new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
		p1Speed = 20;
		p1Size = 40;
		tryMove("R");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//updates player position
		p1Pos = p1Pos + (p1Dir * p1Speed);
		sendMessage();
		
		//if player's position collides with a pellet:
		//playerSize increases
		//playerSpeed decreases
		//pellet respawns to a random location
		//Random.Range (0, screenmax); 
		
		//foreach (Vector2 pos in pelletPos){
		int xDif; 
		int yDif;
		bool xFlag = false;
		bool yFlag = false;
		for (int i = 0; i < 4 ; i++)
		{
			xDif = (int)(p1Pos.x-pelletPos[i].x);
			yDif = (int)(p1Pos.y-pelletPos[i].y);
			if(xDif <= ((p1Size/2) + 10) && xDif >= -((p1Size/2) + 10))
				xFlag = true;
			if(yDif <= ((p1Size/2) + 10) && yDif >= -((p1Size/2) + 10))
				yFlag = true;
			if (xFlag && yFlag) 
			{
				p1Size+= 20;
				if (p1Speed>1)
					p1Speed-= 1;
				pelletPos[i] =  new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
			}
			
		}
		
		
		if(p1Pos.x >= 500 - (p1Size/2) || p1Pos.x <= -500 + (p1Size/2) || p1Pos.y >= 500 - (p1Size/2) 
		   || p1Pos.y <= -500 + (p1Size/2))
		{
			p1Pos = new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
			p1Size = 40;
			p1Speed = 20;
			sendMessage();
		}
	}
	
	void tryMove(string inputMove)
	{
		//changes position
		if(inputMove == "U")
		{
			p1Dir = new Vector2(0,1);
			if(p1Speed < 0)
				p1Speed *= -1;
		}
		else if(inputMove == "D")
		{
			p1Dir = new Vector2(0,1);
			if(p1Speed > 0)
				p1Speed *= -1;
		}
		else if(inputMove == "L")
		{
			p1Dir = new Vector2(1,0);
			if(p1Speed > 0)
				p1Speed *= -1;
		}
		else if(inputMove == "R")
		{
			p1Dir = new Vector2(1,0);
			if(p1Speed < 0)
				p1Speed *= -1;
		}
		sendMessage();
	}
	
	public void getMessage(string input)
	{
		string tempMes = input.Substring(0,input.IndexOf(delim));
		
		//parses out the message to the variables
		input= input.Substring(input.IndexOf(delim)+1);
		p1Pos.x  =  int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		p1Pos.y  =  int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		p1Speed = int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		p1Size = int.Parse(input);
		
		tryMove(tempMes);
	}
	
	void sendMessage()
	{
		message = p1Pos.x.ToString() + "$" + p1Pos.y.ToString() + "$" + p1Dir.x.ToString() + "$" + 
				  p1Dir.y.ToString() + "$" + p1Speed.ToString() + "$" + p1Size.ToString();
		
		//should add all 4 of the pellets' X and Y to the end of the message
		for (int i = 0; i < 4; i++){
			message = message + "$" + pelletPos[i].x.ToString() + "$" + pelletPos[i].y.ToString();
		}
		message += "$";
		
		print("From Server: " + message);
		
		//This will eventualy be TCP code to send message to the client
		activeClient.doMove(message);
	}
}
