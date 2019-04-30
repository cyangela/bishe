using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Tools : MonoBehaviour {

    public static Tools _Instance = null;

    [SerializeField]
    GameObject LeftController_UI;
    [SerializeField]
    GameObject RightController_UI;
    [SerializeField]
    GameObject LeftController;
    [SerializeField]
    GameObject RightController;

    private void Awake()
    {
        _Instance = this;
    }

    public void SetUIController()
    {
        LeftController.SetActive(false);
        RightController.SetActive(false);
        LeftController_UI.SetActive(true);
        RightController_UI.SetActive(true);
        VRTK_SDKManager.instance.scriptAliasLeftController = LeftController_UI;
        VRTK_SDKManager.instance.scriptAliasRightController = RightController_UI;
    }

    public void SetController()
    {
        LeftController_UI.SetActive(false);
        RightController_UI.SetActive(false);
        LeftController.SetActive(true);
        RightController.SetActive(true);
        VRTK_SDKManager.instance.scriptAliasLeftController = LeftController;
        VRTK_SDKManager.instance.scriptAliasRightController = RightController;
    }
}
