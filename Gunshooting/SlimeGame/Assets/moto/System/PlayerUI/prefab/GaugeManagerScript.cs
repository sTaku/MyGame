using UnityEngine;
using System.Collections;

public class GaugeManagerScript : MonoBehaviour {
  
    [SerializeField]
    private GameObject HPbar; //一目盛り分のHPバー.
    private GameObject[] HPbars = new GameObject[360];

    private GameObject player;
    private PlayerScript playerScript;

    private float playerHP;
    private float playerCutIn;

    public Color HPcolor;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("PlayerObj");
        playerScript = player.GetComponent<PlayerScript>();

        for (var i = 0; i < 360; i++)
        {
            //生成
            HPbars[i] = (GameObject)Instantiate(HPbar, this.transform.position + new Vector3(0.0f, 2.217407f,0.0f), Quaternion.identity);
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, i);
            HPbars[i].transform.parent = this.transform;
        }

	}
	
	// Update is called once per frame
	void Update () {
        playerHP = playerScript.m_fLife;

        HPmanager();
	}

    void HPmanager()
    {
        float HPparsent = playerHP / playerScript.m_fMaxLife; //残りHPの割合.

        float HPbarParsent = 360 * HPparsent; //３６０度×パーセンテージ.

        HPcolor = Color.Lerp(Color.red, Color.green, HPparsent);

        if (HPbarParsent <= 0) HPbarParsent = 0;

        for (var i = 0; i < HPbarParsent; i++)  //残っているHP分描画する.
        {
            HPbars[i].GetComponent<Renderer>().enabled = true;
            HPbars[i].GetComponent<Renderer>().sharedMaterial.color = HPcolor;
        }

        for (var i = (int)HPbarParsent; i < 360; i++)  //減っている分透明にする.
        {
            HPbars[i].GetComponent<Renderer>().enabled = false;
        }
    }

    void MaterialManager()
    {

    }
}
