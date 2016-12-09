using UnityEngine;
using System.Collections;

public class Hero : Unit
{
    [SerializeField]
    private int stamina, might, willpower, awareness, knowledge;

    [SerializeField]
    private string archetype;

    [SerializeField]
    private GameObject deadToken;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public override string GiveInfo()
    {
        string info = "hero :" + name + "\n health :" + health + "\n speed :" + speed + "\n defence :" + defence + "\n stamina :" + stamina + "\n type :" + archetype;
        return info;
    }

    public override void Destroyer()
    {
        Destroy(gameObject);
        Instantiate(deadToken, this.transform.position, this.transform.rotation);
    }
}
