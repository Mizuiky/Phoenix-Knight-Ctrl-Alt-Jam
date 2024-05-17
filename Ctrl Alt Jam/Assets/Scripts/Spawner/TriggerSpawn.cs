using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JAM.Spawner
{
    public class TriggerSpawn : MonoBehaviour
    {
        [SerializeField] private int spawnId = 0;
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.name == "Player")
            {
                EventSpawner.instancia.RoomAreaEnter(spawnId);
            }

        }
       
    }
}
