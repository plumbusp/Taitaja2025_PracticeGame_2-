using UnityEngine;
using System;
using UnityEngine.UI;

public class Problem : MonoBehaviour
{
    // Have methods to be solved
    [SerializeField] private float _holdDuration;
    [SerializeField] private Image _fillCircle;

    private float _holdTimer = 0;
    private bool _isHolding = false;

    public bool Active { get; private set; }
    public void SetActive() => Active = true;

    private void Update()
    {
        if (!Active)
            return;

        if (_isHolding)
        {
            _holdTimer += Time.deltaTime;

        }
    }
}
