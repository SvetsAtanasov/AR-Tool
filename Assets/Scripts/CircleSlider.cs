using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleSlider : MonoBehaviour
{
    public Image colorPreview;
    public Image colorWheel;

    [SerializeField] private ManipulateObj manipulateObj;

    private Color color;
    private void Start()
    {
        manipulateObj = FindObjectOfType<ManipulateObj>();
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Texture2D tex = colorWheel.sprite.texture;

                    Rect r = colorWheel.rectTransform.rect;
                    Vector2 localPoint;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(colorWheel.rectTransform, touch.position, null, out localPoint);

                    int px = Mathf.Clamp(0, (int)(((localPoint.x - r.x) * tex.width) / r.width), tex.width);
                    int py = Mathf.Clamp(0, (int)(((localPoint.y - r.y) * tex.height) / r.height), tex.height);

                    Color col = tex.GetPixel(px, py);

                    color = new Color(col.r, col.g, col.b);
                    colorPreview.color = color;
                    Debug.Log(col);
                }

                else
                {
                    return;
                }
            }
            manipulateObj.selectedObject.gameObject.GetComponent<MeshRenderer>().material.color = colorPreview.color;
        }
    }
}
