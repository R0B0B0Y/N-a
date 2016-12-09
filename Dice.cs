using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
    public int RollDice()
    {
        int roll;
        roll = Random.Range(0, 7); //dice
        return roll;
    }
	
}
