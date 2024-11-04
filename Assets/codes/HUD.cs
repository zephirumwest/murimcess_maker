using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType{
        EXP, LEVEL, Kill, Time, Health
    }
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.EXP:
                
                break;
            case InfoType.LEVEL:
               
                break;
            case InfoType.Kill:
                
                break;
            case InfoType.Time:
                
                break;
            case InfoType.Health:
                
                break;
        }
    }
}
