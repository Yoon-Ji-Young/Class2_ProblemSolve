using System;
using UnityEngine;

namespace DataStrucuture
{
    public class Generate : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public GameObject StartObj;
        public int Capacity = 10;
        public Stack<GameObject> Ammo = new Stack<GameObject>(); 

        private int activeBullet;
        private Transform spawnPoint;

        void Start()
        {
            spawnPoint = StartObj.transform;

            for (int i = 0; i < Capacity; i++)
            {
                // 오브젝트 10개 미리 생성 후 비활성화
                GameObject bullet = Instantiate(BulletPrefab, spawnPoint.position, spawnPoint.rotation);
                bullet.SetActive(false);
                Ammo.Push(bullet);
            }
        }

        void Update()
        {
            if (activeBullet <= Capacity)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject bullet = Ammo.Pop();
                    bullet.SetActive(true);
                    activeBullet++;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);

            GameObject bullet = Instantiate(BulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.SetActive(false);
            Ammo.Push(bullet);
        }
    }
}
