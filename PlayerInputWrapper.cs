using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputWrapper : MonoBehaviour
{
    public InputActionAsset inputActions;

    [HideInInspector] public InputActionProperty moveAction;
    [HideInInspector] public InputActionProperty interactAction;

    void Awake()
    {
        var gameplayMap = inputActions.FindActionMap("Gameplay", true);
        moveAction = new InputActionProperty(gameplayMap.FindAction("Move", true));
        interactAction = new InputActionProperty(gameplayMap.FindAction("Interact", true));
    }
}