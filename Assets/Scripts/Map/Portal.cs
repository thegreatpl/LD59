using UnityEngine;

public class Portal : MonoBehaviour
{

    public string NextLevel;

    public string StartLocationName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !string.IsNullOrWhiteSpace(NextLevel))
        {
            GameManager.Instance.LoadLevel(NextLevel, StartLocationName);
        }
    }

}
