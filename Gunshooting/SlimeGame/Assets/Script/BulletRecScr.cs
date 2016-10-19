using UnityEngine;
using System.Collections;

public class BulletRecScr : MonoBehaviour {

    private MachineGunScript machineGunScr;

    // Use this for initialization
    void Start()
    {
        var machineGun = GameObject.Find("MachineGunObject");
        machineGunScr = machineGun.GetComponent<MachineGunScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet" || collision.transform.tag == "MBullet")
        {
            machineGunScr.nowRemenberBullet += machineGunScr.maxBulletNum;
            if (machineGunScr.nowRemenberBullet > machineGunScr.maxRemenberBullet) machineGunScr.nowRemenberBullet = machineGunScr.maxRemenberBullet;
            Destroy(this.gameObject);
        }
    }
}
