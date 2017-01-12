using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームマネージャークラス。
/// </summary>
public class GameManager : MonoBehaviour {
    public bool isGameOver;
    public GameObject GameBGM;
   
    // Use this for initialization
    void Start()
    {
        Instantiate(GameBGM);
    }
	// Update is called once per frame
	void Update () {
	}
}