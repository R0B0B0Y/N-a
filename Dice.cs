using UnityEngine;
using System.Collections;

class Dice
{
    public int RollDice()
    {
        int roll;
        roll = Random.Range(0, 7); //dice
        int damage;
        switch (roll)
        {
            case 6:
                damage = 5;
                break;
            case 5:
                damage = 4;
                break;
            case 4:
                damage = 2;
                break;
            case 3:
                damage = 2;
                break;
            case 2:
                damage = 1;
                break;
            case 1:
                damage = 0;
                break;
            default:
                damage = 0;
                break;
        }

        return damage;
    }
	
}
