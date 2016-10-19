using UnityEngine;
using System.Collections;

public class RotationBoxScript : MonoBehaviour {

    public Vector3 degree;

    public float time;

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
            collider.transform.SendMessage("setDegree", degree);
            collider.transform.SendMessage("setTime", time);
        }
    }
}
