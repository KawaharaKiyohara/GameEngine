using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームマネージャークラス。
/// </summary>
public class GameManager : MonoBehaviour {
    public bool isGameOver;
    public GameObject GameBGM;
    int Count = 0;
    // Use this for initialization
    void Start()
    {
        Instantiate(GameBGM);
    }
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            if (Count == 60)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                Count++;
            }
        }
	}
}