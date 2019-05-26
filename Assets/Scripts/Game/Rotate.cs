using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateDirection
{
    Forward,
    Up,
    Left,
}

public class Rotate : MonoBehaviour {
    [HideInInspector]
    public Vector3 myPos;

    [Header("自转")]
    public bool isSelfRotate;

    [Header("顺时针自转")]
    public bool isSelfRotatePositive;

    [Header("自转速度")]  
    [Range(1f, 100f)]
    public float speed;

    [Header("静止转向")]
    public Vector3 vector3;

    float t;
    [Header("漂浮方向")]
    public RotateDirection rotateDirection = RotateDirection.Forward;

    [Header("漂浮幅度")]
    [Range(-0.1f, 0.1f)]
    public float range = 0.1f;

    float hight;
    void Start ()
    {
        myPos = transform.position;
        if (rotateDirection == RotateDirection.Forward)
        {
            hight = transform.localPosition.z;
        }
        else if (rotateDirection == RotateDirection.Left)
        {
            hight = transform.localPosition.x;
        }
        else
        {
            hight = transform.localPosition.y;
        }
    }
	
	void Update ()
    {
        t += Time.deltaTime;
        if (rotateDirection == RotateDirection.Forward)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, hight + range * Mathf.Sin(t));
        }
        else if(rotateDirection == RotateDirection.Left)
        {
            transform.localPosition = new Vector3(hight + range * Mathf.Sin(t), transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, hight + range * Mathf.Sin(t), transform.localPosition.z);
        }
        if (isSelfRotate)
        {
            if (isSelfRotatePositive)
                transform.rotation = Quaternion.Euler(speed * t, speed * t, speed * t);
            else
                transform.rotation = Quaternion.Euler(speed * t, -speed * t, speed * t);           
        }     
    }

    public void SelfRotate(bool flag)
    {
        isSelfRotate = flag;
        transform.rotation = Quaternion.Euler(vector3.x, vector3.y, vector3.z);
    }
    public void SelfRotatePositive(bool flag)
    {
        isSelfRotatePositive = flag;
    }
}
