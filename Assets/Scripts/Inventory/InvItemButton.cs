using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InvItemButton : MonoBehaviour
{
    
    public Text label;

    public void SetLabel(string text)
    {
        label.text = text;
    }    

}
