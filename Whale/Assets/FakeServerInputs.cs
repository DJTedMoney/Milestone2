using UnityEngine;
using System.Collections;

public class FakeServerInputs : MonoBehaviour 
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
	
	}
}
