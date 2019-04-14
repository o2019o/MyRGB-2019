using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour {
    private GameObject shopUI;
    private TweenPosition tween;
    private int buy_id;

    public GameObject buyBut1, buyBut2, buyBut3, closeBut, okBut, numberInput_UI;
    private UIInput numberInput;
	// Use this for initialization
	void Start () {
        shopUI = GameObject.Find("ShopUI");
        tween = shopUI.GetComponent<TweenPosition>();

        numberInput_UI = GameObject.Find("NumberInputUI");
        numberInput = numberInput_UI.GetComponentInChildren<UIInput>();
        okBut = numberInput_UI.GetComponentInChildren<UIButton>().gameObject;
        okBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnOKClick));
        numberInput_UI.SetActive(false);

        buyBut1 = GameObject.Find("BuyButton1");
        buyBut1.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1001));
        buyBut2 = GameObject.Find("BuyButton2");
        buyBut2.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1002));
        buyBut3 = GameObject.Find("BuyButton3");
        buyBut3.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1003));
        closeBut = GameObject.Find("CloseBut");
        closeBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnCloseButClick));
    }
    private void BuyItem(int id)
    {
        buy_id = id;
        ShowNumberDiglog();
    }
    private void ShowNumberDiglog()
    {
        numberInput_UI.SetActive(true);
        numberInput.value = "0";
    }
    private void OnOKClick()
    {
        int inputCount = int.Parse(numberInput.value);
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(buy_id);
        int price = info.price_buy;
        int price_total = price * inputCount;
        bool total = UIInventory.Instance.GetCoinCount(price_total);
        if(total)
        {
            if(inputCount > 0)
            {
                UIInventory.Instance.GetItemId(buy_id, inputCount);
            }
        }
        numberInput_UI.SetActive(false);
    }

    private void OnCloseButClick()
    {
        tween.PlayReverse();
    }

    private void OnBuy1003()
    {
        BuyItem(1003);
    }

    private void OnBuy1002()
    {
        BuyItem(1002);
    }

    private void OnBuy1001()
    {
        BuyItem(1001);
    }
    private bool isShow = false;
    private void SetTweenPos()
    {
        if(!isShow)
        {
            tween.PlayForward();isShow = true;
        }
        else
        {
            tween.PlayReverse();isShow = false;
        }
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetTweenPos();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
