using UnityEngine;
using System.Collections;

public class wavedamageScript : MonoBehaviour {

    private PlayerScript playerScript;
    private float previoushp;
    private float hp;

    private EnemyScript enemyScript;
    private int k =0;

    public GameObject pas;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("PlayerObj");
        playerScript = player.GetComponent<PlayerScript>();
        enemyScript = this.gameObject.GetComponent<EnemyScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyScript.IsWakeUp())
        {
            if (k == 0)
            {
                hp = playerScript.m_fLife;
                previoushp = hp;
                k++;
            }
            if (IsDamage())
            {
                int i = 0;
                pas.SendMessage("PassCheckEnable",i);
            }
        }
	}

    bool IsDamage()
    {
        previoushp = hp;
        hp = playerScript.m_fLife;
        return hp != previoushp; 
    }
}
