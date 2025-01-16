using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Table : MonoBehaviour
{
    public event Action OnPerformed;
    private GameControls _playerInputActions;

    // Have methods to be solved
    [Header("Hold")]
    [SerializeField] private float _holdDuration;
    [SerializeField] private Image _fillCircle;
    private float _holdTimer = 0;
    private bool _isHolding = false;

    [Header(" \"In-code animation\" parameters")]
    [SerializeField] private Sprite _activeSprite;
    private Sprite _initialSprite;

    [SerializeField] private Vector2 _initialWarningScale;
    [SerializeField] private Vector2 _urgentWarningScale;

    [SerializeField] private Color _initialWarningColor;
    [SerializeField] private Color _urgentWarningColor;

    private Vector2 _initialScale;
    private float float_t;
    private bool increasing_t;
    private Color _initialColor;

    private SpriteRenderer _spriteRen;


    private bool _active = false;


    private bool _holdCanBeShown = false;
    public bool HoldCanBeShown
    {
        get
        {
            return _holdCanBeShown;
        }
        set
        {
            if (_isHolding)
                ResetHold();

            _holdCanBeShown = value;
        }
    }
    private void Start()
    {
        _playerInputActions = new GameControls();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Solve.started += OnHold;
        _playerInputActions.Player.Solve.canceled += OnHold;
        _playerInputActions.Player.Solve.performed += OnHold;
        ResetHold();

        _spriteRen = GetComponent<SpriteRenderer>();
        _initialColor = _spriteRen.color;
        _initialSprite = _spriteRen.sprite;
    }
    public void Initlaize(GameControls playerInputActions)
    {
       
    }

    private void Update()
    {
        //Hold
        if (!HoldCanBeShown)
            return;

        if (_isHolding)
            HandleHoldingTimer();
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        if (!HoldCanBeShown)
            return;

        if (context.started)
            _isHolding = true;
        else if (context.canceled)
            ResetHold();
        else if (context.performed)
            OnPerformed?.Invoke();
    }
    private void ResetHold()
    {
        _isHolding = false;
        _holdTimer = 0;
        _fillCircle.fillAmount = 0;
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
    //private void HandleActiveAnimation()
    //{
    //    if (increasing_t)
    //        float_t += Time.deltaTime;
    //    else
    //        float_t -= Time.deltaTime;

    //    increasing_t = float_t >= 1 ? false : true;

    //}
}
