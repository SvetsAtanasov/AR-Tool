using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ManipulateObj : MonoBehaviour
{
    public const float widthRotation = 0.1f;
    public const float touchRotationMin = 0.1f;

    [SerializeField] private Camera cam;
    [SerializeField] public Transform selectedObject;

    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private Vector2 startVec = Vector2.zero;

    [SerializeField] private bool isRotating = false;

    [SerializeField] private bool btnMoveClicked = false;
    [SerializeField] private bool btnScaleClicked = false;
    [SerializeField] private bool btnRotateClicked = false;
    [SerializeField] private bool btnDeleteClicked = false;

    void Start()
    {
        cam = Camera.main;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        SelectObject();
        TouchBasedInteraction();
    }

    public void TouchBasedInteraction()
    {
        if (Input.touchCount == 1 && btnMoveClicked)
        {
            MoveObject();
        }

        else if (Input.touchCount == 2 && btnRotateClicked)
        {
            RotateObject();
        }

        else if (Input.touchCount == 2 && btnScaleClicked)
        {
            ScaleObject();
        }

    }

    public void MoveBtnIsClicked()
    {
        btnMoveClicked = true;

        if (btnMoveClicked)
        {
            btnRotateClicked = false;
            btnScaleClicked = false;
        }
    }

    public void RotateBtnIsClicked()
    {
        btnRotateClicked = true;

        if (btnRotateClicked)
        {
            btnMoveClicked = false;
            btnScaleClicked = false;
        }
    }

    public void ScaleBtnIsClicked()
    {
        btnScaleClicked = true;

        if (btnScaleClicked)
        {
            btnMoveClicked = false;
            btnRotateClicked = false;
        }
    }

    public void DeleteBtnIsClicked()
    {
        btnDeleteClicked = true;
    }

    public void SelectObject()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5f)));

            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return;
                }

                RaycastHit hit = new RaycastHit();
                Ray ray = cam.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, 100f, clickableLayer))
                {
                    if (hit.collider != null)
                    {
                        selectedObject = hit.transform;
                    }
                }

                else
                {
                    selectedObject = null;
                }
            }
        }
    }

    public void MoveObject()
    {
        if (!selectedObject)
            return;

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                selectedObject.transform.position = new Vector3(selectedObject.transform.position.x + touch.deltaPosition.x * 0.05f * Time.deltaTime, selectedObject.transform.position.y, selectedObject.transform.position.z + touch.deltaPosition.y * 0.05f * Time.deltaTime);
            }
        }
    }

    void ScaleObject()
    {
        if (!selectedObject)
            return;

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            float pinchAmount = deltaMagnitudeDiff * 0.02f * Time.deltaTime;


            selectedObject.transform.localScale += new Vector3(pinchAmount, pinchAmount, pinchAmount);
        }
    }

    void RotateObject()
    {
        if (!selectedObject)
            return;

        if (Input.touchCount == 2)
        {
            if (!isRotating)
            {
                startVec = Input.touches[1].position - Input.touches[0].position;
                isRotating = startVec.sqrMagnitude > widthRotation;
            }

            else
            {
                Vector2 currentVec = Input.touches[1].position - Input.touches[0].position;
                float angleOffset = Vector2.Angle(startVec, currentVec);

                if (angleOffset > touchRotationMin)
                {
                    Vector3 LR = Vector3.Cross(startVec, currentVec);

                    if (LR.z > 0f)
                    {
                        selectedObject.transform.rotation = Quaternion.Euler(0f, 0f - angleOffset, 0f);
                    }

                    else if (LR.z < 0f)
                    {
                        selectedObject.transform.rotation = Quaternion.Euler(0f, 0f + angleOffset, 0f);
                    }
                }
            }
        }
    }
}