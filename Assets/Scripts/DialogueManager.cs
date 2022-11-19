using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private float textSpeed = 0.1F;

    private string[] sentences;
    private int index;

    public IsWriting isWriting;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (isWriting.getWriting() == true))
        {
            if (index == sentences.Length - 1 && dialogueText.text == sentences[index])
            {
                UnityEngine.Debug.Log("fin");
                nameText.text = "";
                dialogueText.text = "";

                StartCoroutine(DebugTime());
            }
            else if (dialogueText.text != sentences[index])
            {
                StopAllCoroutines();
                dialogueText.text = sentences[index];
            }
            else
            {
                index++;
                DisplayNextSentence();
            }
        }
    }



    public void StartDialogue(Dialogue dialogue)
    {
        isWriting.changeWritingState(true);
        nameText.text = dialogue.name;
        index = 0;
        sentences = dialogue.sentences;

        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {
        dialogueText.text = "";
        StartCoroutine(TypeSentence());
        }



    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }



    IEnumerator DebugTime()
    {
        yield return new WaitForSeconds(0.1f);
        isWriting.changeWritingState(false);
    }
}
