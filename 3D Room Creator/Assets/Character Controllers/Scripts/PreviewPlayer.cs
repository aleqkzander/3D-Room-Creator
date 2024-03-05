using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewPlayer : MonoBehaviour
{
    public GameObject PreviewCameraReference;
    public GameObject Player;

    public void ChangeState(bool state)
    {
        if (state)
        {
            PreviewCameraReference.SetActive(false);
        }
        else
        {
            PreviewCameraReference.SetActive(true);
        }

        Player.SetActive(state);
    }
}
