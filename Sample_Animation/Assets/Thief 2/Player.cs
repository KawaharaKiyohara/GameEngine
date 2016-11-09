using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Animator animator = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("isAttack");
        }
	}
}
