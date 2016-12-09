using UnityEngine;
using System.Collections;

public class Monster : Unit
{
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
        string info = "monster :" + name + "\n health :" + health + "\n speed :" + speed + "\n defence :" + defence;
        return info;
    }

    public override void Destroyer()
    {
        Destroy(gameObject);
    }
}
