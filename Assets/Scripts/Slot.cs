using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slot : MonoBehaviour
{
    public Image image;
    public Text text;

    [SerializeField] Action onClick;

    CrosshairPlacement placement;
    public void Initialize(ItemData itemData, Action _onClick)
    {
        onClick = _onClick;
        image.sprite = itemData.itemSprite;
        text.text = itemData.itemName;
    }

    public void Click()
    {
        onClick.Invoke();
    }
}