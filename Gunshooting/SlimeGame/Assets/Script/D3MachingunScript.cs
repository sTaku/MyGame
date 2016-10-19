using UnityEngine;
using System.Collections;

/// <summary>
/// 銃の切り替えのクラス2
/// </summary>
public class D3MachingunScript : MonoBehaviour {

    private GameObject player;
    private PlayerScript pscript;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerObj");
        pscript = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pscript.getGunType() != PlayerScript.GunType.MachinGun) gameObject.GetComponent<Renderer>().enabled = false;
        
        if (pscript.getGunType() == PlayerScript.GunType.MachinGun) gameObject.GetComponent<Renderer>().enabled = true;
	}
}
