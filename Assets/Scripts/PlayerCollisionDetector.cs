using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisionDetector : MonoBehaviour
{
    // Detects problems and allows them to be solved
    public event Action<Problem> OnProblemEntered;
    public event Action<Problem> OnProblemExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Problem>(out Problem currentProblem))
        {
            OnProblemExit(currentProblem);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Problem>(out Problem currentProblem))
        {
            OnProblemExit(currentProblem);
        }
    }
}