using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject obj;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        obj.transform.position = cam.transform.position + cam.transform.forward * 1f;
        obj.transform.SetParent(cam.transform);
        obj.transform.localPosition = Vector3.forward * 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
