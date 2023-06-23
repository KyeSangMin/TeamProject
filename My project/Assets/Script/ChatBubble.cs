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

        chatBubbleTransform.localScale = 
            new Vector3(
                chatBubbleTransform.localScale.x / chatBubbleTransform.parent.localScale.x * 0.5f,
                chatBubbleTransform.localScale.y / chatBubbleTransform.parent.localScale.y * 0.5f,
                chatBubbleTransform.localScale.z / chatBubbleTransform.parent.localScale.z);

        if(localPosition.x < 0)
            chatBubbleTransform.Find("Background").GetComponent<SpriteRenderer>().flipX = true;

        chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer backgroundColorRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        backgroundColorRenderer = transform.Find("BackgroundColor").GetComponent<SpriteRenderer>();
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

        Vector2 textBoxSize = new Vector2(2.0f, 1.0f);
        Vector2 padding = new Vector2(0.1f, 0.1f);
        backgroundSpriteRenderer.size = textBoxSize + padding;
        backgroundColorRenderer.size =
            new Vector2(
                backgroundColorRenderer.size.x * backgroundSpriteRenderer.size.x,
                backgroundColorRenderer.size.y * backgroundSpriteRenderer.size.y);

        Vector3 offset = new Vector3(-1.0f, 0f);
        backgroundSpriteRenderer.transform.localPosition =
            new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;
    }
}
