using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public static GameObject selectedUnit;

    public static bool herosTurn = true;

    [SerializeField]
    private GameObject turnUI, actionUI, heroDataUI, abilityUI;

    [SerializeField]
    private Text errortext, infoText, turnText;

    private GameObject hero;

    private bool bossAlive = true;

    private int overlordTokens = 0;

    void Start()
    {
        herosTurn = true;
        turnText.text = "Heros Turn";

        heroDataUI.SetActive(false);
        actionUI.SetActive(false);
        abilityUI.SetActive(false);
    }

    public void DisplaySelected(GameObject obj)
    {
        abilityUI.SetActive(false);
        actionUI.SetActive(false);
        if (obj)
        {
            heroDataUI.SetActive(true);
            if (obj.tag == "hero")
            {
                Unit Skripet = obj.GetComponent<Unit>();
                infoText.text = Skripet.GiveInfo();
                if (herosTurn) { actionUI.SetActive(true); }
            }
            if (obj.tag == "monster")
            {
                Unit Skripet = obj.GetComponent<Unit>();
                infoText.text = Skripet.GiveInfo();
                if (!herosTurn) { actionUI.SetActive(true); }
            }
            if (obj.tag == "token")
            {
                infoText.text = "this is a token";
            }
        }
        else
        {
            infoText.text = null;
            heroDataUI.SetActive(false);
        }
    }

    public void DoAction()
    {
        GameObject obj = Selecter.selectedObject;
        selectedUnit = obj;
        if (herosTurn) { HeroAction(obj); }
        else { OverlordAction(obj); }
    }

    public void OverlordAction(GameObject obj)
    {
        Debug.Log("overlord action");
        actionUI.SetActive(false);
    }

    public void HeroAction(GameObject obj)
    {
        Debug.Log("hero action");
        actionUI.SetActive(false);
    }

    public void ToggleTurn()
    {
        herosTurn = !herosTurn;

        heroDataUI.SetActive(false);
        actionUI.SetActive(false);
        abilityUI.SetActive(false);
    }

    public void EndTurn()
    {
        if (!bossAlive)
        {
            Debug.Log("HerosWin");
        }
        if (overlordTokens > 4)
        {
            Debug.Log("OverLoardWin");
        }

        ToggleTurn();

        if (herosTurn)
        {
            Debug.Log("HerosTurn");
            turnText.text = "Heros Turn";
        }
        else
        {
            Debug.Log("OverLoardTurn");
            turnText.text = "OverLords Turn";
        }
    }
}
