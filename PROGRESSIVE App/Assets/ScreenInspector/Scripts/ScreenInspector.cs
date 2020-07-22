using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenInspector : MonoBehaviour {

    public bool show;
    public bool mirrored;
    public Color color = Color.black;
    public enum Types {Notch, Rounded };
    public Types type;
    private Texture[] textures;
#if UNITY_EDITOR

    void OnEnable()
    {
        textures = new Texture[4];

        textures[0] = Resources.Load<Texture>("Notch_Portrait");
        textures[1] = Resources.Load<Texture>("Rounded_Portrait");
        textures[2] = Resources.Load<Texture>("Notch_Landscape");
        textures[3] = Resources.Load<Texture>("Rounded_Landscape");
    }

    private void OnGUI()
    {
        bool portrait = Screen.height > Screen.width;

        if (Application.isEditor && !Application.isPlaying && show)
        {
            GUI.color = color;

            if (portrait)
            {
                if (textures[(int)type])
                {
                    if (mirrored)
                        GUI.DrawTexture(new Rect(0, Screen.height, Screen.width, -Screen.height), textures[(int)type]);
                    else GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textures[(int)type]);
                }
            }
            else
            {
                if (textures[(int)type + 2])
                {
                    if (mirrored)
                        GUI.DrawTexture(new Rect(Screen.width, 0, -Screen.width, Screen.height), textures[(int)type + 2]);
                    else GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textures[(int)type + 2]);
                }
            }
        }
    }
#endif
}