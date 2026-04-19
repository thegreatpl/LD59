using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartSceneScript : MonoBehaviour
{

    InputAction Skip;

    InputAction NextSpeech; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Skip = InputSystem.actions.FindAction("Jump");
        NextSpeech = InputSystem.actions.FindAction("Attack");
        StartCoroutine(RunCutscene()); 
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Skip.IsPressed())
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().LockControls = false; 
            //skip to first level if they press this. 
            GameManager.Instance.LoadLevel("level1", "Alpha"); 
        }
    }


    IEnumerator RunCutscene()
    {
        yield return null;
        yield return null;
        var Playerobj = GameManager.Instance.Player.GetComponent<PlayerController>();
        Playerobj.LockControls = true;

        yield return null; 

        //do plot stuff here. 

        yield return null;
        Playerobj.transform.LookAt(transform.position);

        yield return new WaitForSeconds(5f); 

        yield return null;
        while (true)
        {
            Playerobj.transform.LookAt(transform.position);
            Playerobj.MovementController.Movement = Vector2.up;
            yield return null;
            Playerobj.MovementController.Movement = Vector2.zero; 

            yield return null;
        }

    }
}
