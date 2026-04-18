using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{

    public MovementController MovementController;


    InputAction Move;
    InputAction Jump; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        Move = InputSystem.actions.FindAction("Move");
        Jump = InputSystem.actions.FindAction("Jump"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Move.ReadValue<Vector2>();
        MovementController.Movement = movement;


        MovementController.Jump = Jump.IsPressed();  

    }
}
