using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject depositPanel;
    public GameObject depositButton;
    public GameObject withdrawPanel;
    public GameObject withdrawButton;
    void Awake()
    {
        I = this;
    }

    public void deposit()
    {
        depositPanel.SetActive(true);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }
    public void withdraw()
    {
        withdrawPanel.SetActive(true);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }

    public void depositBack()
    {
        depositPanel.SetActive(false);
        depositButton.SetActive(true);
        withdrawButton.SetActive(true);
    }
    public void withdrawBack()
    {
        withdrawPanel.SetActive(false);
        depositButton.SetActive(true);
        withdrawButton.SetActive(true);
    }

}
