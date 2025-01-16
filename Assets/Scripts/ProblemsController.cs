using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemsController : MonoBehaviour
{
    // Makes problems active at some period of time 
    [SerializeField] EndGameScreenManager _endGameScreenManager;
    [SerializeField] private float _waitTime;
    private float _timer = 0;

    public List<Problem> _problems;
    private List<Problem> _activeProblems = new();

    private bool _busy = false;

    private void Start()
    {
        foreach (var problem in _problems)
        {
            problem.OnDied += () => _endGameScreenManager.ShowDeadScreen();
        }
    }

    private void Update()
    {
        if(_busy)
            return;

        _timer += Time.deltaTime;
        if(_timer >= _waitTime)
        {
            _timer = 0;
            if(_activeProblems.Count >= _problems.Count)
                return;
            StartCoroutine(HandleProblemActivation());
        }
    }

    private IEnumerator HandleProblemActivation()
    {
        _busy = true;
        while (true)
        {
            if (ActivateRandomProblem())
            {
                _busy = false;
                yield break;
            }
        }

    }

    private bool ActivateRandomProblem()
    {
        int randomIndex = Random.Range(0, _problems.Count );
        if (_activeProblems.Contains(_problems[randomIndex]))
            return false;

        var problem = _problems[randomIndex];
        _activeProblems.Add(problem);
        problem.Active = true;
        problem.OnFixed += OnProblemFixed;

         return true;
    }

    private void OnProblemFixed(Problem problem) => _activeProblems.Remove(problem);
}
