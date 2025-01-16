using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Problem : MonoBehaviour
{
    public event Action<Problem> OnFixed;
    public event Action OnDied;

    private GameControls _playerInputActions;

    // Have methods to be solved
    [Header("Hold")]
    [SerializeField] private float _holdDuration;
    [SerializeField] private Image _fillCircle;
    private float _holdTimer = 0;
    private bool _isHolding = false;

    [Header("Active state parameters")]
    [SerializeField] private float _secondsUntilUrgent;
    [SerializeField] private float _secondsUntilDie;
    private float _waitTimer;


    [Header(" \"In-code animation\" parameters")]
    [SerializeField] private Vector2 _initialWarningScale;
    [SerializeField] private Vector2 _urgentWarningScale;

    [SerializeField] private Color _initialWarningColor;
    [SerializeField] private Color _urgentWarningColor;

    private Vector2 _initialScale;
    private Color _initialColor;

    private SpriteRenderer _spriteRen;


    private bool _active = false;
    public bool Active {
        get
        {
            return _active;
        }
        set
        {
            if (_isHolding)
                ResetHold();

            _active = value;

            if (_active) // If set to Active
            {
                _spriteRen.color = _initialWarningColor;
            }
            else // If set to Unactive
            {
                _waitTimer = 0;
                _spriteRen.color = _initialColor;
            }
        }
    }

    private bool _holdCanBeShown = false;
    public bool HoldCanBeShown
    {
        get
        {
            return _holdCanBeShown;
        }
        set
        {
            if(_isHolding)
                ResetHold();

            _holdCanBeShown = value;
        }
    }


    public void Initlaize(GameControls playerInputActions)
    {
        _playerInputActions = playerInputActions;
        _playerInputActions.Player.Solve.started += OnHold;
        _playerInputActions.Player.Solve.canceled += OnHold;
        _playerInputActions.Player.Solve.performed += OnHold;
        ResetHold();

        _spriteRen = GetComponent<SpriteRenderer>();
        _initialColor = _spriteRen.color;
    }

    private void Update()
    {
        if (!Active)
            return;

        HandleActiveTimer();

        //Hold
        if (!HoldCanBeShown)
            return;

        if (_isHolding)
            HandleHoldingTimer();
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        if (!Active)
            return;

        if (!HoldCanBeShown)
            return;

        if (context.started)
            _isHolding = true;
        else if (context.canceled)
            ResetHold();
        else if (context.performed)
        {
            Active = false;
            OnFixed?.Invoke(this);
        }
    }
    private void ResetHold()
    {
        _isHolding = false;
        _holdTimer = 0;
        _fillCircle.fillAmount =0;
    }
    private void HandleActiveTimer()
    {
        _waitTimer += Time.deltaTime;
        if (_waitTimer >= _secondsUntilUrgent)
        {
            _spriteRen.color = _urgentWarningColor;
            if (_waitTimer >= _secondsUntilUrgent + _secondsUntilDie)
            {
                //Player Lost 
                OnDied?.Invoke();
            }
        }
    }
    private void HandleHoldingTimer()
    {
        _holdTimer += Time.deltaTime;
        _fillCircle.fillAmount = _holdTimer / _holdDuration;
        if (_holdTimer >= _holdDuration)
        {
            // To-DO: Fix problem
            Debug.Log(" Problem " + gameObject.name + " fixed");
            ResetHold();
        }
    }
}
