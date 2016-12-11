using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{

    public static int heroNum;

    public static GameObject heroOne, heroTwo, heroThree, heroFour ;

    [SerializeField]
    private Dropdown dropdownOne, dropdownTwo, dropdownThree, dropdownFour;

    [SerializeField]
    private Text textOne, textTwo, textThree, textFour;

    [SerializeField]
    private GameObject hero1, hero2, hero3, hero4, hero5, hero6, hero7, hero8;

    List<GameObject> Heros = new List<GameObject>();

    List<string> heros = new List<string>() { "Random", "Ashrian", "Avric Albright", "Grisban the Thirsty", "Jain Fairwood", "Leoric of the Book", "Syndrael", "Tomble Burrowell", "Widow Tarha" };

    void Start()
    {
        heroNum = 2;

        LoadHeros();

        heroOne = null;
        heroTwo = null;
        heroThree = null;
        heroFour = null;

        DisplayHeroInfo(heroOne, textOne);
        DisplayHeroInfo(heroTwo, textTwo);
        DisplayHeroInfo(heroThree, textThree);
        DisplayHeroInfo(heroFour, textFour);

        Populate(dropdownOne);
        Populate(dropdownTwo);
        Populate(dropdownThree);
        Populate(dropdownFour);
    }

    //Heros equals 
    private void LoadHeros()
    {
        Heros.Add(null);
        Heros.Add(hero1);
        Heros.Add(hero2);
        Heros.Add(hero3);
        Heros.Add(hero4);
        Heros.Add(hero5);
        Heros.Add(hero6);
        Heros.Add(hero7);
        Heros.Add(hero8);
    }


    // this is called on stat game
    public void StartGame()
    {
        if (!heroOne) { heroOne = RandomHero(); }
        if (!heroTwo) { heroTwo = RandomHero(); }
        if (!heroThree) { heroThree = RandomHero(); }
        if (!heroFour) { heroFour = RandomHero(); }
        
    }

    void Populate(Dropdown dropDown)
    {
        dropDown.AddOptions(heros);
    }

    public void indexChangeOne(int index)
    {
        heroOne = Heros[index];
        DisplayHeroInfo(heroOne, textOne);
    }

    public void indexChangeTwo(int index)
    {
        heroTwo = Heros[index];
        DisplayHeroInfo(heroTwo, textTwo);
    }

    public void indexChangeThree(int index)
    {
        heroThree = Heros[index];
        DisplayHeroInfo(heroThree, textThree);
    }

    public void indexChangeFour(int index)
    {
        heroFour = Heros[index];
        DisplayHeroInfo(heroFour, textFour);
    }

    //called when char num change
    public void SetCharNum(int index)
    {
        Debug.Log(index);
        switch (index)
        {
            case 2:
                heroNum = 4;
                break;
            case 1:
                heroNum = 3; 
                break;
            default:
                heroNum = 2;
                break;
        }
        Debug.Log(heroNum);
    }

    private void DisplayHeroInfo(GameObject obj,Text text)
    {
        if (obj)
        {
            Unit Skripet = obj.GetComponent<Unit>();
            text.text = Skripet.GiveInfo();
        }
        else
        {
            text.text = "??????????????????";
        }             
    }

    private GameObject RandomHero()
    {
        int index = Random.Range(1, 9);
        Debug.Log(index);
        GameObject obj = Heros[index];
        Debug.Log(obj.name);
        return obj;
    }
}
