using UnityEngine;
using System.Collections;

public class Client : MonoBehaviour 
{
	public GameManager manager;
	public FakeServerInputs server;
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find("Manager").GetComponent<GameManager>();
		server = GameObject.Find ("FakeServer").GetComponent<FakeServerInputs>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void requestMove(string inputMove)
	{
		
	}
	
	
}
