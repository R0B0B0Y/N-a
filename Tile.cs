using UnityEngine;
using System.Collections;


public class Tile : MonoBehaviour
{
	void Update ()
    {
        GameObject obj = Selecter.selectedObject;
        if (obj)
        {
            Renderer r = this.GetComponent<Renderer>();
            r.enabled = CheckInRange(obj);

        }
    }

    private bool CheckInRange(GameObject obj)
    {
        bool inrange = false;
        Vector3 unit = obj.transform.position;
        Vector3 tile = this.transform.position;
        Vector3 diffrence = unit - tile;
        if ((diffrence.x < 2 && diffrence.x > -2) && (diffrence.z < 2 && diffrence.z > -2))
        {
            inrange = true;
        }
        return inrange;
    }
}
