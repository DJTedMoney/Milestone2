using UnityEngine;
using System.Collections;

public class LoginBox : MonoBehaviour 
{
	public string userName;
	public string passWord;
	
	public GUIText grafxText;
	
	public bool showLogin;
	
	// Use this for initialization
	void Start () 
	{
		// grafxText = GameObject.Find("GUIText").GetComponent<GUIText>();
		
		userName = "0000";
		passWord = "";
		
		// grafxText.text = "0000 0000";
	}
	
	// Update is called once per frame
	void Update () 
	{
		// grafxText.text = "hello";
	}
	
	void OnGUI()
	{	
		if(!showLogin)
		{
			GUI.Label(new Rect(130, 200, 100, 20), "UserName : ");
			
			userName = GUI.TextField(new Rect(200, 200, 100, 20), userName );
			
			GUI.Label(new Rect(130, 220, 100, 20), "PassWord : ");
			
			passWord = GUI.TextField(new Rect(200, 220, 100, 20), passWord);
			
			if(GUI.Button (new Rect (200, 170, 100, 20), "Connect") )
			{
				//grafxText.text = "Connect";
				
				showLogin = !showLogin;
			}
		}
		
		else
		{
			GUI.Label(new Rect(10, 40, 100, 20), userName);
			
			if(GUI.Button (new Rect(10, 10, 100, 20), "Disconnect") )
			{
				//grafxText.text = "Hello";
				
				showLogin = !showLogin;
			}
		}
	}
}
