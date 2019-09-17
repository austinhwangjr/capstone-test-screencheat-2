using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public GameObject player;
    Vector3 player_position_;

    // Start is called before the first frame update
    void Start()
    {
        player_position_ = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player_position_.x = player.transform.position.x;
            player_position_.y = player.transform.position.y;
            transform.position = player_position_;
        }
    }
}
