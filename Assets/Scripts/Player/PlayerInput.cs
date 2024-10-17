using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode jump = KeyCode.Space;

    private Vector2 inputVector;
    public Vector2 InputVector => inputVector;

    public bool IsJumping { get => isJumping; set => isJumping = value; }

    private bool isJumping;

    private float xInput;
    private float yInput;


    public void HandleInput()
    {
        xInput = 0;
        yInput = 0;

        if (Input.GetKey(left))
        {
            xInput--;
        }
        if (Input.GetKey(right))
        {
            xInput++;
        }
        if (Input.GetKey(KeyCode.R))
        {
            GameManager.Instance.LoadSavedGame();
        }

        inputVector = new Vector2(xInput, yInput);

        isJumping = Input.GetKeyDown(jump);
    }

    void Update()
    {
        HandleInput();
    }

}
