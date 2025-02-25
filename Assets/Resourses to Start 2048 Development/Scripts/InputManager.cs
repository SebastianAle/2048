﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public enum MoveDirection
	{
		Left, Right, Up, Down
	}

	private GameManager gm;

	void Awake()
	{
		gm = GameObject.FindObjectOfType<GameManager> ();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gm.State == GameState.Playing) 
		{
			if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				gm.Move (MoveDirection.Right);
			} 
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				gm.Move (MoveDirection.Left);
			} 
			else if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				gm.Move (MoveDirection.Up);
			} 
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				gm.Move (MoveDirection.Down);
			}
		}
	}
}
