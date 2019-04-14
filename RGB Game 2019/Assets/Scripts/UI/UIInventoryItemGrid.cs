using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItemGrid : MonoBehaviour {
    public int gridId = 0;
    public int num = 0;
    public UILabel itemLabel;
    ObjectInfo info;
    // Use this for initialization
    void Start () {
        itemLabel = GetComponentInChildren<UILabel>();
        itemLabel.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PulsCount(int count=1)
    {
        num += count;
        itemLabel.text = num.ToString();
    }

    internal void SetGirdId(int id,int num=1)
    {
        gridId = id;
        info = ObjectsInfo._instance.GetObjectInfoById(id);
        UIInventoryItem item = GetComponentInChildren<UIInventoryItem>();
        item.SetSprite(id,info.icon_name);
        itemLabel.enabled = true;
        this.num = num;
        itemLabel.text = this.num.ToString();
    }
    public void CleckGrid()
    {
        gridId = 0;
        num = 0;
        info = null;
        itemLabel.enabled = false;
    }
}
