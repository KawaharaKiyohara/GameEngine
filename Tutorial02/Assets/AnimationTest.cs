using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Animator animator = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.RightArrow)
            )
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Attack");
        }
       
	}
}
