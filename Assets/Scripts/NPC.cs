using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;
    public IsWriting isWriting;

    //public TextMeshProUGUI iconeEText;

    void Update()
    {
        if (ContactNPC() && (isWriting.getWriting() == false))
        {
            if (Input.GetKeyDown(KeyCode.E)){
                //iconeEText.text = "";
                TriggerDialogue();
            }
            //else
            //{
            //    iconeEText.text = "E";
            //}
        }
    }

    private bool ContactNPC()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D rayCast = Physics2D.CircleCast(origin, transform.localScale.x * 2f
            , Vector2.down, transform.localScale.y*2, mask);

        return rayCast.collider != null;
    }

        public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}