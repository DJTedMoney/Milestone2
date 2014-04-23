using UnityEngine;
using System.Collections;

public class LoginBox : MonoBehaviour 
{
public string userName;
	
	public GUIText grafxText;
	
	public bool showLogin;
	
	// Use this for initialization
	void Start () 
	{
		// grafxText = GameObject.Find("GUIText").GetComponent<GUIText>();
		
		userName = "0000";
		
		// grafxText.text = "0000 0000";
	}
	
	// Update is called once per frame
	void Update () 
	{
		grafxText.text = "hello";
	}
	
	void OnGui()
	{	
		if(!showLogin)
		{
			if(GUI.Button (new Rect (100, 100, 100, 20), "Connect") )
			{
				grafxText.text = "Connect";
			}
		}
		
		else
		{
			if(GUI.Button (new Rect(10, 10, 100, 20), "Trying") )
			{
				grafxText.text = "Hello";
			}
		}
	}
}
