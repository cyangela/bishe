
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RWVR_UIController : RWVR_InteractionObject
{

    private void Start()
    {
        Debug.Log(GetComponent<Button>().onClick.GetPersistentMethodName(0));
    }
    public override void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        GetComponent<Button>().Select();
    }
}
