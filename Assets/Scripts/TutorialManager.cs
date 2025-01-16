using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] GameObject tutorial_1;
    [SerializeField] GameObject tutorial_2;
    [SerializeField] GameObject tutorial_3;
    [SerializeField] GameObject tutorial_4;
    [SerializeField] GameObject tutorial_5;

    [SerializeField] float startDelay = 1f;
    private bool waiting = true;
    [SerializeField] int currentTutorialSlide = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentTutorialSlide++;
            NextTutorialSlide();
        }
    }

    private IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(startDelay);
        tutorial_1.SetActive(true);
        waiting = false;
    }

    private void NextTutorialSlide()
    {
        tutorial_1.SetActive(false);
        tutorial_2.SetActive(false);
        tutorial_3.SetActive(false);
        tutorial_4.SetActive(false);
        tutorial_5.SetActive(false);

        switch (currentTutorialSlide)
        {
            case 2:
                tutorial_2.SetActive(true);
                break;
            case 3:
                tutorial_3.SetActive(true);
                break;
            case 4:
                tutorial_4.SetActive(true);
                break;
            case 5:
                tutorial_5.SetActive(true);
                break;
        }

        if (currentTutorialSlide > 5)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        //add the logic/call to the method to start the actual game

        gameObject.SetActive(false);
    }
}
