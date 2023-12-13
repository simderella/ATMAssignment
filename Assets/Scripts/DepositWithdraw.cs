using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositWithdraw : MonoBehaviour

{
    public GameObject depositPanel;
    public GameObject depositButton;
    public GameObject withdrawPanel;
    public GameObject withdrawButton;
    public void Deposit()
    {
        depositPanel.SetActive(true);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }
    public void Withdraw()
    {
        withdrawPanel.SetActive(true);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }

    public void DepositBack()
    {
        depositPanel.SetActive(false);
        depositButton.SetActive(true);
        withdrawButton.SetActive(true);
    }
    public void WithdrawBack()
    {
        withdrawPanel.SetActive(false);
        depositButton.SetActive(true);
        withdrawButton.SetActive(true);
    }
}
