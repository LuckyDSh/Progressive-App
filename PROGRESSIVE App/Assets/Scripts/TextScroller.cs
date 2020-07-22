/*
* TickLuck Team
* All rights reserved
*/

using System.Collections;
using TMPro;
using UnityEngine;

public class TextScroller : MonoBehaviour
{

    public TextMeshProUGUI text;
    //public float scrollSpeed = 10.0f;

    private TextMeshProUGUI cloneText;

    private RectTransform textRectTransform;

    // Use this for initialization
    void Awake()
    {
        textRectTransform = text.GetComponent<RectTransform>();

        cloneText = Instantiate(text) as TextMeshProUGUI;
        RectTransform cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        //cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localPosition = new Vector3(0, text.preferredHeight + cloneRectTransform.position.y, 0);
        cloneRectTransform.localScale = Vector3.one;
        cloneText.text = text.text;

    }

    //private IEnumerator Start()
    //{

    //    float width = text.preferredWidth;
    //    Vector3 startPosition = textRectTransform.localPosition;

    //    float scrollPosition = 0;

    //    while (true)
    //    {
    //        textRectTransform.localPosition = new Vector3(-scrollPosition % width, startPosition.y, startPosition.z);
    //        scrollPosition += scrollSpeed * 20 * Time.deltaTime;
    //        yield return null;
    //    }
    //}

}
