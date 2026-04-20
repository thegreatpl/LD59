using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public TextMeshProUGUI SliderText;

    public Slider Slider;


    public PlayerController Player; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MainMenuCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator MainMenuCoroutine()
    {
        yield return null;
        yield return null;

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Player = GameManager.Instance.Player.GetComponent<PlayerController>(); 
        Player.LockControls = true;
        Slider.value = GameManager.Instance.Player.GetComponentInChildren<MouseLook>().MouseSensitivity;
        SetSliderText();
        GameManager.Instance.UI.ShowBlackPanel(false); 
        GameManager.Instance.UI.ShowSpeechPanel(false);
        yield return null;

        WaypointScript CurrentWaypoint = 
            GameManager.Instance.CurrentMap.Waypoints.OrderBy(x => Vector3.Distance(x.transform.position,
                GameManager.Instance.CurrentMap.Startpositions[0].transform.position)).FirstOrDefault();

        if (CurrentWaypoint != null)
        {

            while (true)
            {
                if (Vector3.Distance(Player.transform.position, CurrentWaypoint.transform.position) < 1)
                {
                    CurrentWaypoint = CurrentWaypoint.Neighbours.RandomElement();
                }

                Player.transform.LookAt(CurrentWaypoint.transform);
                Player.MovementController.Movement = Vector2.up; 

                yield return null;
            }
        }
    }


    public void SetSliderText()
    {
        SliderText.text = Slider.value.ToString();
        GameManager.Instance.Player.GetComponentInChildren<MouseLook>().MouseSensitivity = Slider.value;
    }


    public void StartGame()
    {
        GameManager.Instance.StartNewGame();
    }
}
