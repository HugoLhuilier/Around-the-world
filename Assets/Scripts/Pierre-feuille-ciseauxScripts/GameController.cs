using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int pPoints = 0;
    private int rPoints = 0;
    public GameObject text3;
    public GameObject text2;
    public GameObject text1;
    public GameObject pPierre;
    public GameObject pFeuille;
    public GameObject pCiseaux;
    public GameObject rPierre;
    public GameObject rFeuille;
    public GameObject rCiseaux;
    public GameObject pHand;
    public GameObject rHand;
    public GameObject results;
    public Transform canvas;
    private Vector3 normalSize;
    private TextMeshProUGUI resultsText;
    private ButtonController bController;
    [SerializeField] private TextMeshProUGUI pPointsText;
    [SerializeField] private TextMeshProUGUI rPointsText;

    // Start is called before the first frame update
    void Start()
    {
        normalSize = text3.transform.localScale;
        resultsText = results.GetComponent<TextMeshProUGUI>();
        bController = GetComponent<ButtonController>();
        pPointsText.SetText("0/5");
        rPointsText.SetText("0/5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator CountDown(string myChoice, string npcChoice)
    {
        text3.SetActive(true);
        yield return new WaitForSeconds(1f);
        text3.transform.localScale = normalSize;
        text3.SetActive(false);

        text2.SetActive(true);
        yield return new WaitForSeconds(1f);
        text2.transform.localScale = normalSize;
        text2.SetActive(false);

        text1.SetActive(true);
        yield return new WaitForSeconds(1f);
        text1.transform.localScale = normalSize;
        text1.SetActive(false);


        pHand.SetActive(true);
        rHand.SetActive(true);
        switch (myChoice)
        {
            case "Pierre":
                pPierre.SetActive(true);

                switch (npcChoice)
                {
                    case "Pierre":
                        rPierre.SetActive(true);
                        Draw();
                        break;

                    case "Feuille":
                        rFeuille.SetActive(true);
                        RWins();
                        break;

                    default:
                        rCiseaux.SetActive(true);
                        PWins();
                        break;
                }
                break;

            case "Feuille":
                pFeuille.SetActive(true);

                switch (npcChoice)
                {
                    case "Pierre":
                        rPierre.SetActive(true);
                        PWins();
                        break;

                    case "Feuille":
                        rFeuille.SetActive(true);
                        Draw();
                        break;

                    default:
                        rCiseaux.SetActive(true);
                        RWins();
                        break;
                }
                break;

            default:
                pCiseaux.SetActive(true);

                switch (npcChoice)
                {
                    case "Pierre":
                        rPierre.SetActive(true);
                        PWins();
                        break;

                    case "Feuille":
                        rFeuille.SetActive(true);
                        RWins();
                        break;

                    default:
                        rCiseaux.SetActive(true);
                        Draw();
                        break;
                }
                break;
        }
        results.SetActive(true);

        yield return new WaitForSeconds(3f);

        // Boîte de dialogue

        results.SetActive(false);
        pPierre.SetActive(false);
        pFeuille.SetActive(false);
        pCiseaux.SetActive(false);
        rPierre.SetActive(false);
        rFeuille.SetActive(false);
        rCiseaux.SetActive(false);
        pHand.SetActive(false);
        rHand.SetActive(false);

        bController.ok = false;
        bController.fini = false;
    }

    public void PWins()
    {
        pPoints += 1;
        resultsText.SetText("Super !");
        pPointsText.SetText(pPoints.ToString() + "/5");
    }

    public void RWins()
    {
        rPoints += 1;
        resultsText.SetText("Roland l'emporte !");
        rPointsText.SetText(rPoints.ToString() + "/5");
    }

    public void Draw()
    {
        resultsText.SetText("Egalite");
    }
}
