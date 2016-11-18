using UnityEngine;
using System.Collections;

public class Common : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnLevelWasLoaded(int level)
    {
        //フェードアウトコンポーネントを張り付ける。
        FadeOut fadeOut = gameObject.GetComponent<FadeOut>();
        if (fadeOut == null)
        {https://docs.unity3d.com/ja/current/ScriptReference/Microphone.html
            gameObject.AddComponent<FadeOut>();
        }
    }

}
