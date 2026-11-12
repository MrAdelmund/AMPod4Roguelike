using UnityEngine;

public class GoldOrb : MonoBehaviour
{
    public float Timer;
    public int goldAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCurrency currency = other.GetComponent<PlayerCurrency>();
        if (currency != null)
        {
            currency.AddGold(goldAmount);
            Destroy(gameObject);
        }
    }
    private void Start()
    {

    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
