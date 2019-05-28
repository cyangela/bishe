using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWVR_Cell : RWVR_InteractionObject {

    public bool hideControllerModel;

    public bool enable;

    public Transform parent;

    private Rigidbody rb;

    private void Start()
    {
        
    }

    public override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    private void ConnectToController(RWVR_InteractionController controller)
    {
        cachedTransform.SetParent(controller.transform);
    }

    private void ReleaseFromController(RWVR_InteractionController controller)
    {
        cachedTransform.SetParent(parent);
    }

    public override void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        if (enable)
        {
            base.OnTriggerWasPressed(controller);

            if (hideControllerModel)
            {
                controller.HideControllerModel();
            }

            ConnectToController(controller);
            CancelRotate();
        }
    }

    public override void OnTriggerWasReleased(RWVR_InteractionController controller)
    {
        if (enable)
        {
            base.OnTriggerWasReleased(controller);

            if (hideControllerModel)
            {
                controller.ShowControllerModel();
            }

            ReleaseFromController(controller);
            ActivateRotate();
        }
    }

    private void CancelRotate()
    {
        if (GetComponent<Rotate>())
        {
            GetComponent<Rotate>().enabled = false;
        }
    }

    private void ActivateRotate()
    {
        if (GetComponent<Rotate>())
        {
            transform.position = GetComponent<Rotate>().myPos;
            transform.rotation = GetComponent<Rotate>().myRot;
            GetComponent<Rotate>().enabled = true;
        }
    }
}

