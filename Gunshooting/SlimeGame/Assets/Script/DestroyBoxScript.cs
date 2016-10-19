using UnityEngine;
using System.Collections;

/// <summary>
/// 通ってないところのオブジェクトを消すクラス
/// </summary>
public class DestroyBoxScript : MonoBehaviour {

    public GameObject[] target;

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
            for (int i = 0; i < target.Length; i++)
            {
                Destroy(target[i]);
            }
        }
    }
}
