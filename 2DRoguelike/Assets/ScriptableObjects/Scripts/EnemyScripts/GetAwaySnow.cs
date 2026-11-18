using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwaySnow : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public GameObject FindPoint;
    public bool IsClose;
    public float DetectionRange = 5;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void GetawayFromPlay()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distance < DetectionRange)
        {
            Instantiate(FindPoint);
        }
    }
}
