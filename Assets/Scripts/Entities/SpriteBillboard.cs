using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var cam = GameManager.Instance.GetCurrentCamera(); 

        if (cam == null )
            return;

        transform.rotation = Quaternion.Euler(0f,cam.transform.rotation.eulerAngles.y, 0f);

    }
}
