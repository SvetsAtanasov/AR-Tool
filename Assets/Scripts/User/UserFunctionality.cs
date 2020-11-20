using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class UserFunctionality : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raymanager;
    [SerializeField] private ARReferencePointManager referencePointManager;
    [SerializeField] private CrosshairPlacement crosshairPlacement;
    [SerializeField] private ManipulateObj manipulateObj;


    void Start()
    {
        raymanager = FindObjectOfType<ARRaycastManager>();
        referencePointManager = FindObjectOfType<ARReferencePointManager>();
        crosshairPlacement = FindObjectOfType<CrosshairPlacement>();
        manipulateObj = GetComponent<ManipulateObj>();
    }

    void Update()
    {
        //crosshairPlacement.PlaceObject(raymanager, referencePointManager);
        //manipulateObj.SelectObject();
        //manipulateObj.Manipulators();
    }
}
