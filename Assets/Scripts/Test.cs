using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Test : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;

    public Canvas canvas;

    void Start ()
    {
        if (canvas)
        {
            if (canvas.gameObject.activeSelf)
            {
                Tools._Instance.SetUIController();
            }
            else
            {
                Tools._Instance.SetController();
            }
        }
    }
	
	void Update ()
    {
		
	}
    private void OnEnable()
    {
        controllerEvents = (controllerEvents == null ? GetComponent<VRTK_ControllerEvents>() : controllerEvents);
        if (controllerEvents == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }



        //Setup controller event listeners
        controllerEvents.TriggerPressed += DoTriggerPressed;
        controllerEvents.TriggerReleased += DoTriggerReleased;
        controllerEvents.TriggerTouchStart += DoTriggerTouchStart;
        controllerEvents.TriggerTouchEnd += DoTriggerTouchEnd;
        controllerEvents.TriggerHairlineStart += DoTriggerHairlineStart;
        controllerEvents.TriggerHairlineEnd += DoTriggerHairlineEnd;
        controllerEvents.TriggerClicked += DoTriggerClicked;
        controllerEvents.TriggerUnclicked += DoTriggerUnclicked;
        controllerEvents.TriggerAxisChanged += DoTriggerAxisChanged;
        controllerEvents.TriggerSenseAxisChanged += DoTriggerSenseAxisChanged;

        controllerEvents.GripPressed += DoGripPressed;
        controllerEvents.GripReleased += DoGripReleased;
        controllerEvents.GripTouchStart += DoGripTouchStart;
        controllerEvents.GripTouchEnd += DoGripTouchEnd;
        controllerEvents.GripHairlineStart += DoGripHairlineStart;
        controllerEvents.GripHairlineEnd += DoGripHairlineEnd;
        controllerEvents.GripClicked += DoGripClicked;
        controllerEvents.GripUnclicked += DoGripUnclicked;
        controllerEvents.GripAxisChanged += DoGripAxisChanged;

        controllerEvents.TouchpadPressed += DoTouchpadPressed;
        controllerEvents.TouchpadReleased += DoTouchpadReleased;
        controllerEvents.TouchpadTouchStart += DoTouchpadTouchStart;
        controllerEvents.TouchpadTouchEnd += DoTouchpadTouchEnd;
        controllerEvents.TouchpadAxisChanged += DoTouchpadAxisChanged;
        controllerEvents.TouchpadTwoPressed += DoTouchpadTwoPressed;
        controllerEvents.TouchpadTwoReleased += DoTouchpadTwoReleased;
        controllerEvents.TouchpadTwoTouchStart += DoTouchpadTwoTouchStart;
        controllerEvents.TouchpadTwoTouchEnd += DoTouchpadTwoTouchEnd;
        controllerEvents.TouchpadTwoAxisChanged += DoTouchpadTwoAxisChanged;
        controllerEvents.TouchpadSenseAxisChanged += DoTouchpadSenseAxisChanged;

        controllerEvents.ButtonOnePressed += DoButtonOnePressed;
        controllerEvents.ButtonOneReleased += DoButtonOneReleased;
        controllerEvents.ButtonOneTouchStart += DoButtonOneTouchStart;
        controllerEvents.ButtonOneTouchEnd += DoButtonOneTouchEnd;

        controllerEvents.ButtonTwoPressed += DoButtonTwoPressed;
        controllerEvents.ButtonTwoReleased += DoButtonTwoReleased;
        controllerEvents.ButtonTwoTouchStart += DoButtonTwoTouchStart;
        controllerEvents.ButtonTwoTouchEnd += DoButtonTwoTouchEnd;

        controllerEvents.StartMenuPressed += DoStartMenuPressed;
        controllerEvents.StartMenuReleased += DoStartMenuReleased;

        controllerEvents.ControllerEnabled += DoControllerEnabled;
        controllerEvents.ControllerDisabled += DoControllerDisabled;
        controllerEvents.ControllerIndexChanged += DoControllerIndexChanged;

        controllerEvents.MiddleFingerSenseAxisChanged += DoMiddleFingerSenseAxisChanged;
        controllerEvents.RingFingerSenseAxisChanged += DoRingFingerSenseAxisChanged;
        controllerEvents.PinkyFingerSenseAxisChanged += DoPinkyFingerSenseAxisChanged;
    }
    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerHairlineStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerHairlineEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("111");
        if (canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(false);
            canvas.GetComponent<VRTK_UICanvas>().enabled = false;
            
            Tools._Instance.SetController();
        }
        else
        {
            canvas.gameObject.SetActive(true);
            canvas.GetComponent<VRTK_UICanvas>().enabled = true;
            Tools._Instance.SetUIController();
        }
    }

    private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTriggerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripHairlineStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripHairlineEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripClicked(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripUnclicked(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoGripAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTwoPressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTwoReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTwoTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTwoTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadTwoAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoTouchpadSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonOnePressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonOneReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonOneTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonOneTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonTwoTouchStart(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoButtonTwoTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoStartMenuPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("111");
        if (canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(false);
            Tools._Instance.SetUIController();
        }
        else
        {
            canvas.gameObject.SetActive(true);
            Tools._Instance.SetController();
        }
        
    }

    private void DoStartMenuReleased(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoControllerEnabled(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoControllerDisabled(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoControllerIndexChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoMiddleFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }

    private void DoRingFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
 
    }

    private void DoPinkyFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

    }
}
