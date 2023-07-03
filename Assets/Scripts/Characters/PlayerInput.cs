using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttak;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttak = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        Movement();
        Combat();
    }

    private void Movement()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HorizontalAxis);
        bool isJumpPressed = Input.GetButtonDown(GlobalStringVars.Jump);
        _playerMovement.Move(horizontalDirection, isJumpPressed);
    }

    private void Combat()
    {
        if (Input.GetButtonDown(GlobalStringVars.Attak) && !_playerAttak.IsAttack && _playerAttak.AttackIsReady) 
        {  
            _playerAttak.Attack(); 
        }
        if (Input.GetButtonDown(GlobalStringVars.Attak) && !_playerAttak.AttackIsReady)
        {
            _playerAttak.FailAttack();
        }
    }
}