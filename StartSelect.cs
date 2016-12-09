using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{

    public static int heroNum;

    public static GameObject heroOne, heroTwo, heroThree, heroFour ;

    [SerializeField]
    private Dropdown one, two, three, four;

    [SerializeField]
    private Text textOne, textTwo, textThree, textFour;

    [SerializeField]
    private GameObject Hero1, Hero2, Hero3, Hero4, Hero5, Hero6, Hero7, Hero8;

    private int i1, i2, i3, i4;

    void Start()
    {
        heroNum = 2;

        heroOne = null;
        heroTwo = null;
        heroThree = null;
        heroFour = null;

        DisplayHeroInfo(heroOne, textOne);
        DisplayHeroInfo(heroTwo, textTwo);
        DisplayHeroInfo(heroThree, textThree);
        DisplayHeroInfo(heroFour, textFour);

        Populate(one);
        Populate(two);
        Populate(three);
        Populate(four);
    }

    // this is called on stat game
    public void StartGame()
    {
        heroOne = RandomHero(i1);
        heroTwo = RandomHero(i2);
        heroThree = RandomHero(i3);
        heroFour = RandomHero(i4);
    }

    void Populate(Dropdown dropDown)
    {
        List<string> heros = new List<string>() { "Random", "Ashrian", "Avric Albright", "Grisban the Thirsty", "Jain Fairwood", "Leoric of the Book", "Syndrael", "Tomble Burrowell", "Widow Tarha" };
        dropDown.AddOptions(heros);
    }

    public void indexChangeOne(int index)
    {
        i1 = index;
        heroOne = LoadHero(i1);
        DisplayHeroInfo(heroOne, textOne);
        string hero = heros[index];
        Debug.Log(hero);
    }
    public void indexChangeTwo(int index)
    {
        i2 = index;
        heroTwo = LoadHero(i2);
        DisplayHeroInfo(heroTwo, textTwo);
        string hero = heros[index];
        Debug.Log(hero);
    }
    public void indexChangeThree(int index)
    {
        i3 = index;
        heroThree = LoadHero(i3);
        DisplayHeroInfo(heroThree, textThree);
        string hero = heros[index];
        Debug.Log(hero);
    }
    public void indexChangeFour(int index)
    {
        i4 = index;
        heroFour = LoadHero(i4);
        DisplayHeroInfo(heroFour, textFour);
        string hero = heros[index];
        Debug.Log(hero);
    }

    //called when char num change
    public void SetCharNum(int index)
    {
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

    private GameObject RandomHero(int index)
    {
        if(index == 0)
        {
            index = Random.Range(1, 9);
            Debug.Log(index);
        }

        GameObject obj = LoadHero(index);
        return obj;
    }

    private GameObject LoadHero(int index)
    {
        GameObject hero;
        switch (index)
        {
            case 1:
                hero = Hero1;
                break;
            case 2:
                hero = Hero2;
                break;
            case 3:
                hero = Hero3;
                break;
            case 4:
                hero = Hero4;
                break;
            case 5:
                hero = Hero5;
                break;
            case 6:
                hero = Hero6;
                break;
            case 7:
                hero = Hero7;
                break;
            case 8:
                hero = Hero8;
                break;
            default:
                hero = null;
                break;
        }
        return hero;
    }

}
