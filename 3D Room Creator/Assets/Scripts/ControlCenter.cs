using UnityEngine;
using UnityEngine.UI;

public class ControlCenter : MonoBehaviour
{
    public static ControlCenter Instance { get; private set; }

    [Header("Main menu interface")]
    [Space(5)]
    public GameObject MainMenuInterface;
    public Button ButtonCreateNewRoom;
    public Button ButtonSaveCurrentRoom;
    public Button ButtonLoadPreviousRoom;
    public Button ButtonDeleteCurrentRoom;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
            StartListenerForReferencedButtons();
        }
    }

    private void StartListenerForReferencedButtons()
    {
        MenuButtons.StartListenerCreateNewRoom(ButtonCreateNewRoom, MainMenuInterface);
        MenuButtons.StartListenerSaveCurrentRoom(ButtonSaveCurrentRoom);
        MenuButtons.StartListenerLoadPreviousRoom(ButtonLoadPreviousRoom, MainMenuInterface);
        MenuButtons.StartListenerDeleteCurrentRoom(ButtonDeleteCurrentRoom);
    }
}
