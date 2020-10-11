/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI watchText;
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
    public GameObject timeSelection;
    public GameObject timer;
    public float smoothSpeed = 1f;
    public Image timerBar;
    //public Animation fillAnim;
    private float fill;
    [HideInInspector]
    public float timeAmount;
    #endregion

    #region Unity Methods

    void Start()
    {
        timerBar.fillAmount = 0f;
        watchText.text = "00.00.00";
        time = 0f;
        fill = 0f;
    }

    /// <summary>
    /// Work over representation of time
    /// </summary>
    void Update()
    {
        if (isOn && !paused)
        {
            if (time > 0)
            {
            time -= Time.deltaTime * prime;

            }

            string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
            string seconds = Mathf.Floor(time % 60).ToString("00");
            string milliSeconds = ((time % 0.99) * 100).ToString("00");

            timerBar.fillAmount = time / timeAmount;
            if (timerBar.fillAmount == 1f)
            {
                //fillAnim.Play();
                timerBar.fillAmount = 0f;
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
            timerBar.fillAmount = 0f;
            watchText.text = "00.00.00";
            time = 0;
            fill = 0f;
        }
    }

    #endregion

    public void SetOn()
    {
        isOn = true;
        paused = false;

        start.SetActive(false);
        reset.SetActive(false);
        timeSelection.SetActive(false);
        timer.SetActive(true);
        pause.SetActive(true);
        loop.SetActive(true);
    }

    public void SetOff()
    {
        isOn = false;
        timeSelection.SetActive(true);
        timer.SetActive(false);
    }

    public void Pause()
    {
        paused = true;

        start.SetActive(true);
        reset.SetActive(true);
        pause.SetActive(false);
        loop.SetActive(false);
    }
}
