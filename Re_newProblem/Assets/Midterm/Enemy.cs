using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject moveArea;
    public GameObject enemy;
    public GameObject player;
    private Camera enemyCamera;

    public float rotatAngle = 20.0f;
    public float areaSize = 3.0f;

    private float rotatTime = 3.0f;
    private float rotationTimer;
    private float rotationSpeed = 90f;

    void Start()
    {
        enemyCamera = GetComponent<Camera>();
        
    }

    
    void Update()
    {
        

        // ī�޶��� ���������� ��������
        FrustumPlanes frustum = new FrustumPlanes(enemyCamera);

        if (frustum.IsInsideFrustum(player.transform.position))
        {
            // Player�� ���� ȸ��
            Vector3 direction = player.transform.position - enemy.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRotation, rotatAngle * Time.deltaTime);

            // Player�� ���� �̵�
            float moveSpeed = 0.04f;
            enemy.transform.Translate(direction.normalized * moveSpeed);

            rotationTimer = 0f;
        }
        else
        {
            Debug.Log("�÷��̾� ����");

            // ȸ�� Ÿ�̸� ����
            rotationTimer += Time.deltaTime;

            if (rotationTimer <= 10.0f)
            {
                if (rotationTimer >= rotatTime)
                {
                    Quaternion targetRotation = enemy.transform.rotation * Quaternion.Euler(0, -90f, 0);
                    enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRotation, rotatAngle * Time.deltaTime);
                    
                    if (enemy.transform.rotation.y == -90)
                    {
                        targetRotation = enemy.transform.rotation * Quaternion.Euler(0, 180f, 0);
                        enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRotation, rotatAngle * Time.deltaTime);
                    }
                }
            }
        }

        
    }

    public void enemyMove()
    {
        float moveX = 3;
        float moveZ = 3;

        enemy.transform.Translate(new Vector3(moveX, 0f, moveZ) * 0.03f);
    }

    private void OnTriggerExit(Collider other)
    {
        enemy.transform.localRotation = Quaternion.identity;
        Quaternion targetRotation = enemy.transform.localRotation * Quaternion.Euler(rotatAngle, 0, 0);
    }

    private void OnDrawGizmos()
    {
        // Box ������ ���̵������ �׸��ϴ�.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(moveArea.transform.position, areaSize);
    }

    


    public class FrustumPlanes
    {
        private readonly Plane[] planes;

        public FrustumPlanes(Camera camera)
        {
            planes = GeometryUtility.CalculateFrustumPlanes(camera);
        }

        public bool IsInsideFrustum(Vector3 point)
        {
            foreach (var plane in planes)
            {
                if (!plane.GetSide(point))
                {

                    return false;
                }
            }
            return true;
        }
    }
}
