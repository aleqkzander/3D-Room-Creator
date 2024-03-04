using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCenter : MonoBehaviour
{
    public static ControlCenter Instance { get; private set; }

    [Header("MainMenuInterface")]
    [Space(5)]
    public GameObject MainMenuInterface;

    [Header("MainMenuButtons")]
    [Space(5)]
    public Button ButtonOpenEditorInterface;
    public Button ButtonSaveCurrentRoom;
    public Button ButtonLoadPreviousRoom;
    public Button ButtonDeleteCurrentRoom;

    [Header("CreationMenuButtons")]
    [Space(5)]
    public Button ButtonAddAnotherRoom;
    public ChangeViewButton ButtonChangeView;
    public Button ButtonBackHome;

    [Header("ObjectPlacer")]
    [Space(5)]
    public ObjectPlacer ObjectPlacer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            StartListenerForReferencedButtons();
        }
    }

    private void StartListenerForReferencedButtons()
    {
        /*
         * Main menu buttons
         */
        ButtonListener.StartListenerCreateNewRoom(ButtonOpenEditorInterface, MainMenuInterface);
        ButtonListener.StartListenerSaveCurrentRoom(ButtonSaveCurrentRoom, ObjectPlacer);
        ButtonListener.StartListenerLoadPreviousRoom(ButtonLoadPreviousRoom, MainMenuInterface, ObjectPlacer);
        ButtonListener.StartListenerDeleteCurrentRoom(ButtonDeleteCurrentRoom);

        /*
         * Creation menu buttons
         */
        ButtonListener.StartListenerAddAnotherRoom(ButtonAddAnotherRoom);
        ButtonListener.StartListenerChangeViewButton(ButtonChangeView);
        ButtonListener.StartListenerBackHome(ButtonBackHome, MainMenuInterface);
    }
}
