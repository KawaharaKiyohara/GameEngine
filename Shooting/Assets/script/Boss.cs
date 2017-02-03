using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    BossEnter bossEnter;
    enum State
    {
        Enter,      //入場。
        Battle,     //バトル。
    };
    State state = State.Enter;
	// Use this for initialization
	void Start () {
        bossEnter = gameObject.AddComponent<BossEnter>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.Enter:
                if (!bossEnter)
                {
                    state = State.Battle;
                }
                break;
            case State.Battle:
                Debug.Log("State.Battle");
                break;
        }
	}
}
