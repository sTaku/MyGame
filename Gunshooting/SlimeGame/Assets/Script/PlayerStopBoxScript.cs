using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの移動を停止させるクラス
/// </summary>
public class PlayerStopBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.SendMessage("setIsGOGOGO", false);
        }
    }
}
