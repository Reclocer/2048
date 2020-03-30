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

    private List<string> _names = new List<string>();
    private GameObject[] _words;    

    private void Start()
    {
        LoadLanguage();        
    }

    /// <summary>
    /// Change language
    /// </summary>
    public void ClickLanguageChangeBtn()
    {
        if (_language == "En")
        {
            _language = "Ru";
            PlayerPrefs.SetString("Language", _language);
            PlayerPrefs.Save();

            LoadLanguage();            
            SceneManager.LoadScene(0);
        }
        else
        {
            _language = "En";
            PlayerPrefs.SetString("Language", _language);
            PlayerPrefs.Save();

            LoadLanguage();
            SceneManager.LoadScene(0);
        } 
    }

    private void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            _words = GameObject.FindGameObjectsWithTag("Localizable");
            string language = PlayerPrefs.GetString("Language");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load($"Assets/Resources/Localization/{language}.xml");
            XmlNodeList list = xmlDocument.GetElementsByTagName("word");
            int lenght = _words.Length;

            foreach (XmlNode tag in list)
            {
                _names.Add(tag.InnerText);
            }

            for (int i = 0; i < lenght; i++)
            {
                _words[i].GetComponent<Text>().text = _names[i];
            }
            
            _language = language;
            GetComponentInChildren<Text>().text = language;
        }
    }
}
