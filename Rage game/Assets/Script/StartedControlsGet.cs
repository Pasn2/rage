using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartedControlsGet : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    public Vector2 direction;
    public bool isPreparingToJump;
    public bool isJumping;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Move(context.ReadValue<float>());
    }

    public void OnPreparing(InputAction.CallbackContext context)
    {
        PreparingForJump(context.ReadValue<float>());
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        print(context.ReadValue<float>());
        Jump(context.ReadValue<float>());
    }
    private void Move(float _dir)
    {
        direction.x = _dir;
    }
    private void PreparingForJump(float _value)
    {
        UtilityConvert.ConvertFloatButtonToBool(_value,out isPreparingToJump);
    }
    private void Jump(float _value)
    {
        UtilityConvert.ConvertFloatButtonToBool(_value,out isJumping);
    }
}
