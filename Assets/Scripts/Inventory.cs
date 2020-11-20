using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Vector2 startPos = Vector2.zero;
    [SerializeField] Vector2 endPos = Vector2.zero;

    void Start()
    {

    }

    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            float prevPos = touch.position.x;
            float currPos = prevPos - touch.deltaPosition.x;

            if (currPos > prevPos)
            {
                touch.position = new Vector2(currPos,0);
                Debug.Log("Left");
                Debug.Log(currPos);
            }

            if (currPos < prevPos)
            {
                Debug.Log("Right");
                Debug.Log(currPos);
            }
        }

        //if (Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            startPos = touch.position;
        //            break;

        //        case TouchPhase.Ended:
        //            endPos = touch.position;

        //            if (startPos == endPos)
        //            {
        //                Debug.Log("tap");
        //            }

        //            else if (startPos != endPos)
        //            {
        //                this.GetComponentInChildren<RectTransform>().GetChild(0).gameObject.SetActive(false);
        //            }

        //            else if (startPos != endPos && this.GetComponentInChildren<RectTransform>().GetChild(0).gameObject == false)
        //            {
        //                gameObject.SetActive(true);
        //            }

        //            startPos = Vector2.zero;
        //            endPos = Vector2.zero;
        //            break;
        //    }
        //}
    }
}
