using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    Vector3 move = new Vector3();
    float moveSpeed = 0.3f;
    bool isJump = false;
    Animator animator;
    CharacterController charaCtr;
    public GameObject goBulletOriginal;
    public GameObject goGun;
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
    void Start () {
        animator = GetComponent<Animator>();
        charaCtr = GetComponent<CharacterController>();
    }
    /// <summary>
    /// 弾丸を発射
    /// </summary>
	void ShotBullet()
    {
        GameObject bt = Instantiate(goBulletOriginal);
        bt.transform.localPosition = goGun.transform.position;
    }
	// Update is called once per frame
	void Update () {
        float h_value = Input.GetAxis("Horizontal");
        float v_value = Input.GetAxis("Vertical");
        CharacterController charaCtr = GetComponent<CharacterController>();
        
        move.x = h_value * 0.3f;
        move.y -= 1.0f * Time.deltaTime;    //重力加速度。
        move.z = v_value * 0.3f;
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            move.y = 0.5f;
            isJump = true;
        }
        charaCtr.Move(move);
        if (charaCtr.isGrounded)
        {
            //地面に着いている。
            move.y = 0.0f;
            isJump = false;
        }
        //一旦移動フラグは全部クリア。
       
        animator.SetBool("isRun", false);

        if (Mathf.Abs(move.x) > 0.0f || Mathf.Abs(move.z) > 0.0f)
        {
            animator.SetBool("isRun", true);
            if (Input.GetButtonDown("Fire1"))
            {
                SetTrigger("isAttackRun");
                //弾丸を生成。
                ShotBullet();
            }
        }
        else {
            if (Input.GetButtonDown("Fire1"))
            {
                SetTrigger("isAttack");
                //弾丸を生成。
                ShotBullet();
            }
        }
    }
}
