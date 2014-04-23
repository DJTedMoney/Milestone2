using UnityEngine;
using System.Collections;

public class FakeServerInputs : MonoBehaviour 
{
	public Client activeClient;
	public string message;
	public Vector2 p1Pos;
	public Vector2 p1Dir;
	public int p1Speed;
	public int p1Size;
	public char delim = '$';	
	
	
	// Use this for initialization
	void Start() 
	{
		activeClient = GameObject.Find("GameClient").GetComponent<Client>();
		p1Pos = new Vector2( (Random.Range(-450.0f, 450.0f) ), (Random.Range(-450.0f, 450.0f) ) );
		p1Speed = 50;
		p1Size = 10;
		tryMove("R");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//updates player position
		p1Pos = p1Pos + (p1Dir * p1Speed);
		sendMessage();
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
			p1Dir = new Vector2(0,1);
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
		print(input);
		input= input.Substring(input.IndexOf(delim)+1);
		print(input);
		p1Pos.x  =  int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		print(input);
		p1Pos.y  =  int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		print(input);
		p1Speed = int.Parse(input.Substring(0,input.IndexOf(delim)));
		input= input.Substring(input.IndexOf(delim)+1);
		print(input);
		p1Size = int.Parse(input);
		
		tryMove(tempMes);
	}
	
	void sendMessage()
	{
		message = "x" + p1Pos.x.ToString() + "y" + p1Pos.y.ToString() + "dX" + p1Dir.x.ToString() + "dY" + 
				  p1Dir.y.ToString() + "t" + p1Speed.ToString() + "s" + p1Size.ToString();
		
		//This will eventualy be TCP code to send message to the client
		activeClient.message = message;
	}
}
