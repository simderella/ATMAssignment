using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText; // ȭ�鿡 ���� �ݾ��� ǥ���� �ؽ�Ʈ
    public Text balanceMoneyText; //ȭ�鿡 ���� �ܾ��� ǥ���� �ؽ�Ʈ
    private int currentMoney = 100000; // �ʱ� �ݾ�
    private int balanceMoney = 50000; // �ʱ� �ܾ�
    public GameObject LessMoneyPanel;
    public InputField depositInput;
    public InputField withdrawInput;
    public Button depositButton;
    public Button withdrawButton;

    void Start()
    {
        UpdateMoneyText();  // �ʱ� �ܾ��� ǥ��
        depositButton.onClick.AddListener(Deposit);
        withdrawButton.onClick.AddListener(Withdraw);
    }
    //public void OndepositButton()
    //{
    //    depositButton.onClick.AddListener(Deposit);
    //}
    //public void OnwithdrawButton()
    //{
    //    withdrawButton.onClick.AddListener(Withdraw);
    //}
    void UpdateMoneyText()
    {
        moneyText.text = currentMoney.ToString("C0"); // C0�� ��ȭ �������� ǥ���ϰ� �޸�(,)�� �ٿ��ݴϴ�.
        balanceMoneyText.text = balanceMoney.ToString("C0");
    }

    public void OnInButtonClick(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            balanceMoney += amount;
            UpdateMoneyText();

            // ���⿡ �Ա� ������ �߰��ϼ���.
            DepositMoney(amount);
        }
        else
        {
            //Debug.Log("�ܾ� ����");
            // �ܾ��� ������ �� ó���� ������ ���⿡ �߰��ϼ���.
            MoneyLess();
        }
    }

    public void Deposit()
    {
        // �Էµ� �ݾ��� ��������
        string depositAmountString = depositInput.text;

        // �Էµ� �ݾ��� ��ȿ���� Ȯ��
        if (int.TryParse(depositAmountString, out int depositAmount))
        {
            if(currentMoney >= depositAmount) 
            {
                // �Ա� ����
                currentMoney -= depositAmount;
                balanceMoney += depositAmount;
                // �ܾ� ������Ʈ
                UpdateMoneyText();
                ResetInputFields();
            }
            else
            {
                MoneyLess();
            }
        }
        else
        {
            // ��ȿ���� ���� �Է��� ��� ó��
            Debug.Log("��ȿ���� ���� �ݾ��Դϴ�.");
        }

    }


    public void OnOutButtonClick(int amount)
    {
        if (balanceMoney >= amount)
        {
            currentMoney += amount;
            balanceMoney -= amount;
            UpdateMoneyText();

            // ���⿡ ��� ������ �߰��ϼ���.
            WithdrawMoney(amount);
        }
        else
        {
            //Debug.Log("�ܾ� ����");
            // �ܾ��� ������ �� ó���� ������ ���⿡ �߰��ϼ���.
            MoneyLess();
        }
    }

    public void Withdraw()
    {
        // �Էµ� �ݾ��� ��������
        string withdrawAmountString = withdrawInput.text;

        // �Էµ� �ݾ��� ��ȿ���� Ȯ��
        if (int.TryParse(withdrawAmountString, out int withdrawAmount))
        {
            if (balanceMoney >= withdrawAmount)
            {
                // ��� ����
                currentMoney += withdrawAmount;
                balanceMoney -= withdrawAmount;
                // �ܾ� ������Ʈ
                UpdateMoneyText();
                ResetInputFields();
            }
            else
            {
                MoneyLess();
            }
        }
        else
        {
            // ��ȿ���� ���� �Է��� ��� ó��
            Debug.Log("��ȿ���� ���� �ݾ��Դϴ�.");
        }

    }

    void DepositMoney(int amount)
    {
        // ���⿡ �Ա� ������ �߰��ϼ���.
        // ���� ���, �����ͺ��̽� ������Ʈ, ���� �� ���� �ڻ� ���� ���� ������ �� �ֽ��ϴ�.
        Debug.Log(amount.ToString("C0") + " �Ա� �Ϸ�");
    }
    void WithdrawMoney(int amount)
    {
        // ���⿡ �Ա� ������ �߰��ϼ���.
        // ���� ���, �����ͺ��̽� ������Ʈ, ���� �� ���� �ڻ� ���� ���� ������ �� �ֽ��ϴ�.
        Debug.Log(amount.ToString("C0") + " ��� �Ϸ�");
    }
    void MoneyLess()
    {
        LessMoneyPanel.SetActive(true);
        Invoke("HideLessMoneyPanel", 1f);
    }
    void HideLessMoneyPanel()
    {
        LessMoneyPanel.SetActive(false);
    }

    void ResetInputFields()
    {
        depositInput.text = ""; // Clear deposit input field
        withdrawInput.text = ""; // Clear withdraw input field
    }
}
