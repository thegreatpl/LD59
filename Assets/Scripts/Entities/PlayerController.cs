using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{

    public MovementController MovementController;

    public ProjectileFire ProjectileFire; 

    public Camera Camera;


    InputAction Move;
    InputAction Jump;
    InputAction Fire; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        ProjectileFire = GetComponent<ProjectileFire>(); 
        Move = InputSystem.actions.FindAction("Move");
        Jump = InputSystem.actions.FindAction("Jump");
        Fire = InputSystem.actions.FindAction("Attack"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Move.ReadValue<Vector2>();
        MovementController.Movement = movement;


        MovementController.Jump = Jump.IsPressed();

        if (Fire.IsPressed())
        {
            ProjectileFire.Fire(Camera.transform.forward); 
        }

    }
}
