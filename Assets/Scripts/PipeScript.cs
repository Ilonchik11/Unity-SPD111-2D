using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    void Start()
    {
        
    }
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
/*
 [SerializeField] - �������, �� ������� ��, �� �������� ��� ����
    ���� ��������� ����� "��������".
    Translate - ����������
    Time.deltaTime - ���, �� ������� �� ������������ ������ (������� ������)
    �������� �� ��� (�������� �� Time.deltaTime) ������� FPS-���������
    FPS Translate(without dT) Translate(with dT)
    100      100 x 1            100 x 1/100 x 1
    50        50 x 1            50 x 1/50 x 1
 */