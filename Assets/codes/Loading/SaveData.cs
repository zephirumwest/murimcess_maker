using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public InputField inputfirstname;
    public InputField inputlastname;

    public void save()
    {
        string firstname = inputfirstname.text;
        string lastname = inputlastname.text;

        PlayerPrefs.SetString("firstname", firstname);
        PlayerPrefs.SetString("lastname", lastname);
        PlayerPrefs.Save();

        string savedfirstname = PlayerPrefs.GetString("firstname");
        string savedlastname = PlayerPrefs.GetString("lastname");
        Debug.Log("Saved Firstname: " + savedfirstname);
        Debug.Log("Saved Lastname: " + savedlastname);
        
    }
    public void load()
    {
        inputfirstname.text = PlayerPrefs.GetString("firstname");
        inputlastname.text = PlayerPrefs.GetString("lastname");
    }
}
