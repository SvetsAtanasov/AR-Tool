using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExpandableMenu : MonoBehaviour
{
    public GameObject[] transforms;
    public RectTransform optionsBtn;
    public CanvasScaler canvasScaler;

    private void Start()
    {
    }

    public void Expand()
    {
        //for (int i = 0; i < transforms.Length; i++)
        //{
        //    float y = optionsBtn.sizeDelta.y * (i + 1);
        //    transforms[i].transform.DOMoveY(-y, 10f * Time.deltaTime);
        //}
    }
}