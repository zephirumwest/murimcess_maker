using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public Text displayText;

    private void Start()
    {
        string firstName = PlayerPrefs.GetString("firstname");
        string lastName = PlayerPrefs.GetString("lastname");
        Debug.Log(firstName + lastName);
        displayText.text = firstName + lastName + "test";
    }
}
