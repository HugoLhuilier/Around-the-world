using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public IsWriting isWriting;
    public GameObject panel;


    public float transitionTime = 1.5f;
    private Animator transition;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isWriting.getWriting())
            {
                panel.SetActive(false);
                isWriting.changeWritingState(false);

            }
            else
            {
                isWriting.changeWritingState(true);
                panel.SetActive(true);
            }
        }
    }

    public void quit()
    {
        Application.Quit();
    }
}