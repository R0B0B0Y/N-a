using UnityEngine;
using System.Collections;

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

    private Vector2 gridPos;

    private bool turnTaken;

    private int actionNum;

	// Use this for initialization
	void Start ()
    {
        gridPos = this.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (health < 1) { Distroyer(); }

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
}
