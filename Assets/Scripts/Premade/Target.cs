using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [HideInInspector]
    public string num;
    private void Start()
    {
        num = transform.parent.name;
    }
}
