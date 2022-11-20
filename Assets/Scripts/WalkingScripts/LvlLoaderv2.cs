using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class LvlLoaderv2 : MonoBehaviour
{
    public float transitionTime = 1.5f;
    private Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        transition = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(int lvlIndex)
    {
        StartCoroutine(LoadLevel(lvlIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
