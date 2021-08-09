using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player(Clone)");
        if (Player == null)
        {
            return;
        }
        pos = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
