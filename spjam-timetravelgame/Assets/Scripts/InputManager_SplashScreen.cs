using UnityEngine;
using System.Collections;

public class InputManager_SplashScreen : MonoBehaviour {
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.Return))
		{
			Application.LoadLevel(3);
		}	
	}
}
