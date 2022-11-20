using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    private bool success = false;
    private string touchPressed = null;
    private bool waiting = false;
    private float horizontal;
    private float act;
    public Sprite eSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public GameObject action;
    private SpriteRenderer actionSprite;
    [SerializeField] private GameObject bienouej;
    [SerializeField] private LvlLoaderv2 loader;
    public int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        actionSprite = action.GetComponent<SpriteRenderer>();
        StartCoroutine(QTEGame());
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting)
        {
            act = Input.GetAxisRaw("Fire1");
            horizontal = Input.GetAxisRaw("Horizontal");
            if (act > 0.1)
            {
                touchPressed = "e";
            }
            else if (horizontal > 0.1)
            {
                touchPressed = "Right";
            }
            else if (horizontal < -0.1)
            {
                touchPressed = "Left";
            }
            else
            {
                touchPressed = null;
            }
        }

        if (success)
        {
            bienouej.SetActive(true);
        }
        else
        {
            bienouej.SetActive(false);
        }
    }

    IEnumerator QTEGame()
    {
        // Première boîte de dialogue : lever aile droite (droite)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = rightSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Right")
            {
                success = true;
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Deuxième boîte de dialogue : lever aile gauche (gauche)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = leftSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Left")
            {
                success = true;
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Troisième boîte de dialogue : battre des ailes (e)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = eSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "e")
            {
                success = true;
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Quatrième boîte de dialogue : lever les deux ailes puis les battre (droite -> gauche -> e)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = rightSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Right")
            {
                action.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                action.SetActive(true);
                actionSprite.sprite = leftSprite;
                yield return new WaitUntil(() => touchPressed == null);
                yield return new WaitUntil(() => touchPressed != null);
                if (touchPressed == "Left")
                {
                    action.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    action.SetActive(true);
                    actionSprite.sprite = eSprite;
                    yield return new WaitUntil(() => touchPressed == null);
                    yield return new WaitUntil(() => touchPressed != null);
                    if(touchPressed == "e")
                    {
                        success = true;
                    }
                }
            }
            if (!success)
            {
                // PERDU LOL (faire pareil partout)
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Cinquième boîte de dialogue : répéter plusieurs fois l'action (droite -> gauche -> e -> gauche -> droite -> e -> e) : l'oiseau vole en l'air mtn
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = rightSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Right")
            {
                action.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                action.SetActive(true);
                actionSprite.sprite = leftSprite;
                yield return new WaitUntil(() => touchPressed == null);
                yield return new WaitUntil(() => touchPressed != null);
                if (touchPressed == "Left")
                {
                    action.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    action.SetActive(true);
                    actionSprite.sprite = eSprite;
                    yield return new WaitUntil(() => touchPressed == null);
                    yield return new WaitUntil(() => touchPressed != null);
                    if (touchPressed == "e")
                    {
                        action.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        action.SetActive(true);
                        actionSprite.sprite = leftSprite;
                        yield return new WaitUntil(() => touchPressed == null);
                        yield return new WaitUntil(() => touchPressed != null);
                        if (touchPressed == "Left")
                        {
                            action.SetActive(false);
                            yield return new WaitForSeconds(0.1f);
                            action.SetActive(true);
                            actionSprite.sprite = rightSprite;
                            yield return new WaitUntil(() => touchPressed == null);
                            yield return new WaitUntil(() => touchPressed != null);
                            if (touchPressed == "Right")
                            {
                                action.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                action.SetActive(true);
                                actionSprite.sprite = eSprite;
                                yield return new WaitUntil(() => touchPressed == null);
                                yield return new WaitUntil(() => touchPressed != null);
                                if (touchPressed == "e")
                                {
                                    action.SetActive(false);
                                    yield return new WaitForSeconds(0.1f);
                                    action.SetActive(true);
                                    actionSprite.sprite = eSprite;
                                    yield return new WaitUntil(() => touchPressed == null);
                                    yield return new WaitUntil(() => touchPressed != null);
                                    if (touchPressed == "e")
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!success)
            {
                // PERDU LOL (faire pareil partout)
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Sixième boîte de dialogue : on veut tourner à gauche (droite -> e -> droite -> e -> droite -> e -> gauche -> e)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = rightSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Right")
            {
                action.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                action.SetActive(true);
                actionSprite.sprite = eSprite;
                yield return new WaitUntil(() => touchPressed == null);
                yield return new WaitUntil(() => touchPressed != null);
                if (touchPressed == "e")
                {
                    action.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    action.SetActive(true);
                    actionSprite.sprite = rightSprite;
                    yield return new WaitUntil(() => touchPressed == null);
                    yield return new WaitUntil(() => touchPressed != null);
                    if (touchPressed == "Right")
                    {
                        action.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        action.SetActive(true);
                        actionSprite.sprite = eSprite;
                        yield return new WaitUntil(() => touchPressed == null);
                        yield return new WaitUntil(() => touchPressed != null);
                        if (touchPressed == "e")
                        {
                            action.SetActive(false);
                            yield return new WaitForSeconds(0.1f);
                            action.SetActive(true);
                            actionSprite.sprite = leftSprite;
                            yield return new WaitUntil(() => touchPressed == null);
                            yield return new WaitUntil(() => touchPressed != null);
                            if (touchPressed == "Left")
                            {
                                action.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                action.SetActive(true);
                                actionSprite.sprite = eSprite;
                                yield return new WaitUntil(() => touchPressed == null);
                                yield return new WaitUntil(() => touchPressed != null);
                                if (touchPressed == "e")
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Septième : idem à droite (gauche -> e -> gauche -> e -> gauche -> e -> droite -> e)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = leftSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "Left")
            {
                action.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                action.SetActive(true);
                actionSprite.sprite = eSprite;
                yield return new WaitUntil(() => touchPressed == null);
                yield return new WaitUntil(() => touchPressed != null);
                if (touchPressed == "e")
                {
                    action.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    action.SetActive(true);
                    actionSprite.sprite = leftSprite;
                    yield return new WaitUntil(() => touchPressed == null);
                    yield return new WaitUntil(() => touchPressed != null);
                    if (touchPressed == "Left")
                    {
                        action.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        action.SetActive(true);
                        actionSprite.sprite = eSprite;
                        yield return new WaitUntil(() => touchPressed == null);
                        yield return new WaitUntil(() => touchPressed != null);
                        if (touchPressed == "e")
                        {
                            action.SetActive(false);
                            yield return new WaitForSeconds(0.1f);
                            action.SetActive(true);
                            actionSprite.sprite = rightSprite;
                            yield return new WaitUntil(() => touchPressed == null);
                            yield return new WaitUntil(() => touchPressed != null);
                            if (touchPressed == "Right")
                            {
                                action.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                action.SetActive(true);
                                actionSprite.sprite = eSprite;
                                yield return new WaitUntil(() => touchPressed == null);
                                yield return new WaitUntil(() => touchPressed != null);
                                if (touchPressed == "e")
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        success = false;


        // Huitième : un LOOPING (e -> e -> e -> e -> e -> e)
        action.SetActive(true);
        waiting = true;
        do
        {
            actionSprite.sprite = eSprite;
            yield return new WaitUntil(() => touchPressed == null);
            yield return new WaitUntil(() => touchPressed != null);
            if (touchPressed == "e")
            {
                action.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                action.SetActive(true);
                actionSprite.sprite = eSprite;
                yield return new WaitUntil(() => touchPressed == null);
                yield return new WaitUntil(() => touchPressed != null);
                if (touchPressed == "e")
                {
                    action.SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    action.SetActive(true);
                    actionSprite.sprite = eSprite;
                    yield return new WaitUntil(() => touchPressed == null);
                    yield return new WaitUntil(() => touchPressed != null);
                    if (touchPressed == "e")
                    {
                        action.SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        action.SetActive(true);
                        actionSprite.sprite = eSprite;
                        yield return new WaitUntil(() => touchPressed == null);
                        yield return new WaitUntil(() => touchPressed != null);
                        if (touchPressed == "e")
                        {
                            action.SetActive(false);
                            yield return new WaitForSeconds(0.1f);
                            action.SetActive(true);
                            actionSprite.sprite = eSprite;
                            yield return new WaitUntil(() => touchPressed == null);
                            yield return new WaitUntil(() => touchPressed != null);
                            if (touchPressed == "e")
                            {
                                action.SetActive(false);
                                yield return new WaitForSeconds(0.1f);
                                action.SetActive(true);
                                actionSprite.sprite = eSprite;
                                yield return new WaitUntil(() => touchPressed == null);
                                yield return new WaitUntil(() => touchPressed != null);
                                if (touchPressed == "e")
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }
        } while (!success);
        waiting = false;
        action.SetActive(false);
        yield return new WaitForSeconds(3f);
        loader.LoadNextLevel(nextScene);
    }

}
