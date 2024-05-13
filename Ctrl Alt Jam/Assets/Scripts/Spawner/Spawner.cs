using System;
using UnityEngine;


namespace JAM.Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private int id;
        private Collider2D spawnerCollider;
        private GameObject enemy1;

        public void Start()
        {
            spawnerCollider = GetComponent<Collider2D>();
            enemy1 = Resources.Load<GameObject>("Enemys/shadow enemy 1");

            if (enemy1 == null)
            {
                Debug.LogError("Prefab não encontrado na pasta Resources.");

            }

            EventSpawner.instancia.OnRoomEnter += SpawEnemys;
            Debug.Log("Ativar");
        }

        private void SpawEnemys(int id)
        {

            if (id == 1)
            {
                this.SpawnEnemysFirstRoom();
            }

            if (id == 2)
            {
                // this.SpawnEnemysSecondRoom();
            }
        }

        private void SpawnEnemysFirstRoom()
        {

            // @todo array de localização para spawnar 
            // @todo melhorar script para ficar mais flexivel

            bool torchFirstRoom = true;  // verificar se tocha da sala 1 está acessa

            if (torchFirstRoom)
            {
                // Definindo os limites de onde serão spawnados
                float minX = -5f; float maxX = -2f; float minY = 1f; float maxY = 3f;
                int quantidadeEnemys = 5;

                // Gerar um array de posições usando os limites especificados e exibir no console
                Vector3[] posicoesGeradas = GerarPosicoes(minX, maxX, minY, maxY, quantidadeEnemys);
                foreach (Vector3 posicao in posicoesGeradas)
                {
                    Instantiate(enemy1, posicao, Quaternion.identity);
                }
            }

        }


        private Vector3[] GerarPosicoes(float minX, float maxX, float minY, float maxY, int quantidade)
        {
            Vector3[] posicoes = new Vector3[quantidade];
            float distanciaMinima = 0.4f;

            for (int i = 0; i < quantidade; i++)
            {
                Vector3 novaPosicao;

                do
                {
                    // Gerando coordenadas aleatórias dentro dos intervalos especificados
                    float x = UnityEngine.Random.Range(minX, maxX);
                    float y = UnityEngine.Random.Range(minY, maxY);
                    float z = 0f;

                    novaPosicao = new Vector3(x, y, z);
                } while (PosicaoEstaMuitoProxima(novaPosicao, posicoes, distanciaMinima, i));

                posicoes[i] = novaPosicao;

            }
            return posicoes;
        }

        private bool PosicaoEstaMuitoProxima(Vector3 novaPosicao, Vector3[] posicoesExistente, float distanciaMinima, int quantidadeExistente)
        {
            for (int i = 0; i < quantidadeExistente; i++)
            {
                if (Vector3.Distance(novaPosicao, posicoesExistente[i]) < distanciaMinima)
                {
                    return true; // A nova posição está muito próxima de uma posição existente
                }
            }
            return false; // A nova posição está distante o suficiente de todas as posições existentes
        }
    }
}
