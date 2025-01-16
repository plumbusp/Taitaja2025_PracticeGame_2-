using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ProblemsController : MonoBehaviour
{
    // Makes problems active at some period of time 
    [SerializeField] private PlayerCollisionDetector _detector;
    private bool _canSolveProblem;

    private List<Problem> _currentProblems = new();

    private void Start()
    {
        _detector.OnProblemEntered += HandleNewProblem;
    }

    private void HandleNewProblem(Problem newProblem)
    {
        
    }
}
