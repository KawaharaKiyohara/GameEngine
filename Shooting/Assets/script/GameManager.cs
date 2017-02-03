using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// ゲームマネージャークラス。
/// </summary>
public class GameManager : MonoBehaviour {
    public bool isGameOver;
    public GameObject GameBGM;
    public Score score;
    int Count = 0;
    // Use this for initialization
    void Start()
    {
        Instantiate(GameBGM);
        score = GameObject.Find("Score").GetComponent<Score>();
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
        //
        if(score.point > 1000)
        {
            //スコアのポイントが1000より大きくなったら

            //ここでボスのブレハブをロードする。
            GameObject new
        }
	}
}