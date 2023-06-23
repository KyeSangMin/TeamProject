using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// ChatBubble.cs
/// ChatBubble.prefab에 적용
/// 말풍선 생성과 말풍선 크기와 여백을 조정

public class ChatBubble : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, string text)
    {
        // Create(parent: 말풍선의 주체, localPosition: 주체로부터 얼만큼 떨어져있는가, text: 출력할 대사)
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
        // 글자수 제한은 크게 없지만 70자 미만이 안정적으로 보임.
        //Setup("일이삼사오육칠팔구십일이삼사오육칠팔구십일이삼사오육칠팔구십일이삼사오육칠팔구십일이삼사오육칠팔구십일이삼사오육칠팔구십");
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
