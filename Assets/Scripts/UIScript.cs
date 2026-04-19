using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public GameObject BlackPanel; 

    public GameObject SpeechPanel;

    public TextMeshProUGUI Text; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BlackPanel.SetActive(false);
        SpeechPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowBlackPanel(bool show)
    {
        BlackPanel.SetActive(show);
    }

    public void ShowSpeechPanel(bool show)
    {
        SpeechPanel.SetActive(show);
    }

    public void ShowSpeech(string speech)
    {
        ShowSpeechPanel(true); 
        Text.text = speech;
    }

}
