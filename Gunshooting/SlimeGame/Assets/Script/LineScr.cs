using UnityEngine;
using System.Collections;

public class LineScr : MonoBehaviour {

    private MachineGunScript machineGunScr;

    private Quaternion lineQuant;

	// Use this for initialization
	void Start () {
        var machineGun = GameObject.Find("MachineGunObject");
        machineGunScr = machineGun.GetComponent<MachineGunScript>();
	}
	
	// Update is called once per frame
	void Update () {

        var pos = machineGunScr.transform.position;
        pos.y += 0.8f;
        this.gameObject.transform.position = pos;
        this.gameObject.transform.rotation = machineGunScr.transform.rotation;
        this.gameObject.transform.Rotate(90.0f, 0.0f, 0.0f);

	}
}
