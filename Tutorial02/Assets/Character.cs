using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    Vector3 moveSpeed = new Vector3();
    Vector3 direction = new Vector3();
	// Use this for initialization
	void Start () {
        direction = Vector3.forward;
    }
	
	// Update is called once per frame
	void Update () {
        CharacterController charaCtr = GetComponent<CharacterController>();
        moveSpeed.x = 0.0f;
        moveSpeed.z = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            moveSpeed.x = 0.1f;   
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            moveSpeed.x = -0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            moveSpeed.z = 0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            moveSpeed.z = -0.1f;
        }
        if(Input.GetKey(KeyCode.J) == true)
        {
            moveSpeed.y = 0.5f;
        }

        moveSpeed.y -= 0.05f;
        Vector3 dirTmp = moveSpeed;
        dirTmp.y = 0.0f;
        if (dirTmp.magnitude > 0.0f)
        {
            direction = dirTmp.normalized;
        }
        charaCtr.Move(moveSpeed);
        if (charaCtr.isGrounded)
        {
            //地面に着いている。
            moveSpeed.y = 0.0f;
        }
        
        transform.localRotation = Quaternion.LookRotation(direction);
    }
}
