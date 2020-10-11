/*
* TickLuck Team
* All rights reserved
*/

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddLoop : MonoBehaviour
{

    #region Variables
    public static TextMeshProUGUI loopTimeText;
    private string timeToAdd;
    private int num = 0;
    private string previousTime;
    private System.Text.StringBuilder stringBuilder;
    #endregion

    #region Unity Methods

    void Start()
    {
        stringBuilder = new System.Text.StringBuilder();
        loopTimeText = GameObject.FindGameObjectWithTag("Loop_txt").GetComponent<TextMeshProUGUI>();
        timeToAdd = "";
        loopTimeText.text = "";
        num = 0;
        previousTime = "";
    }

    void Update()
    {
        timeToAdd = StopWatch.watchTextCopy.text;
    }

    #endregion
    public void Add()
    {
        // set the calculation mm ss msms

        string newText = num.ToString() + " " + timeToAdd + " " + "+ "/*(timeToAdd - previousTime)*/;// convert 

        // make repeating string disapear

        stringBuilder.AppendLine(timeToAdd);
        stringBuilder.AppendLine(previousTime);

        loopTimeText.text = stringBuilder.ToString();
        previousTime = timeToAdd;
        stringBuilder.Clear();
        //loopTimeText.text += "\n";
        num++;
    }

}
