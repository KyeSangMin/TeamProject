using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// ChatBubble.cs
/// ChatBubble.prefab�� ����
/// ��ǳ�� ������ ��ǳ�� ũ��� ������ ����

public class ChatBubble : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, string text)
    {
        // Create(parent: ��ǳ���� ��ü, localPosition: ��ü�κ��� ��ŭ �������ִ°�, text: ����� ���)
        Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, parent);
        chatBubbleTransform.localPosition = localPosition;

        if(localPosition.x < 0)
            chatBubbleTransform.Find("Background").GetComponent<SpriteRenderer>().flipX = true;

        chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        // ���ڼ� ������ ũ�� ������ 70�� �̸��� ���������� ����.
        //Setup("���̻�����ĥ�ȱ������̻�����ĥ�ȱ������̻�����ĥ�ȱ������̻�����ĥ�ȱ������̻�����ĥ�ȱ������̻�����ĥ�ȱ���");
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();

        Vector2 textBoxSize = new Vector2(1.8f, 0.5f);
        Vector2 padding = new Vector2(0.1f, 0.1f);
        backgroundSpriteRenderer.size = textBoxSize + padding;

        Vector3 offset = new Vector3(0f, 0f);
        backgroundSpriteRenderer.transform.localPosition =
            new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;
    }
}
