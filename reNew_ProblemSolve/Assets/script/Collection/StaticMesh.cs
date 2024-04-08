using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMesh))]
public class StaticMeshGenEditor : Editor
{
    //��ư����� ����
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StaticMesh script = (StaticMesh)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }

    }
}

//�޽������ ����
public class StaticMesh : MonoBehaviour
{


    // Start is called before the first frame update
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (0.0f, 0.0f, 0.0f),   //0
            new Vector3 (1.0f, 0.0f, 0.0f),   //1
            new Vector3 (0.5f, 1.5f, 0.0f),   //2
            new Vector3 (-0.5f, 1.5f, 0.0f),  //3
            new Vector3 (1.5f, 1.5f, 0.0f),   //4
            new Vector3 (-1.0f, 0.0f, 0.0f),  //5 ������� ���� ��
            new Vector3 (-1.0f, -1.0f, 0.0f), //6 ������� ���� ��
            new Vector3 (0.5f, -1.5f, 0.0f),  //7
            new Vector3 (1.0f, -1.0f, 0.0f),  //8 ������� ���� ��
            new Vector3 (0.5f, 2.5f, 0.0f),  //9
            new Vector3 (-1.0f, 3.5f, 0.0f),  //10
            new Vector3 (2.0f, 3.5f, 0.0f),  //11
            new Vector3 (2.5f, 0.0f, 0.0f),  //12
            new Vector3 (-1.5f, 0.0f, 0.0f),  //13
            //�Ʒ� ��
            new Vector3 (0.0f, 0.0f, 3.0f),   //14   [0]
            new Vector3 (1.0f, 0.0f, 3.0f),   //15   [1]
            new Vector3 (0.5f, 1.5f, 3.0f),   //16   [2]
            new Vector3 (-0.5f, 1.5f, 3.0f),  //17   [3]
            new Vector3 (1.5f, 1.5f, 3.0f),   //18   [4]
            new Vector3 (0.5f, -1.5f, 3.0f),  //19   [7]
            new Vector3 (0.5f, 2.5f, 3.0f),   //20   [9]
            new Vector3 (-1.0f, 3.5f, 3.0f),  //21   [10]
            new Vector3 (2.0f, 3.5f, 3.0f),   //22   [11]
            new Vector3 (2.5f, 0.0f, 3.0f),   //23   [12]
            new Vector3 (-1.5f, 0.0f, 3.0f),  //24   [13]
            //��� �κ�
            new Vector3 (0.0f, 0.0f, 3.0f),   //25 
        };

        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            0,2,1,
            0,3,2,
            1,2,4,
            3,9,4,
            3,10,9,
            9,11,4,
            1,4,12,
            13,3,0,
            7,0,1,
            //�ϴ� ��
            14,16,15,
            14,17,16,
            15,16,18,
            17,20,18,
            17,21,18,
            20,22,18,
            15,18,23,
            24,17,14,
            19,14,15,
            //��պκ�
            4,11,22,
            4,22,18,
            12,4,18,
            12,18,23,
            1,12,23,
            1,23,15,
            7,1,15,
            7,15,19,
            14,0,7,
            19,14,7,
            0,14,13,
            14,24,13,
            13,17,3,
            13,24,17,
            3,21,10,
            3,17,21,
            9,10,21,
            9,21,20,
            9,22,11,
            9,20,22,
        };

        mesh.triangles = triangleIndices;

        MeshFilter mf = this.GetComponent<MeshFilter>(); // ���� MeshFilter�� ������
        if (mf == null)
            mf = this.AddComponent<MeshFilter>();

        MeshRenderer mr = this.GetComponent<MeshRenderer>(); // ���� MeshRenderer�� ������
        if (mr == null)
            mr = this.AddComponent<MeshRenderer>();

        Material yellowMaterial = new Material(Shader.Find("Custom/StartShader")); // ����� Shader�� ���� Material ����
        mr.material = yellowMaterial; // MeshRenderer�� Material �Ҵ�

        mf.mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

