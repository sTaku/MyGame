using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーのクラス
/// </summary>
public class PlayerScript : MonoBehaviour
{

    public float m_fLife;
    public float m_fMaxLife; //マックスだけ設定.
    
    public DateTime startTime;
    public float second = 0;

    //ダメージ
    public GameObject crackObj;

    //銃の種類.
    public enum GunType
    {
        HandGun = 0,
        MachinGun = 1,
        RocketLauncher = 2
    }

    private GunType m_iGun;
    private GunType previosGun;
    private GameObject m_gGun;

    // Use this for initialization
    void Start()
    {
        m_fLife = m_fMaxLife;
        m_iGun = GunType.HandGun;
    }

    // Update is called once per frame
    void Update()
    { 
        m_fLife = Mathf.Clamp(m_fLife, 0.0f, m_fMaxLife);

        switch (m_iGun)
        {
            case GunType.HandGun:
                m_gGun = GameObject.Find("HandGunObject");
                break;
            case GunType.MachinGun:
                m_gGun = GameObject.Find("MachineGunObject");
                break;
            case GunType.RocketLauncher:
                m_gGun = GameObject.Find("LauncherObject");
                break;
        }

        GameOverCheck();    //死んだか

        ShotCheck();        //撃つボタンを押したか
        ReloadCheck();      //リロードするボタンを押したか

        previosGun = m_iGun;
        WeaponChenge();     //マウスホイールを回したか
    }

    /// <summary>
    /// 銃を撃ったか確認するもの
    /// </summary>
    void ShotCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_gGun.SendMessage("Shot");
            return;
        }
        else if (Input.GetMouseButton(0) && m_iGun == GunType.MachinGun)
        {
            m_gGun.SendMessage("Shot");
        }
    }
    /// <summary>
    /// リロード
    /// </summary>
    void ReloadCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            m_gGun.SendMessage("Reload");
        }
    }
    /// <summary>
    /// 銃の種類を変更する
    /// </summary>
    void WeaponChenge()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_iGun++;
            if (m_iGun > GunType.RocketLauncher)
            {
                m_iGun = GunType.HandGun;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            m_iGun--;
            if (m_iGun < GunType.HandGun)
            {
                m_iGun = GunType.RocketLauncher;
            }
        }
    }
    /// <summary>
    /// 銃の種類を取得
    /// </summary>
    /// <returns></returns>
    public GunType getGunType()
    {
        return m_iGun;
    }


    public bool IsChangeGun()
    {
        return m_iGun != previosGun;
    }

    public void Damage(float damage)
    {
        m_fLife -= damage;
        Instantiate(crackObj, this.transform.position + new Vector3(0.0f, 0.0f, 1.5f), Quaternion.identity);
    }

    void GameOverCheck()
    {
        if (m_fLife <= 0)
        {
            Application.LoadLevel(0);
        }
    }
}