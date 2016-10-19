using UnityEngine;
using System.Collections;
/// <summary>
/// オブジェクトを消すクラス
/// </summary>
public class DeleteScript : MonoBehaviour {
    [SerializeField]
    private float deleteTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, deleteTime);
	}
}
