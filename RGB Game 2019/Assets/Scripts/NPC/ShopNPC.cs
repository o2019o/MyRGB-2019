using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour {
    private GameObject shopUI;
    private TweenPosition tween;

    public GameObject buyBut1, buyBut2, buyBut3, closeBut, okBut, numberInput_UI;
    private UIInput numberInput;
	// Use this for initialization
	void Start () {
        shopUI = GameObject.Find("ShopUI");
        tween = shopUI.GetComponent<TweenPosition>();
        numberInput_UI = GameObject.Find("NumberInputUI");
        numberInput = numberInput_UI.GetComponentInChildren<UIInput>();
        okBut = numberInput_UI.GetComponentInChildren<UIButton>().gameObject;

        buyBut1 = GameObject.Find("BuyButton1");
        buyBut1.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1001));
        buyBut2 = GameObject.Find("BuyButton2");
        buyBut2.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1002));
        buyBut3 = GameObject.Find("BuyButton3");
        buyBut3.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnBuy1003));
        closeBut = GameObject.Find("CloseBut");
        closeBut.GetComponent<UIButton>().onClick.Add(new EventDelegate(OnCloseButClick));
    }

    private void OnCloseButClick()
    {

    }

    private void OnBuy1003()
    {

    }

    private void OnBuy1002()
    {

    }

    private void OnBuy1001()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
