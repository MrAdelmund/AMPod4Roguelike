using UnityEngine;

public class XpOrb : MonoBehaviour
{
    public float Timer;
    public int xpAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerXP playerXP = other.GetComponent<PlayerXP>();
        if (playerXP != null)
        {
            playerXP.GainXP(xpAmount);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            Destroy(gameObject);
        }
    }

}
