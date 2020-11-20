using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ItemData[] itemDatas;
    public Transform slotHolder;
    public Slot slotPrefab;

    public CrosshairPlacement placement;
    void Start()
    {
        itemDatas = Resources.LoadAll<ItemData>("Items");

        foreach (ItemData item in itemDatas)
        {
            Debug.Log(item);
            Slot slot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotHolder);
            slot.Initialize(item, () => placement.GetPrefab(item));
        }
    }
}
