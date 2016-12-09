using UnityEngine;
using System.Collections;

public class Selecter : MonoBehaviour
{
    public static GameObject selectedObject;

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private int X, Y, Z;

    private Vector2 move;

    void Start()
    {
        ClearSelected();
    }

	void Update ()
    {
        Rotate();
        RayCaster();
	}

    private void RayCaster()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.transform.gameObject;

            if (hitObject)

                if (Input.GetKeyDown("mouse 0"))
                {
                    if (hitObject.tag != "tile") { SelectObject(hitObject); }
                    else { ClearSelected(); }
                }
            if (Input.GetKeyDown("mouse 1") && selectedObject && CheckInRange(hitObject))
            {
                MoveTo(hitObject);
            }
        }
    }

    private void Rotate()
    {
        cube.transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }

    private bool CheckInRange(GameObject obj)
    {
        bool inrange = false;
        Vector3 unit = selectedObject.transform.position;
        Vector3 tile = obj.transform.position;
        Vector3 diffrence = unit - tile;
        Debug.Log(diffrence);
        if ((diffrence.x < 2 && diffrence.x > -2) && (diffrence.z < 2 && diffrence.z > -2))
        {
            inrange = true;
        }
        return inrange;
    }

    private void MoveTo(GameObject obj)
    {
        if ((selectedObject.tag == "hero" && Turn.herosTurn) || (selectedObject.tag == "monster" && !Turn.herosTurn))
        {
            if (obj.tag == "tile" || obj.tag == "token" || obj.tag == "deadToken")
            {
                selectedObject.transform.position = obj.transform.position;
                MoveToSelected(selectedObject);
            }
        }
    }

    private void ClearSelected()
    {
        cube.SetActive(false);
        selectedObject = null;
        Debug.Log( "clear selected");
    }

    private void SelectObject(GameObject obj)
    {
        MoveToSelected(obj);
        selectedObject = obj;
        Debug.Log(obj.name + " is selected");
    }

    private void MoveToSelected(GameObject obj)
    {
        cube.SetActive(true);
        this.transform.position = obj.transform.position;
        selectedObject = obj;
    }
}
