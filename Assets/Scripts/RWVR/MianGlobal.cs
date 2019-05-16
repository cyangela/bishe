using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianGlobal : MonoBehaviour
{
    public GameObject go_1;
    public GameObject go_2;
    void Start ()
    {
        GameManager._Instance.currentScenceID = ScenceID.Cell;
        if (GameManager._Instance.currentScenceID == ScenceID.Cell)
        {
            Debug.Log("-----this is cell sence");
            go_1.SetActive(false);
            go_2.SetActive(true);
        }
	}
	
	void Update ()
    {
		
	}
}
