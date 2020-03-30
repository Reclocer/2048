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
    public event Action<string> OnChangeLanguage = (language) => { };

    private void Start()
    {
        LoadLanguage();        
    }

    public void ClickLanguageChangeBtn()
    {
//#if UNITY_EDITOR && !UNITY_ANDROID
//        if (_language == "En")
//        {
//            _language = "Ru";
//            PlayerPrefs.SetString("Language", _language);
//            PlayerPrefs.Save();

//            LoadLanguage();            
//            SceneManager.LoadScene(0);
//        }
//        else
//        {
//            _language = "En";
//            PlayerPrefs.SetString("Language", _language);
//            PlayerPrefs.Save();

//            LoadLanguage();
//            SceneManager.LoadScene(0);
//        }  
//#endif

#if UNITY_EDITOR && UNITY_ANDROID
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
#endif
    }

    private void LoadLanguage()
    {
//#if UNITY_EDITOR && !UNITY_ANDROID
//        if (PlayerPrefs.HasKey("Language"))
//        {
//            _words = GameObject.FindGameObjectsWithTag("Localizable");
//            string language = PlayerPrefs.GetString("Language");
//            XmlDocument xmlDocument = new XmlDocument();
//            xmlDocument.Load($"Assets/Resources/Localization/{language}.xml");
//            XmlNodeList list = xmlDocument.GetElementsByTagName("word");
//            int lenght = _words.Length;

//            foreach (XmlNode tag in list)
//            {
//                _names.Add(tag.InnerText);
//            }

//            for (int i = 0; i < lenght; i++)
//            {
//                _words[i].GetComponent<Text>().text = _names[i];
//            }
            
//            _language = language;
//            GetComponentInChildren<Text>().text = language;
//        }
//#endif
    }
}
