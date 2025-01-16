using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Problem : MonoBehaviour
{
    // Have methods to be solved
    [SerializeField] private float _holdDuration;
    [SerializeField] private Image _fillCircle;

    private GameControls _playerInputActions;

    private float _holdTimer = 0;
    private bool _isHolding = false;

    private bool _active = false;
    public bool Active {
        get
        {
            return _active;
        }
        set
        {
            if(_isHolding)
                ResetHold();

            _active = value;
        }
    }

    public void Initlaize()
    {

    }
    private void Start()
    {
        _playerInputActions = new GameControls();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Solve.started += OnHold;
        _playerInputActions.Player.Solve.canceled += OnHold;

        ResetHold();
    }

    private void Update()
    {
        if (!Active)
            return;

        if (_isHolding)
        {
            _holdTimer += Time.deltaTime;
            _fillCircle.fillAmount = _holdTimer/_holdDuration;
            if(_holdTimer >= _holdDuration )
            {
                // To-DO: Fix problem
                Debug.Log(" Problem " + gameObject.name + " fixed");
            }
        }
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
            _isHolding = true;
        else if (context.canceled)
            ResetHold();
    }
    private void ResetHold()
    {
        _isHolding = false;
        _holdTimer = 0;
        _fillCircle.fillAmount =0;
    }
}
