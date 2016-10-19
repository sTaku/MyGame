using UnityEngine;
using System.Collections;

public class waveScript : MonoBehaviour {

    private int maxChildCount;
    private GameObject[] child;
    private bool check = false;
    public GameObject keyEnemy;
    public GameObject pas;

	// Use this for initialization
	void Start () {
        maxChildCount = transform.childCount;
        child = new GameObject[transform.childCount];
	}
	
	// Update is called once per frame
	void Update () {
        if (ChildCheck())
        {
            int num = 0;
            pas.SendMessage("PassCheckEnable", num);
        }
	}

    bool ChildCheck()
    {
        if (transform.childCount != (maxChildCount - 1)) return false;
        for (int i = 0; i < transform.childCount; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
            if (child[i] == keyEnemy)
            {
                check = true;
            }
        }
        if (check)
        {
            return false;
        }
        return true;
    }
}
