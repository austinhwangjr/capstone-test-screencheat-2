using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Instance_Manager : MonoBehaviour
{
    private GameObject[] player_list_;
    private GameObject[] obstacle_list_;
    private List<GameObject> enemy_list_ = new List<GameObject>();

    // Prefab references
    private GameObject Enemy_Prefab;

    // Positions
    private Vector3 map_center_ = new Vector3(0.0f, 0.0f, 4.0f);

    // Start is called before the first frame update
    void Start()
    {
        player_list_ = GameObject.FindGameObjectsWithTag("Player");
        obstacle_list_ = GameObject.FindGameObjectsWithTag("Obstacle");

        // Instantiating prefabs
        Enemy_Prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Enemy.prefab", typeof(GameObject));
        AddEnemy(map_center_);
    }

    // Update is called once per frame
    void Update()
    {
        //print(enemy_list_.Count);
    }

    void AddEnemy(Vector3 position)
    {
        enemy_list_.Add(Instantiate(Enemy_Prefab, map_center_, Quaternion.identity));
    }
}
