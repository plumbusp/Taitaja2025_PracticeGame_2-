using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollisionDetector : MonoBehaviour
{
    // Detects problems and allows them to be solved

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Problem>(out Problem currentProblem))
        {
            currentProblem.HoldCanBeShown = true;
            //Debug.Log(currentProblem.HoldCanBeShown);
        }
        else if(other.gameObject.TryGetComponent<Table>(out Table table))
            {
            table.HoldCanBeShown=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Problem>(out Problem currentProblem))
        {
            currentProblem.HoldCanBeShown = false;
            //Debug.Log(currentProblem.HoldCanBeShown);
        }
        else if (other.gameObject.TryGetComponent<Table>(out Table table))
        {
            table.HoldCanBeShown = false;
        }
    }
}