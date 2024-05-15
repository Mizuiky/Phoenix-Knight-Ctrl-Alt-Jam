using System;
using UnityEngine;

namespace JAM.Spawner
{
    public class EventSpawner : MonoBehaviour
    {
        public static EventSpawner instancia;
        void Awake() => instancia = this;

        public event Action<int> OnRoomEnter;
        public void RoomAreaEnter(int id) => OnRoomEnter?.Invoke(id);

        public event Action<int> OnRoomExit;
        public void RoomAreaExit(int id) => OnRoomExit?.Invoke(id);

    }
}
