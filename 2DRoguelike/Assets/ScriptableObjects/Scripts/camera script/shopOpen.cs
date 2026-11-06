using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shopOpen : MonoBehaviour
{
    public ShopManager shopManager;
    public GameManager GameManager;
    private void Start()
    {
        GameObject managerObj = GameObject.FindWithTag("GameManager");
        if (managerObj == null)
        {
            if  (GameManager == null)
            {
                GameManager = managerObj.GetComponent<GameManager>();
            }
        }
            if (shopManager == null)
        {
            {
                shopManager = managerObj.GetComponent<ShopManager>();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("I hit shop");
            if (other.CompareTag("Player"))
            {
                Debug.Log("I enter shop");
            shopManager.OpenShop();
            Destroy(gameObject);
        }
        }
}
