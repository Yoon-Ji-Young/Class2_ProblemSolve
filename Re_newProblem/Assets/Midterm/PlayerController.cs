using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;

    public Vector3 offset;
    public float followSpeed = 0.15f;

    public GameObject quarterViewCamera; // ���ͺ� ī�޶� �޾ƿ� ����
    public float rotationAngle = 45.0f; // ȸ���� ����
    private bool isRotating = false; // ȸ�� ������ ���θ� ��Ÿ���� ����

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start()
    {

    }

    
    void Update()
    {
        playerMove();

        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            RotateCamera(-rotationAngle);
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            RotateCamera(rotationAngle);
        }
    }

    /*private void FixedUpdate()
    {
        Vector3 cam_Pos = Player.transform.position + offset;
        Vector3 lerp_Pos = Vector3.Lerp(quarterViewCamera.transform.position, cam_Pos, followSpeed);
        quarterViewCamera.transform.position = lerp_Pos;
        quarterViewCamera.transform.LookAt(Player.transform);

        
    }*/

    public void playerMove()
    {
        float moveZ = 0f;
        float moveX = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
            moveX += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveZ += 1f;
            moveX -= 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveX -= 1f;
            moveZ -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
            moveZ -= 1f;
        }

        transform.Translate(new Vector3(moveX, 0f, moveZ) * 0.03f);
    }

    void RotateCamera(float angle)
    {
        // ȸ�� �ִϸ��̼� �ߺ� ����
        if (isRotating) return;

        // ȸ�� ��ǥ ���� ����
        Quaternion targetRotation = Player.transform.localRotation * Quaternion.Euler(0, angle, 0);

        // ȸ�� �ִϸ��̼� ����
        StartCoroutine(RotateAnimation(targetRotation));
    }

    IEnumerator RotateAnimation(Quaternion targetRotation)
    {
        isRotating = true;
        float elapsedTime = 0;
        Quaternion startRotation = Player.transform.localRotation;

        while (elapsedTime < 1.0f)
        {
            // ȸ�� �ִϸ��̼� ����
            Player.transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ȸ�� �ִϸ��̼� ����
        Player.transform.localRotation = targetRotation;
        isRotating = false;
    }


}
