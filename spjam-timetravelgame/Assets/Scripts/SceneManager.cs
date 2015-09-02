using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour 
{
	public void test()
	{
		Debug.Log("TESTEEEEEE");
	}
		
	public void LoadScreenById(int id)
	{
		Application.LoadLevel(id);
	}
}
