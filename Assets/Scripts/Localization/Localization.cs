using System.Xml;
using UnityEngine;
using G2048;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Localization : MonoBehaviour
{
    private string _language = "Ru";
    public  string  Language => _language;
    
    public event Action<string> OnChangeLanguage = (language) => { };    

    /// <summary>
    /// Change language
    /// </summary>
    public void ClickLanguageChangeBtn()
    {

        if (_language == "En")
        {
            _language = "Ru";
            GetComponentInChildren<Text>().text = _language;            
        }
        else
        {
            _language = "En";
            GetComponentInChildren<Text>().text = _language;            
        }

        OnChangeLanguage(_language);
    }    
}
