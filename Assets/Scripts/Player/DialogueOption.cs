using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    public string[] text;
    public int index, option;
    public bool showDlg;
    //public GUIStyle dlgStyle;
    private void OnGUI()
    {
        if(showDlg)
        {
            Vector2 scr = new Vector2(Screen.width/16,Screen.height/9);

            GUI.Box(new Rect(0, scr.y * 6, Screen.width,scr.y*3),text[index]);
            if(!(index >= text.Length-1 || index == option))
            {
                if(GUI.Button(new Rect(scr.x*14.25f,scr.y*8.35f,scr.x*1.5f, scr.y*0.5f),"Next"))
                {
                    index++;
                }
            }
            else if(index == option)
            {
                if (GUI.Button(new Rect(scr.x * 14.25f, scr.y * 8.35f, scr.x * 1.5f, scr.y * 0.5f), "Decline"))
                {
                    index = text.Length - 1;
                }
                if (GUI.Button(new Rect(scr.x * 12.5f, scr.y * 8.35f, scr.x * 1.5f, scr.y * 0.5f), "Accept"))
                {
                    index++;
                }
            }
            else
            {
                if (GUI.Button(new Rect(scr.x * 14.25f, scr.y * 8.35f, scr.x * 1.5f, scr.y * 0.5f), "Bye."))
                {
                    index = 0;
                    showDlg = false;
                }
            }
        }
    }
}
