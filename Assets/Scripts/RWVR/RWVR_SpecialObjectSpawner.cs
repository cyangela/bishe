using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RWVR_SpecialObjectSpawner : RWVR_InteractionObject
{
    public GameObject arrowPrefab;
    public List<GameObject> randomPrefabs = new List<GameObject>();

    public override void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        base.OnTriggerWasPressed(controller);

        if (RWVR_ControllerManager.Instance.AnyControllerIsInteractingWith<Bow>())
        {
            SpawnObjectInHand(arrowPrefab, controller);
        }
        else
        {
            SpawnObjectInHand(randomPrefabs[UnityEngine.Random.Range(0, randomPrefabs.Count)], controller);
        }
    }

    private void SpawnObjectInHand(GameObject prefab, RWVR_InteractionController controller)
    {
        GameObject spawnedObject = Instantiate(prefab, controller.snapColliderOrigin.position, controller.transform.rotation);
        controller.SwitchInteractionObjectTo(spawnedObject.GetComponent<RWVR_InteractionObject>());
        OnTriggerWasReleased(controller);
    }
}
