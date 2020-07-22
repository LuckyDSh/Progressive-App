/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

[System.Serializable]
public class AlarmInfo
{
    public int hour;
    public int min;
    public string[] repeat;
    public AudioClip music;
    public bool vibration;
    public bool deleteAfterOff;
    public string Label;
}
