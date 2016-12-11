using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultHero;
    [SerializeField]
    private GameObject token;
    [SerializeField]
    private GameObject mauler;
    [SerializeField]
    private GameObject goblin;

    private GameObject heroOne, heroTwo, heroThree, heroFour;

    private int heroNumber;

    // Use this for initialization
    void Start()
    {
        heroNumber = StartSelect.heroNum;
        heroOne = LoadHero(StartSelect.heroOne);
        heroTwo = LoadHero(StartSelect.heroTwo);
        heroThree = LoadHero(StartSelect.heroThree);
        heroFour = LoadHero(StartSelect.heroFour);

        Spawn();
        
    }

    private GameObject LoadHero(GameObject obj)
    {
        if (obj)
        {
            return obj;
        }
        else
        {
            return defaultHero;
        }
    }
    
    private void Spawn()
    {
        Instantiate(token, new Vector3(5, 0, 3), this.transform.rotation);
        Instantiate(token, new Vector3(5, 0, 10), this.transform.rotation);
        Instantiate(heroOne, new Vector3(11, 0, 2), this.transform.rotation);
        Instantiate(heroTwo, new Vector3(11, 0, 3), this.transform.rotation);
        Instantiate(goblin, new Vector3(11, 0, 6), this.transform.rotation);
        Instantiate(goblin, new Vector3(11, 0, 7), this.transform.rotation);

        if (heroNumber > 2)
        {
            Instantiate(token, new Vector3(13, 0, 7), this.transform.rotation);
            Instantiate(goblin, new Vector3(12, 0, 6), this.transform.rotation);
            Instantiate(heroThree, new Vector3(10, 0, 3), this.transform.rotation);
        }
        if (heroNumber > 3)
        {
            Instantiate(token, new Vector3(1, 0, 5), this.transform.rotation);
            Instantiate(goblin, new Vector3(12, 0, 7), this.transform.rotation);
            Instantiate(heroFour, new Vector3(10, 0, 2), this.transform.rotation);
        }
        Instantiate(mauler, new Vector3(7, 0, 10), this.transform.rotation);
    }

    
}
