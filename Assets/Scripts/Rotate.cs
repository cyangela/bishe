using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Transform tf1;
    public Transform tf2;
    float h;
    float t;

	void Start ()
    {
        h = tf1.position.y;
    }
	
	void Update ()
    {
        t += Time.deltaTime;
        tf1.transform.RotateAround(transform.position, transform.up, 40 * Time.deltaTime);
        tf1.transform.position = new Vector3(tf1.transform.position.x, h + 0.15f * Mathf.Sin(t), tf1.transform.position.z);
        tf1.rotation = Quaternion.Euler(0, 0, 0);
        tf2.transform.RotateAround(transform.position, transform.up, 40 * Time.deltaTime);
        tf2.rotation = Quaternion.Euler(0, 0, 0);
        tf2.transform.position = new Vector3(tf2.transform.position.x, h + 0.15f * -Mathf.Sin(t), tf2.transform.position.z);
    }
}
