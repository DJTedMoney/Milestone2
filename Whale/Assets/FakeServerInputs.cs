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
		
	}
	
	void tryMove(string inputMove)
	{
		//changes position
		if(inputMove == "pU")
		{
			p1Dir = new Vector2(0,1);
		}
		else if(inputMove == "pD")
		{
			p1Dir = new Vector2(0,1) * -1;
		}
		else if(inputMove == "pL")
		{
			p1Dir = new Vector2(0,1) * -1;
		}
		else if(inputMove == "pR")
		{
			p1Dir = new Vector2(1,0);
		}
		sendMessage();
		
		
	}
	
	void sendMessage()
	{
		message = "x" + p1Pos.x.ToString() + "y" + p1Pos.y.ToString() + "dX" + p1Dir.x.ToString() + "dY" + 
				  p1Dir.y.ToString() + "t" + p1Speed.ToString() + "s" + p1Size.ToString();
		
		//This will eventualy be TCP code to send message to the client
		activeClient.message = message;
	}
}
