using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectablePower : ItemCollectableBase
{
    protected override void Collect()
    {
        base.Collect();
        ItemManager.Instance.AddPower();
    }
}
