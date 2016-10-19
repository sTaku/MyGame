using UnityEngine;
using System.Collections;

/// <summary>
/// ゴールオブジェクトクラス
/// </summary>
public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        Application.LoadLevel(0);
    }
}
