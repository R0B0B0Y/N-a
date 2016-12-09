using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;

    private bool menuOpen;
    
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("toggleMenu", gameObject);
            menuOpen = !menuOpen;
            Menu.gameObject.SetActive(menuOpen);
        }
    }

    public void CloseMenu()
    {

        Debug.Log("closeMenu", gameObject);
        menuOpen = false;
            Menu.gameObject.SetActive(false);
    }

    public void ChangeScene(string changeTo)
    {
       Application.LoadLevel(changeTo);
    }

    //reset the current scene
    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //closes the game
    public void Exit()
    {
        Application.Quit();
    }


}
