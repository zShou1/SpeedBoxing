using UnityEngine;
using DG.Tweening;

public class UIPanel : Node
{
    public RectTransform GetRectTransform()
    {
        return this.GetComponent<RectTransform>();
    }

    public void Open(float duration)
    {
        SetScale(Vector3.zero);
        Activate();
        gameObject.transform.DOScale(Vector3.one, duration).SetEase(Ease.InQuad).SetUpdate(true);
        /*Debug.Log("OpenDuoi" + transform.localScale);*/
    }

    public void Close(float duration)
    {
        gameObject.transform.DOScale(Vector3.zero, duration).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(Deactivate);
        /*Debug.Log("Close" + transform.localScale);*/
    }

    public void SlideDown(RectTransform rectTransform, float to, float duration)
    {
        Activate();
        rectTransform.DOAnchorPosY(to, duration).SetUpdate(true).SetEase(Ease.InQuad);
    }

    public void SlideUp(RectTransform rectTransform, float to, float duration)
    {
        rectTransform.DOAnchorPosY(to, duration).SetUpdate(true).SetEase(Ease.OutQuad).OnComplete(Deactivate);
    }

    public void MoveAnchorX(float to, float duration)
    {
        GetRectTransform().DOAnchorPosX(to, duration);
    }

    public void MoveAnchorY(RectTransform rectTransform, float to, float duration)
    {
        rectTransform.DOAnchorPosY(to, duration);
    }

    public void MoveAnchorPos(RectTransform rectTransform, Vector2 to, float duration)
    {
        GetRectTransform().DOAnchorPos(to, duration);
    }

    public void ScaleObject(Vector3 endValue, float duration)
    {
        transform.DOScale(endValue, duration);
    }
}