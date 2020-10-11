/*
* TickLuck Team
* All rights reserved
*/

using TMPro;
using UnityEngine;

public class TimeSynchroniser : MonoBehaviour
{

    #region Variables
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    #endregion

    #region Unity Methods

    void Update()
    {
        if(timeText && dateText)
        {
            timeText.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
            dateText.text = System.DateTime.UtcNow.ToLocalTime().ToString("ddd MMM dd"); // fix it to make english 
        }
    }

#endregion

}
