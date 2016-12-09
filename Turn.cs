using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public static bool herosTurn = true;

    [SerializeField]
    private GameObject turn, action, heroData;

    [SerializeField]
    private Text errortext, infoText, turnText;

    private GameObject hero;

    private bool bossAlive = true;

    private int overlordTokens = 0;

    void Start()
    {
        herosTurn = true;
        turnText.text = "Heros Turn";
        heroData.SetActive(false);
        action.SetActive(false);
    }

    void Update ()
    {
        DisplaySelected(Selecter.selectedObject);
	}

    private void DisplaySelected(GameObject obj)
    {
        action.SetActive(false);
        if (obj)
        {
            heroData.SetActive(true);
            if (obj.tag == "hero")
            {
                Unit Skripet = obj.GetComponent<Unit>();
                infoText.text = Skripet.GiveInfo();
                if (herosTurn) { HeroAction(obj); }
            }
            if (obj.tag == "monster")
            {
                Unit Skripet = obj.GetComponent<Unit>();
                infoText.text = Skripet.GiveInfo();
                if (!herosTurn) { OverlordAction(obj); }
            }
            if (obj.tag == "token")
            {
                string info = "this is a token";
                infoText.text = info;
            }
        }
        else
        {
            infoText.text = null;
            heroData.SetActive(false);
            

        }
    }

    public void OverlordAction(GameObject obj)
    {
        action.SetActive(true);

    }

    public void HeroAction(GameObject obj)
    {
        action.SetActive(true);
        
    }

    public void ToggleTurn()
    {
        herosTurn = !herosTurn;
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
