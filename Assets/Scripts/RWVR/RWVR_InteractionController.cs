using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class RWVR_InteractionController : MonoBehaviour {
    public Transform snapColliderOrigin;
    public GameObject ControllerModel;

    [HideInInspector]
    public Vector3 velocity; 
    [HideInInspector]
    public Vector3 angularVelocity; 

    private RWVR_InteractionObject objectBeingInteractedWith; 

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    public RWVR_InteractionObject InteractionObject
    {
        get { return objectBeingInteractedWith; }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    /// <summary>
    /// 检测透明球体碰到的物体
    /// </summary>
    private void CheckForInteractionObject()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(snapColliderOrigin.position, snapColliderOrigin.lossyScale.x / 2f);

        foreach (Collider overlappedCollider in overlappedColliders)
        {
            if (overlappedCollider.CompareTag("InteractionObject") && overlappedCollider.GetComponent<RWVR_InteractionObject>().IsFree())
            {
                objectBeingInteractedWith = overlappedCollider.GetComponent<RWVR_InteractionObject>();
                objectBeingInteractedWith.OnTriggerWasPressed(this);
                return;
            }
        }
    }

    void Update()
    {

        if (Controller.GetHairTriggerDown())
        {
            CheckForInteractionObject();
        }

        if (Controller.GetHairTrigger())
        {
            if (objectBeingInteractedWith)
            {
                objectBeingInteractedWith.OnTriggerIsBeingPressed(this);
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectBeingInteractedWith)
            {
                objectBeingInteractedWith.OnTriggerWasReleased(this);
                objectBeingInteractedWith = null;
            }
        }

		//跳转显微镜场景
        if (GameManager._Instance.isCanToMicroscope)
        {
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis0))
            {
                MyTween myTween = new MyTween();
                myTween.OnHalfComplete(()=>{
                    GameManager._Instance.isCanToMicroscope = false;
                    GameManager._Instance.currentScenceID = ScenceID.Microscope;
                    SceneManager.LoadScene("Microscope");
                });
                ScreenFade.Instance.SceneFade(myTween);
            }
        }

		//跳转实验室场景
        if (GameManager._Instance.isCanTo2019)
        {
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis0))
            {
                MyTween myTween = new MyTween();
                myTween.OnHalfComplete(() => {
                    GameManager._Instance.isCanTo2019 = false;
                    GameManager._Instance.currentScenceID = ScenceID.Mian;
                    SceneManager.LoadScene("2019");
                });
                ScreenFade.Instance.SceneFade(myTween);
            }
        }

		if (GameManager._Instance.isMicroscope)
		{
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Axis0))
            {
			    GameManager._Instance.isMicroscope = false;
			    Microscope_Manager._Instance.Play();
            }
		}
    }

    private void UpdateVelocity()
    {
        velocity = Controller.velocity;
        angularVelocity = Controller.angularVelocity;
    }

    void FixedUpdate()
    {
        UpdateVelocity();
    }

    public void HideControllerModel()
    {
        ControllerModel.SetActive(false);
    }

    public void ShowControllerModel()
    {
        ControllerModel.SetActive(true);
    }

    public void Vibrate(ushort strength)
    {
        Controller.TriggerHapticPulse(strength);
    }

    public void SwitchInteractionObjectTo(RWVR_InteractionObject interactionObject)
    {
        objectBeingInteractedWith = interactionObject;
        objectBeingInteractedWith.OnTriggerWasPressed(this);
    }
}
