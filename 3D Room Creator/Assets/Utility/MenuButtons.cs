using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons
{
    public static void StartListenerCreateNewRoom(Button button, GameObject mainmenuinterface)
    {
        button.onClick.AddListener(() =>
        {
            mainmenuinterface.SetActive(false);
        });
    }

    public static void StartListenerSaveCurrentRoom(Button button)
    {
        button.onClick.AddListener(() =>
        {
            throw new System.NotImplementedException();
        });
    }

    public static void StartListenerLoadPreviousRoom(Button button, GameObject mainmenuinterface)
    {
        button.onClick.AddListener(() =>
        {
            mainmenuinterface.SetActive(false);
        });
    }

    public static void StartListenerDeleteCurrentRoom(Button button)
    {
        button.onClick.AddListener(() =>
        {
            throw new System.NotImplementedException();
        });
    }

    public static void StartListenerAddAnotherRoom(Button button)
    {
        button.onClick.AddListener(() =>
        {
            throw new System.NotImplementedException();
        });
    }

    public static void StartListenerChangeViewButton(ChangeViewButton changeviewbutton)
    {
        changeviewbutton.Button.onClick.AddListener(() =>
        {
            changeviewbutton.ChangeState();
        });
    }

    public static void StartListenerBackHome(Button button, GameObject mainmenuinterface)
    {
        button.onClick.AddListener(() =>
        {
            mainmenuinterface.SetActive(true);
        });
    }
}
