using UnityEngine;
using System.Collections;

public class LoginBox : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		 GUI.Box(new Rect(0,0,1000, 1000),"This is not a title");
	}
}
