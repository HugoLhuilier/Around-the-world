using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private RectTransform selectArrow;
    [SerializeField] private RectTransform pierre;
    [SerializeField] private RectTransform feuille;
    [SerializeField] private RectTransform ciseaux;
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform selectionBar;
    [SerializeField] private GameController gameController;
    [SerializeField] private String[] rActions;
    [SerializeField] private String[] rDialogues;
    public int nbActions;
    [SerializeField] private TextMeshProUGUI diagText;
    public int selectedAct;

    private Vector3 velocity = Vector3.zero;
    private String[] buttons;
    private float horizontalAxis;
    private float act;
    private int selected = 1;
    private bool canSelect = true;
    public bool ok = false;
    public bool fini = false;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new String[3];
        buttons[0] = "Pierre";
        buttons[1] = "Feuille";
        buttons[2] = "Ciseaux";
        selectedAct = UnityEngine.Random.Range(0, nbActions - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fini)
        {
            diagText.text = rDialogues[selectedAct];
            getInput();
            updateSelected();

            selectionBar.localPosition = new Vector3(0, -120, 0);

            switch (selected)
            {
                case 0:
                    selectArrow.position = pierre.position + 110 * Vector3.down;
                    break;

                case 1:
                    selectArrow.position = feuille.position + 110 * Vector3.down;
                    break;

                default:
                    selectArrow.position = ciseaux.position + 110 * Vector3.down;
                    break;
            }

            if (act > 0.1 && !ok)
            {
                ok = true;
            }

            if (ok)
            {
                StartCoroutine(gameController.CountDown(buttons[selected], rActions[selectedAct]));
                fini = true;
                diagText.text = "";
            }
        }
        if (ok)
        {
            selectionBar.position = Vector3.SmoothDamp(selectionBar.position, new Vector3(selectionBar.position.x, -350, 0), ref velocity, smoothTime);
        }
    }

    private void getInput()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        act = Input.GetAxisRaw("Fire1");
    }

    private void updateSelected()
    {
        if(horizontalAxis > 0.1 && canSelect)
        {
            switch (selected)
            {
                case 0:
                    selected = 1;
                    break;

                case 1:
                    selected = 2;
                    break;

                default:
                    selected = 0;
                    break;
            }
            canSelect = false;
        }

        else if(horizontalAxis < -0.1 && canSelect)
        {
            switch (selected)
            {
                case 0:
                    selected = 2;
                    break;

                case 1:
                    selected = 0;
                    break;

                default:
                    selected = 1;
                    break;
            }
            canSelect=false;
        }

        if(Mathf.Abs(horizontalAxis) < 0.1)
        {
            canSelect = true;
        }
    }
}
