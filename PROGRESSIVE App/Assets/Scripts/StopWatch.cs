/*
* TickLuck Team
* All rights reserved
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{

    #region Variables
    public TextMeshProUGUI watchText;
    public static TextMeshProUGUI watchTextCopy;
    public float time;
    public float prime = 1f;
    [HideInInspector]
    public bool isOn = false;
    [HideInInspector]
    public bool paused = false;
    public GameObject start;
    public GameObject reset;
    public GameObject pause;
    public GameObject loop;
    public float smoothSpeed = 1f;
    public Image secondsBar;
    //public Animation fillAnim;
    private float fill;
    #endregion

    #region Unity Methods

    void Start()
    {
        secondsBar.fillAmount = 0f;
        watchText.text = "00.00.00";
        time = 0f;
        fill = 0f;
    }


    void Update()
    {
        watchTextCopy = watchText;

        if (isOn && !paused)
        {
            time += Time.deltaTime * prime;

            string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
            string seconds = Mathf.Floor(time % 60).ToString("00");
            string milliSeconds = ((time % 0.99) * 100).ToString("00");

            secondsBar.fillAmount += smoothSpeed * Time.deltaTime * 100f;
            if (secondsBar.fillAmount == 1f)
            {
                //fillAnim.Play();
                secondsBar.fillAmount = 0f;
            }

            //if (seconds == "00")
            //{
            //    fill = 0f;
            //    secondsBar.fillAmount = 0f;
            //}

            watchText.text = minutes + ":" + seconds + ":" + milliSeconds;
        }

        if (!isOn)
        {
            secondsBar.fillAmount = 0f;
            watchText.text = "00.00.00";
            time = 0;
            fill = 0f;
        }
    }

    public void SetOn()
    {
        isOn = true;
        paused = false;

        start.SetActive(false);
        reset.SetActive(false);
        pause.SetActive(true);
        loop.SetActive(true);
    }

    public void SetOff()
    {
        isOn = false;
        AddLoop.loopTimeText.text = "";
    }

    public void Pause()
    {
        paused = true;

        start.SetActive(true);
        reset.SetActive(true);
        pause.SetActive(false);
        loop.SetActive(false);
    }

    #endregion

}
