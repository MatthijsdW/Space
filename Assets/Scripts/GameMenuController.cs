using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuController : MonoBehaviour
{

    private bool menuOpen = false;
    private GameObject panel;

    void Start()
    {
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(menuOpen);
        Cursor.visible = menuOpen;
    }

    public void OnToggleMenu(InputAction.CallbackContext context)
    {
        //Toggle whether the menu is open
        menuOpen = !menuOpen;
        panel.SetActive(menuOpen);
        Cursor.visible = menuOpen;

        //Toggle whether the game is paused
        Time.timeScale = menuOpen ? 0 : 1;
    }

    private void OnDestroy()
    {
        //Unpause the game, when the menu no longer exists.
        Time.timeScale = 1;
        Cursor.visible = true;
    }
}
