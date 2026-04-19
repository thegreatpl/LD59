using UnityEngine;

public class SpeechTrigger : MonoBehaviour
{

    public string Message; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UI.ShowSpeech(Message); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.UI.ShowSpeechPanel(false);
        }
    }
}
