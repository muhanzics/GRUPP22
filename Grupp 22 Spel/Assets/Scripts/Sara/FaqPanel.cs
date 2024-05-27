using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaqPanel : MonoBehaviour
{
    [SerializeField] private GameObject faqPanel;

    public void ShowFaq()
    {
        faqPanel.SetActive(true);
    }

    public void CloseFaq()
    {
        faqPanel.SetActive(false);
    }

}