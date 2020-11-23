using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class CrosshairPlacement : MonoBehaviour
{
    public GameObject pointerObj;
    public GameObject placedObject;

    public Text refpointCount;

    private ManipulateObj manipulate;

    [SerializeField] private ARRaycastManager raymanager;
    [SerializeField] private ARReferencePointManager referencePointManager;

    [SerializeField] private List<ARReferencePoint> referencePoints = new List<ARReferencePoint>();
    [SerializeField] private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raymanager = FindObjectOfType<ARRaycastManager>();
        referencePointManager = FindObjectOfType<ARReferencePointManager>();
        manipulate = FindObjectOfType<ManipulateObj>();
    }

    private void Update()
    {
        PlaceObject();
    }

    public void PlaceObject()
    {
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }

        if (raymanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon) && Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Pose pose = hits[0].pose;

            if (touch.phase == TouchPhase.Began)
            {
                ARReferencePoint referencePoint = referencePointManager.AddReferencePoint(pose);

                if (referencePoint == null)
                {
                    Debug.Log("Something Went Wrong");
                }

                else if (referencePointManager.referencePointPrefab != null)
                {
                    Instantiate(placedObject, pose.position, Quaternion.identity);
                    referencePoints.Add(referencePoint);
                    refpointCount.text = $"Referencepoint Count: {referencePoints.Count}";
                }
            }
        }
    }

    public void GetPrefab(ItemData itemData)
    {
        placedObject = itemData.itemPrefab;
    }
}