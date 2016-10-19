using UnityEngine;
using System.Collections;

/// <summary>
/// 銃(マシンガン)の弾を描画するクラス
/// </summary>
public class MachineGunBulletPre_3DScr : MonoBehaviour
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
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.getGunType() != PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (playerScript.getGunType() == PlayerScript.GunType.MachinGun)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
