using UnityEngine;
using System.Collections;

/// <summary>
/// このObjectを壊すとルート分岐できる（未実装）
/// </summary>
public class WoodBlockScript : MonoBehaviour {

    public GameObject pas;
    private int num = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            pas.SendMessage("PassCheckEnable",num);
            Destroy(this.gameObject);
        }
    }
}
