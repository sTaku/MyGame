using UnityEngine;
using System.Collections;


/// <summary>
/// ゲーム終了クラス
/// </summary>
public class GameQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameEnd();
	}

    void GameEnd()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
