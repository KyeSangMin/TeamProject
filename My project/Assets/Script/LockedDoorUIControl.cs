using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorUIControl : MonoBehaviour
{
    [SerializeField] private Transform pfLockedWindow;
    private bool isOpenWindow;

    private void Start()
    {
        isOpenWindow = false;
    }

    public void EnableLockedWindow()
    {
        if (!isOpenWindow)
        {
            isOpenWindow = true;
            StartCoroutine(OpenWindowForSecond(2.0f));// â �ڵ� ���� �ð� ����
        }
    }

    IEnumerator OpenWindowForSecond(float second)
    {
        Transform window = GameObject.Instantiate(pfLockedWindow, gameObject.transform);
        window.localScale = new Vector3(0.5f, 0.5f, 1.0f);// ���â ũ�� ����
        yield return new WaitForSeconds(second);
        isOpenWindow = false;
        Destroy(window.gameObject);
    }
}
