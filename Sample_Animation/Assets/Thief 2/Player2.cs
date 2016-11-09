using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
    ///
    IEnumerator _SetTrigger(string name)
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(name, true);
        yield return new WaitForSeconds(0);
        animator.SetBool(name, false);
    }
    /// <summary>
    /// フラグのトリガー設定。
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    void SetTrigger(string name)
    {
        StartCoroutine(_SetTrigger(name));
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.DownArrow)
           )
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (Input.GetKeyDown(KeyCode.A))    //トリガー判定はDown
        {
            SetTrigger("isAttack");
        }
    }
}
