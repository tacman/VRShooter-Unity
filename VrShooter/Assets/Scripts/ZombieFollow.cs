﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow 
{
    NavMeshAgent zombieAgent;
    Transform playerTransform;
    bool alive = true;
    public ZombieFollow(GameObject zombiePrefab, Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        zombieAgent = GameObject.Instantiate(zombiePrefab, new Vector3(38f, 2.81f, 27f),Quaternion.identity).GetComponent<NavMeshAgent>();
        zombieUpdate();
    }
    ~ZombieFollow()
    {
        alive = false;
        Debug.Log("[ZombieFollow]zombieDestroyed");
    }

   public async void zombieUpdate()
    {
        while (alive)
        {
            await Task.Delay(1000);
            Debug.Log("[ZombieFollow]zombieMoving");
            zombieAgent.SetDestination(playerTransform.position);
        }
    }

  
}
