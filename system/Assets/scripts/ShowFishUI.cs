using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ShowFishUI : MonoBehaviour
{
    [SerializeField] private Text ShowUI;
    [SerializeField] private Image background;
    void start ()
    {

    }
    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            ShowUI.gameObject.SetActive (true);
            background.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            ShowUI.gameObject.SetActive (false);
            background.gameObject.SetActive (false);
        }
    }
}