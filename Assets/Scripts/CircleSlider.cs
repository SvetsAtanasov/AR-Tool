using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleSlider : MonoBehaviour
{
    public EventTrigger eventTrigger;
    public Transform handle;
    public Image slider;

    Vector3 mousePos;

    private void Start()
    {
        eventTrigger = GetComponentInChildren<EventTrigger>();

    }

    public void OnHandleDrag()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        mousePos = Input.mousePosition;

        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Debug.Log(angle);
        Quaternion r = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

        float amount = ((360 - (angle + 90f)) % 360) / 360;

        handle.rotation = r;
        slider.fillAmount = amount;
    }
}
