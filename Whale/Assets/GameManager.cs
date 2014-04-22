using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Client activeClient; 
	
	// Use this for initialization
	void Start () 
	{
		activeClient = GameObject.Find("Client").GetComponent<Client>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
