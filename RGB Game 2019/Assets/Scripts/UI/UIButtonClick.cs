using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonClick : MonoBehaviour {

    private UIButton statusBut, bagBut, equipBut, skillBut, settingBut;
	// Use this for initialization
	void Start () {
        statusBut = transform.GetChild(0).GetComponent<UIButton>();
        statusBut.onClick.Add(new EventDelegate(OnStatusClick));
        bagBut = transform.GetChild(1).GetComponent<UIButton>();
        bagBut.onClick.Add(new EventDelegate(OnBagClick));
        equipBut = transform.GetChild(2).GetComponent<UIButton>();
        equipBut.onClick.Add(new EventDelegate(OnEquipClick));
        skillBut = transform.GetChild(3).GetComponent<UIButton>();
        skillBut.onClick.Add(new EventDelegate(OnSkillClick));
        settingBut = transform.GetChild(4).GetComponent<UIButton>();
        settingBut.onClick.Add(new EventDelegate(OnSettingClick));
    }

    private void OnSettingClick()
    {
    }

    private void OnSkillClick()
    {

    }

    private void OnEquipClick()
    {

    }

    private void OnBagClick()
    {
        UIInventory.Instance.SetTweemPos();
    }

    private void OnStatusClick()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
