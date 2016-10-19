using UnityEngine;
using System.Collections;

public class waveUseScript : MonoBehaviour {
   
    private PlayerScript playerScript;
    private float previoushp;
    private float hp;

    private EnemyScript enemyScript;

    public GameObject pas;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("PlayerObj");
        playerScript = player.GetComponent<PlayerScript>();
        enemyScript = this.gameObject.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.IsWakeUp())
        {
            if (IsUse())
            {
                int i = 0;
                pas.SendMessage("PassCheckEnable", i);
            }
        }
    }

    bool IsUse()
    {
        if (playerScript.getGunType() == PlayerScript.GunType.RocketLauncher && Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}
