using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianGlobal : MonoBehaviour
{
    public GameObject go_1;
    public GameObject go_2;
    public OutLine go_3;
    public OutLine go_4;
    void Start ()
    {
        //GameManager._Instance.currentScenceID = ScenceID.Cell;
        if (GameManager._Instance.currentScenceID == ScenceID.Cell)
        {
            go_1.SetActive(false);
            go_2.SetActive(true);
            go_3.enabled = false;
            go_4.enabled = false;
        }
	}
	
	void Update ()
    {
		
	}
}
