using UnityEngine;
using System.Collections;

/// <summary>
/// 弾のUIを切り替えるクラス
/// </summary>
public class BulletPreScript : MonoBehaviour {

    private GameObject Player;
    private PlayerScript playerScript;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PlayerObj");
        playerScript = Player.GetComponent<PlayerScript>();
        if (playerScript.getGunType() != PlayerScript.GunType.HandGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.HandGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerScript.getGunType() != PlayerScript.GunType.HandGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.HandGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = true;
        }
	}
}
