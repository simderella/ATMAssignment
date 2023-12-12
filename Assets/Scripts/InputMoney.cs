using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMoney : MonoBehaviour
{
    public Text moneyText; // 화면에 현재 금액을 표시할 텍스트
    public Text balanceMoneyText; //화면에 현재 잔액을 표시할 텍스트
    private int currentMoney = 100000; // 초기 금액
    private int balanceMoney = 50000; // 초기 잔액
    public GameObject LessMoneyPanel;
    public InputField depositInput;
    public InputField withdrawInput;
    public Button depositButton;
    void Start()
    {
        UpdateMoneyText();  // 초기 잔액을 표시
    }
    public void OndepositButton()
    {
        depositButton.onClick.AddListener(Deposit);
    }
    void UpdateMoneyText()
    {
        moneyText.text = currentMoney.ToString("C0"); // C0는 통화 형식으로 표시하고 콤마(,)를 붙여줍니다.
        balanceMoneyText.text = balanceMoney.ToString("C0");
    }

    public void OnInButtonClick(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            balanceMoney += amount;
            UpdateMoneyText();

            // 여기에 입금 로직을 추가하세요.
            DepositMoney(amount);
        }
        else
        {
            //Debug.Log("잔액 부족");
            // 잔액이 부족할 때 처리할 내용을 여기에 추가하세요.
            MoneyLess();
        }
    }

    public void Deposit()
    {
        // 입력된 금액을 가져오기
        string depositAmountString = depositInput.text;

        // 입력된 금액이 유효한지 확인
        if (int.TryParse(depositAmountString, out int depositAmount))
        {
            if(currentMoney >= depositAmount) 
            {
                // 입금 실행
                currentMoney -= depositAmount;
                balanceMoney += depositAmount;
            }
            else
            {
                MoneyLess();
            }
            // 잔액 업데이트
            UpdateMoneyText();

        }
        else
        {
            // 유효하지 않은 입력일 경우 처리
            Debug.LogError("유효하지 않은 금액입니다.");
        }

    }

    public void OnOutButtonClick(int amount)
    {
        if (balanceMoney >= amount)
        {
            currentMoney += amount;
            balanceMoney -= amount;
            UpdateMoneyText();

            // 여기에 출금 로직을 추가하세요.
            WithdrawMoney(amount);
        }
        else
        {
            //Debug.Log("잔액 부족");
            // 잔액이 부족할 때 처리할 내용을 여기에 추가하세요.
            MoneyLess();
        }
    }

    void DepositMoney(int amount)
    {
        // 여기에 입금 로직을 추가하세요.
        // 예를 들어, 데이터베이스 업데이트, 게임 내 가상 자산 증가 등을 수행할 수 있습니다.
        Debug.Log(amount.ToString("C0") + " 입금 완료");
    }
    void WithdrawMoney(int amount)
    {
        // 여기에 입금 로직을 추가하세요.
        // 예를 들어, 데이터베이스 업데이트, 게임 내 가상 자산 증가 등을 수행할 수 있습니다.
        Debug.Log(amount.ToString("C0") + " 출금 완료");
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
}
