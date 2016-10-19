using UnityEngine;
using System.Collections;

/// <summary>
/// 銃(ロケットランチャー)クラス
/// </summary>

    //未実装のためデバッグ用
public class RocketLauncherScript : MonoBehaviour
{

    //銃切り替え用
    private PlayerScript playerScr;

    //弾描画用オブジェクト
    public GameObject LauncherBullet;

    //カーソルオブジェクト
    private GameObject cursolObject;
    private CursolObjectScript cursolScript;

    //レーザーポインター関連
    //private GameObject point;

    //弾関連
    private int bulletNum; //現在の装填数
    public int maxBulletNum; //装填可能弾数
    public int nowRemenberBullet; //現在所持弾数
    public int maxRemenberBullet; //最大所持弾数
    private int bulletCount = 0;
    public GameObject Efe_bulletParticle;

    //弾丸描画関連

    //リロード関連.
    public float reloadTime;
    private bool reloadFlg = false;
    private float reloadTimer;
    private Vector3 gunRote;
    public GameObject reloadAlert;

    public Vector2 kickMin;
    public Vector2 kickMax;

    // Use this for initialization
    void Start()
    {

        var Player = GameObject.Find("PlayerObj");
        playerScr = Player.GetComponent<PlayerScript>();
        if (playerScr.getGunType() != PlayerScript.GunType.RocketLauncher)
        {
            transform.localPosition = new Vector3(1.0f, -10.0f, 0.3f);
        }

        cursolObject = GameObject.Find("CursolObject");
        cursolScript = cursolObject.GetComponent<CursolObjectScript>();

        bulletNum = maxBulletNum;

        reloadTimer = 0.0f;

        //point = GameObject.Find("PointKun");
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(cursolScript.cursolPosition);
        RaycastHit hit;
        int layerMask = 1 << 20;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMask))
        {
            Vector3 hitPosition = hit.point;
            transform.LookAt(hitPosition);
        }



        if (playerScr.getGunType() == PlayerScript.GunType.RocketLauncher && playerScr.IsChangeGun())
        {
            transform.localPosition = new Vector3(1.0f, -0.8f, 0.3f);
        }
        else if (playerScr.getGunType() != PlayerScript.GunType.RocketLauncher && playerScr.IsChangeGun())
        {
            transform.rotation = Quaternion.identity;
            transform.localPosition = new Vector3(1.0f, -5.0f, 0.3f);
        }
    }

    void LateUpdate()
    {
        playReload();
    }

    /// <summary>
    /// 撃った時
    /// </summary>
    void Shot()
    {
        //弾がある　又は　リロードをしていない
        if (bulletNum > 0 && !reloadFlg)
        {
            Instantiate(LauncherBullet, transform.position, transform.rotation);
            Instantiate(Efe_bulletParticle, transform.position, transform.rotation);
            bulletNum--;
            BulletRem(bulletNum);
            cursolScript.SendMessage("kick", new Vector2(Random.Range(kickMin.x, kickMax.x), Random.Range(kickMin.y, kickMax.y)));
        }
        if (bulletNum == 0)
        {
            Instantiate(reloadAlert);
        }
    }

    /// <summary>
    /// 装填数で(描画)を減らす
    /// </summary>
    /// <param name="nowBulletCount"></param>
    public void BulletRem(int nowBulletCount)
    {
        // 現在の装填数に合わせて弾画像を消す
    }

   /// <summary>
   /// 装填数で弾(描画)を増やす
   /// </summary>
   /// <param name="nowBulletCount"></param>
    public void BulletReload(int nowBulletCount)
    {
        // リロード時、現在の装填数に合わせて弾画像を生成
    }

    /// <summary>
    /// リロード
    /// </summary>
    void Reload()
    {
        //弾が一発でも減っていたら
        if (bulletNum < maxBulletNum && nowRemenberBullet > 0)
        {
            //リロードフラグON
            reloadFlg = true;
            bulletCount = nowRemenberBullet;
        }
        //--------------------------------------------------------------------
    }

    void playReload()
    {
        if (!reloadFlg) return;

        //リロード時装填可能数に現在の装填数に達していない:毎フレームに1発
        if (bulletNum < maxBulletNum && bulletCount > 0)
        {
            bulletNum++;
            bulletCount--;
            reloadTimer += Time.deltaTime;
            BulletReload(bulletNum);
        }
        //装填可能数に現在の装填数に達している　かつ　リロード時間終了
        else if (reloadTimer >= reloadTime)
        {
            //リロードフラグOFF
            reloadFlg = false;
            //リロード時間を初期化
            reloadTimer = 0.0f;
            nowRemenberBullet = bulletCount;
        }
        //リロード時間中　かつ　装填数MAX
        else
        {
            reloadTimer += Time.deltaTime;
        }

        Quaternion gunQuant = transform.rotation;
        if (reloadTimer <= 0.5f)
        {
            gunRote = Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.2f, 0.0f, 0.0f), reloadTimer * 2);
            gunQuant.Set(
                gunQuant.x + gunRote.x,
                gunQuant.y,
                gunQuant.z,
                gunQuant.w
            );
            this.gameObject.transform.localRotation = gunQuant;
        }
        else if (reloadTimer <= 2.0f)
        {
            gunQuant.Set(
                gunQuant.x + 1.2f,
                gunQuant.y,
                gunQuant.z,
                gunQuant.w
            );
            this.gameObject.transform.localRotation = gunQuant;
        }
        else
        {
            gunRote = Vector3.Lerp(new Vector3(1.2f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), (reloadTimer - 2.0f) * 2);
            gunQuant.Set(
                gunQuant.x + gunRote.x,
                gunQuant.y,
                gunQuant.z,
                gunQuant.w
            );
            this.gameObject.transform.localRotation = gunQuant;
        }
    }
}
