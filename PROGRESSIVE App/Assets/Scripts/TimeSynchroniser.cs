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
    #endregion

    #region Unity Methods

    void Update()
    {
        if(timeText)
            timeText.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
    }

#endregion

}
