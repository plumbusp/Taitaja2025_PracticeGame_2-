using System.Collections.Generic;
using UnityEngine;

public class ProblemsBootstrap : MonoBehaviour
{
    [SerializeField] private List<Problem> problems;
    private GameControls _playerInputActions;

    private void Awake()
    {
        foreach (var problem in problems)
        {
            _playerInputActions = new GameControls();
            _playerInputActions.Player.Enable();
            problem.Initlaize(_playerInputActions);
        }
    }
}
