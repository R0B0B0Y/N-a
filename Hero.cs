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

    private int maxStamina;
    // Use this for initialization
    void Start ()
    {
        maxStamina = stamina;
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

    public void Skill() { }
    public void Rest() { }
    public void Search() { }
    public void StandUp() { }
    public void ReviveHero() { }
    public void OpenCloseDoor() { }
    public void Special() { }

}
