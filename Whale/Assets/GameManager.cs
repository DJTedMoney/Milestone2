using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Client activeClient; 
	
	// Use this for initialization
	void Start () 
	{
		activeClient = GameObject.Find("GameClient").GetComponent<Client>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) )
		{
			activeClient.requestMove("pU");
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow) )
		{
			activeClient.requestMove("pD");
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			activeClient.requestMove("pL");
		}
		
		if(Input.GetKeyDown(KeyCode.RightArrow) )
		{
			activeClient.requestMove("pR");
		}
		
		
	}
}
