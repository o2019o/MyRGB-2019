using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItem : UIDragDropItem {
    public int itemId = 0;
    public UISprite sprite;

    protected override void Awake()
    {
        base.Awake();
        sprite = GetComponent<UISprite>();
        transform.GetComponent<UIEventTrigger>().onHoverOver.Add(new EventDelegate(OnHoverOver));
        transform.GetComponent<UIEventTrigger>().onHoverOut.Add(new EventDelegate(OnHoverOut));

    }
    private bool isHide = false;
    private void OnHoverOut()
    {
        isHide = false;
    }

    private void OnHoverOver()
    {
        isHide = true;
    }

    public void SetSprite(int id,string name)
    {
        itemId = id;
        transform.name = name;
        sprite.spriteName = name;
    }
    protected override void Update () {
        base.Update();

        if(isHide)
        {
            UIInventoryDes.Instence.ShowItemDes(itemId);
        }
	}
    protected override void OnDragDropRelease(GameObject temp)
    {
        base.OnDragDropRelease(temp);
        if(temp != null)
        {
            Debug.Log(temp);
            if(temp.tag == "InventoryItemGrid")
            {
                if (temp == transform.parent.gameObject)
                {
                    transform.localPosition = Vector3.zero;
                }
                else
                {
                    UIInventoryItemGrid grid1 = transform.parent.GetComponent<UIInventoryItemGrid>();
                    UIInventoryItemGrid grid2 = temp.GetComponent<UIInventoryItemGrid>();
                    transform.parent = temp.transform;
                    grid2.SetGirdId(grid1.gridId, grid1.num);
                    grid1.CleckGrid();
                }
            }
            else if(temp.tag == "InventoryItem")
            {
                UIInventoryItemGrid grid1 = transform.parent.GetComponent<UIInventoryItemGrid>();
                UIInventoryItemGrid grid2 = temp.transform.parent.GetComponent<UIInventoryItemGrid>();
                int id = grid1.gridId;int num = grid1.num;               
                grid1.SetGirdId(grid2.gridId, grid2.num);
                grid2.SetGirdId(id,num);
            }
        }
        transform.localPosition = Vector3.zero;
    }

    
}
