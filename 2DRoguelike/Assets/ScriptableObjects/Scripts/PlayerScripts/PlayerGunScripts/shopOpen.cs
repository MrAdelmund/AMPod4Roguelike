using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopOpen : MonoBehaviour
{
    [Header("References")]
    public ShopManager shopManager;
    public void open()
    {
        shopManager.OpenShop();
    }
}
