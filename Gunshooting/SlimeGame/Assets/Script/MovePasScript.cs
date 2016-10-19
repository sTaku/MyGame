using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの移動ルートクラス
/// </summary>
public class MovePasScript : MonoBehaviour {

    [System.Serializable]
    public class para
    {
        public GameObject nextPas;
        public float nextToa;
        public bool nextCheck;
    }

    public para[] Pass;

    private para thisPas;

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
        thisPas = getNextRoot();
	}

    public Vector3 getMyPosition()
    {
        return this.transform.position;
    }

    public GameObject getNextPas()
    {
        if (thisPas == null) return this.gameObject;
        return thisPas.nextPas;
    }

    public float getNextToa()
    {
        if (thisPas == null) return 0;
        return thisPas.nextToa;
    }

    public para getNextRoot()
    {
        for (int i = 0; i < Pass.Length; ++i)
        {
            if (Pass[i].nextCheck == true)
            {
                return Pass[i];
            }
        }
        return null;
    }

    //外部から道を通る条件から呼ぶ用
    void PassCheckEnable(int num)
    {
        Pass[num].nextCheck = true;
    }
}
