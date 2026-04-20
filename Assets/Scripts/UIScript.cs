using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public GameObject BlackPanel; 

    public GameObject SpeechPanel;

    public GameObject InGameManu; 


    public TextMeshProUGUI Text;


    public TextMeshProUGUI SliderText;

    public Slider Slider;

    InputAction BringUpMenu;

    bool menushowing; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BringUpMenu = InputSystem.actions.FindAction("Cancel");


        BlackPanel.SetActive(false);
        SpeechPanel.SetActive(false);
        InGameManu.SetActive(false);
        menushowing = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (BringUpMenu.WasPressedThisFrame())
        {
            if (menushowing)
            {
                InGameManu.SetActive(false);
                GameManager.Instance.Player.GetComponent<PlayerController>().LockControls = false;
                GameManager.Instance.Player.GetComponent<Attributes>().Immune = false;
                Cursor.lockState = CursorLockMode.Locked;
                menushowing = false; 
            }
            else
            {
                InGameManu.SetActive(true);
                GameManager.Instance.Player.GetComponent<PlayerController>().LockControls = true;
                GameManager.Instance.Player.GetComponent<Attributes>().Immune = true;
                Slider.value = GameManager.Instance.Player.GetComponentInChildren<MouseLook>().MouseSensitivity;
                SetSliderText(); 
                Cursor.lockState = CursorLockMode.None;
                menushowing = true;
            }
        }
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




    public void SetSliderText()
    {
        SliderText.text = Slider.value.ToString();
        GameManager.Instance.Player.GetComponentInChildren<MouseLook>().MouseSensitivity = Slider.value;
    }

}
