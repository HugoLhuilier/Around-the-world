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

    private char nameCharacter;
    private string dialogueBoby;

    public IsWriting isWriting;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (isWriting.getWriting() == true))
        {
            if (index == sentences.Length - 1 && dialogueText.text == dialogueBoby)
            {
                UnityEngine.Debug.Log("fin");
                nameText.text = "";
                dialogueText.text = "";

                StartCoroutine(DebugTime());
            }
            else if (dialogueText.text != dialogueBoby)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueBoby;
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
        index = 0;
        sentences = dialogue.sentences;
        
        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {
        nameCharacter = sentences[index].ToCharArray()[0];
        displayName(nameCharacter);

        dialogueText.text = "";
        dialogueBoby = "";

        char[] sentence = sentences[index].ToCharArray();
        for (int i = 2; i < sentence.Length; i++)
        {
            dialogueBoby += sentence[i];
        }
        StartCoroutine(TypeSentence(dialogueBoby));
        }



    public void displayName(char c)
    {
        if (c == 'G')
        {
            nameText.text = "Gaston";
        }
        else if (c == 'C')
        {
            nameText.text = "Chloé";
        }
        else if (c == 'R')
        {
            nameText.text = "Roland";
        }
        else
        {
            nameText.text = "Joueur";
        }
    }



    IEnumerator TypeSentence(string dialogueBody)
    {
        foreach (char letter in dialogueBody.ToCharArray())
        {
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