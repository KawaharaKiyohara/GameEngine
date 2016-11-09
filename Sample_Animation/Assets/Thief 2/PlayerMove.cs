﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.z = 0.1f;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            move.z = -0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x = -0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x = 0.1f;
        }
            CharacterController charCtr = GetComponent<CharacterController>();
        charCtr.Move(move);

    }
}
