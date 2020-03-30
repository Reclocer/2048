using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalization : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;    
    
    private void Start()
    {
        Localization localization = GameObject.FindGameObjectWithTag("Localization").GetComponent<Localization>();
        localization.OnChangeLanguage += LoadLanguage;
        LoadLanguage(localization.Language);
    }   
    
    private void LoadLanguage(string language)
    {
        if (language == "En")
        {
            GetComponent<Text>().text = _en;
        }
        else
        {
            GetComponent<Text>().text = _ru;
        }
    }
}
