using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーのHPクラス
/// </summary>
public class PlayerHPScript : MonoBehaviour {

    private GameObject Player;
    private PlayerScript playerScript;
    private float HPparsent;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PlayerObj");
        playerScript = Player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        HPparsent = playerScript.m_fLife / playerScript.m_fMaxLife;
        GetComponent<Renderer>().material.color = Color.red;//Color.Lerp(Color.red, Color.green, HPparsent);
        GetComponent<Renderer>().material.SetColor("_MainTex", Color.red);
        GetComponent<Renderer>().material.SetFloat("_Cutoff", Mathf.Lerp(1.0f,0.001f,HPparsent));
	}
}
