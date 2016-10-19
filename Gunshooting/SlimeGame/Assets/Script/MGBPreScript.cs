using UnityEngine;
using System.Collections;

/// <summary>
/// 銃(マシンガン)の描画クラス
/// </summary>
public class MGBPreScript : MonoBehaviour
{

    private GameObject Player;
    private PlayerScript playerScript;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("PlayerObj");
        playerScript = Player.GetComponent<PlayerScript>();
        if (playerScript.getGunType() != PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.getGunType() != PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<GUITexture>().enabled = true;
        }
    }
}
