using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleSlider : MonoBehaviour
{
    //public EventTrigger eventTrigger;
    //public GameObject handle;
    //public Image slider;

    public Image colorPreview;
    public Image colorWheel;

    private Color color;
    private void Start()
    {
        //eventTrigger = GetComponentInChildren<EventTrigger>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Texture2D tex = colorWheel.sprite.texture;

            Rect r = colorWheel.rectTransform.rect;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(colorWheel.rectTransform, Input.mousePosition, null, out localPoint);

            int px = Mathf.Clamp(0, (int)(((localPoint.x - r.x) * tex.width) / r.width), tex.width);
            int py = Mathf.Clamp(0, (int)(((localPoint.y - r.y) * tex.height) / r.height), tex.height);

            Color col = tex.GetPixel(px, py);

            color = new Color(col.r, col.g, col.b);
            colorPreview.color = color;
            Debug.Log(col);
        }
    }

    //public void OnHandleDrag()
    //{
    //    Screen.sleepTimeout = SleepTimeout.NeverSleep;
    //    mousePos = Input.mousePosition;

    //    Vector2 dir = mousePos - handle.position;
    //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    //    Debug.Log(angle);
    //    Quaternion r = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

    //    float amount = ((360 - (angle + 90f)) % 360) / 360;

    //    handle.rotation = r;
    //    slider.fillAmount = amount;
    //}
}
