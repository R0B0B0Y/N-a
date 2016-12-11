using UnityEngine;
using System.Collections;
using Assets.Scripts;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected string name;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int defence;

    private Weapon weapon = new Weapon();

    private Vector2 gridPos;

    private bool turnTaken;

    private int actionNum;

    private int maxHealth, maxSpeed;

	// Use this for initialization
	void Start ()
    {
        maxHealth = health;
        maxSpeed = speed;
        gridPos = this.transform.position;
	}

    public virtual string GiveInfo()
    {
        string info = name + "\n health " + health + "\n speed " + speed + "\n defence " + defence;
        return info;
    }
	
    public virtual void Destroyer()
    {
        Destroy(gameObject);
    }

    public void Move(GameObject obj)
    {
            if (obj.tag == "tile" || obj.tag == "token" || obj.tag == "deadToken")
            {
                this.transform.position = obj.transform.position;
            }
    }

    public void Deffence(int damage)
    {
        int defence = 0;
        damage = defence - damage;
        if (health < 1) { Destroyer(); }
    }

    public void Attack()
    {
        
    }
}
