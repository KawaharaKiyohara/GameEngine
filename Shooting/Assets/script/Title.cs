using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    enum Step
    {
        WaitPressAnyKey,
        WaitFadeOut,
    };
    public GameObject goCommon;
    public GameObject goCommonCanvas;
    Step step = Step.WaitPressAnyKey;

	// Use this for initialization
	void Start () {
        goCommon = GameObject.Find("Common");
        DontDestroyOnLoad(goCommon);
    }
	
	// Update is called once per frame
	void Update () {
        switch (step) {
            case Step.WaitPressAnyKey:
                if (Input.GetButton("Fire1"))
                {
                    goCommon.AddComponent<FadeIn>();

                    step = Step.WaitFadeOut;
                }
                break;
            case Step.WaitFadeOut:
                if(goCommon.GetComponent<FadeIn>() == null)
                {
                    //フェードインが終わった。
                    SceneManager.LoadScene("game");
                }
                break;
        }
       
	}
}
