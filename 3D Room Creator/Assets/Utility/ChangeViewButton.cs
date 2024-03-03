using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChangeViewButton
{
    public Button Button;
    public List<Sprite> CurrentState;

    public void ChangeState()
    {
        if (Button.image.sprite == CurrentState[0])
        {
            Button.image.sprite = CurrentState[1];
        }
        else
        {
            Button.image.sprite = CurrentState[0];
        }
    }
}
