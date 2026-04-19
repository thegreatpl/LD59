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
        yield return null; 
        yield return null; //need to wait for the scene load code to finish before we turn on the black screen. 
        var UI = GameManager.Instance.UI;       
        UI.ShowBlackPanel(true); 

        yield return null;
        var Playerobj = GameManager.Instance.Player.GetComponent<PlayerController>();
        Playerobj.LockControls = true;

        yield return null;

        //do plot stuff here. 
        UI.ShowSpeech("Richard: \n What do you think we'll find?");
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());
        UI.ShowSpeech("You: \n I have no idea");
        yield return null;
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());
        UI.ShowSpeech("Richard: \n Dude, you're not even curious? It's a mysterious signal on the moon. It could be anything. It could be aliens. It might even be Doom or something.");
        yield return null;
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());
        UI.ShowSpeech("You: \n I hope it's not Doom. I'm an astronaught, not a soldier. I can't hit the broadside of a barn.");
        yield return null;
        yield return new WaitUntil(()=> NextSpeech.WasPressedThisFrame());
        UI.ShowSpeech("Commander James: \n It's probably something natural. Or someone's probe got malfunctioning. Now, get ready for landing");
        yield return null;
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());

        UI.ShowBlackPanel(false); 
        Playerobj.transform.LookAt(transform.position);
        UI.ShowSpeech("Richard: \n That's a door! A door on the moon!");
        yield return null;
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());
        Playerobj.transform.LookAt(transform.position);
        UI.ShowSpeech("Commander James: \n Stay sharp!");
        yield return null;
        yield return new WaitUntil(() => NextSpeech.WasPressedThisFrame());
        Playerobj.transform.LookAt(transform.position);
        UI.ShowSpeech("You: \n Let me just... AAARG!"); 

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
