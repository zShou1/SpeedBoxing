using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public virtual Color GetColor()
    {
        if (base.GetComponent<UnityEngine.UI.Text>())
        {
            return base.GetComponent<UnityEngine.UI.Text>().color;
        }

        if (base.GetComponent<Camera>())
        {
            return base.GetComponent<UnityEngine.Camera>().backgroundColor;
        }

        if (base.GetComponent<Image>())
        {
            return base.GetComponent<Image>().color;
        }

        if (base.GetComponent<SpriteRenderer>())
        {
            return base.GetComponent<SpriteRenderer>().color;
        }

        if (base.GetComponent<MeshRenderer>())
        {
            return base.GetComponent<MeshRenderer>().material.color;
        }

        return Color.black;
    }

    public virtual void SetColor(Color color)
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            this.SetColor(base.GetComponent<SpriteRenderer>(), color);
        }

        if (base.GetComponent<Image>())
        {
            this.SetColor(base.GetComponent<Image>(), color);
        }

        if (base.GetComponent<MeshRenderer>())
        {
            this.SetColor(base.GetComponent<MeshRenderer>(), color);
        }

        if (base.GetComponent<UnityEngine.UI.Text>())
        {
            this.SetColor(base.GetComponent<UnityEngine.UI.Text>(), color);
        }

        if (base.GetComponent<TextMesh>())
        {
            this.SetColor(base.GetComponent<TextMesh>(), color);
        }

        if (base.GetComponent<Camera>())
        {
            this.SetColor(base.GetComponent<UnityEngine.Camera>(), color);
        }
    }

    public virtual void SetColor(UnityEngine.Camera component, Color color)
    {
        component.backgroundColor = color;
    }

    public virtual void SetColor(SpriteRenderer component, Color color)
    {
        component.color = color;
    }

    public virtual void SetColor(Image component, Color color)
    {
        component.color = color;
    }

    public virtual void SetColor(MeshRenderer component, Color color)
    {
        component.material.SetColor("_BaseColor", color);
    }

    public virtual void SetColor(UnityEngine.UI.Text component, Color color)
    {
        component.color = color;
    }

    public virtual void SetColor(TextMesh component, Color color)
    {
        component.color = color;
    }

    public virtual void SetEmissionColor(Color color)
    {
        if (base.GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color);
        }
    }

    public virtual float GetFade()
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            return this.GetFade(base.GetComponent<SpriteRenderer>());
        }

        if (base.GetComponent<Image>())
        {
            return this.GetFade(base.GetComponent<Image>());
        }

        if (base.GetComponent<MeshRenderer>())
        {
            return this.GetFade(base.GetComponent<MeshRenderer>());
        }

        if (base.GetComponent<CanvasGroup>())
        {
            return this.GetFade(base.GetComponent<CanvasGroup>());
        }

        if (base.GetComponent<UnityEngine.UI.Text>())
        {
            return this.GetFade(base.GetComponent<UnityEngine.UI.Text>());
        }

        if (base.GetComponent<TextMesh>())
        {
            return this.GetFade(base.GetComponent<TextMesh>());
        }

        return 0f;
    }

    public virtual float GetFade(SpriteRenderer component)
    {
        return component.color.a;
    }

    public virtual float GetFade(Image component)
    {
        return component.color.a;
    }

    public virtual float GetFade(TextMesh component)
    {
        return component.color.a;
    }

    public virtual float GetFade(UnityEngine.UI.Text component)
    {
        return component.color.a;
    }

    public virtual float GetFade(MeshRenderer component)
    {
        return component.material.color.a;
    }

    public virtual float GetFade(CanvasGroup component)
    {
        return component.alpha;
    }

    public virtual void SetFade(double fade)
    {
        if (base.GetComponent<CanvasGroup>())
        {
            this.SetFade(base.GetComponent<CanvasGroup>(), fade);
            return;
        }

        if (base.GetComponent<SpriteRenderer>())
        {
            this.SetFade(base.GetComponent<SpriteRenderer>(), fade);
            return;
        }

        if (base.GetComponent<Image>())
        {
            this.SetFade(base.GetComponent<Image>(), fade);
            return;
        }

        if (base.GetComponent<MeshRenderer>())
        {
            this.SetFade(base.GetComponent<MeshRenderer>(), fade);
            return;
        }

        if (base.GetComponent<UnityEngine.UI.Text>())
        {
            this.SetFade(base.GetComponent<UnityEngine.UI.Text>(), fade);
            return;
        }

        if (base.GetComponent<TextMesh>())
        {
            this.SetFade(base.GetComponent<TextMesh>(), fade);
            return;
        }
    }

    public virtual void SetFade(SpriteRenderer component, double fade)
    {
        component.color = new Color(component.color.r, component.color.g, component.color.b, (float) fade);
    }

    public virtual void SetFade(Image component, double fade)
    {
        component.color = new Color(component.color.r, component.color.g, component.color.b, (float) fade);
    }

    public virtual void SetFade(TextMesh component, double fade)
    {
        component.color = new Color(component.color.r, component.color.g, component.color.b, (float) fade);
    }

    public virtual void SetFade(UnityEngine.UI.Text component, double fade)
    {
        component.color = new Color(component.color.r, component.color.g, component.color.b, (float) fade);
    }

    public virtual void SetFade(MeshRenderer component, double fade)
    {
        Color color = component.material.GetColor("_BaseColor");
        color.a = (float) fade;
        component.material.SetColor("_BaseColor", color);
    }

    public virtual void SetFade(CanvasGroup component, double fade)
    {
        component.alpha = (float) fade;
    }

    public virtual Vector3 GetPosition()
    {
        if (base.GetComponent<RectTransform>() == null)
        {
            return base.transform.localPosition;
        }

        return base.GetComponent<RectTransform>().anchoredPosition;
    }

    public virtual float GetPositionX()
    {
        if (base.GetComponent<RectTransform>() == null)
        {
            return base.transform.localPosition.x;
        }

        return base.GetComponent<RectTransform>().anchoredPosition.x;
    }

    public virtual float GetPositionY()
    {
        if (base.GetComponent<RectTransform>() == null)
        {
            return base.transform.localPosition.y;
        }

        return base.GetComponent<RectTransform>().anchoredPosition.y;
    }

    public virtual float GetPositionZ()
    {
        return base.transform.localPosition.z;
    }

    public virtual void SetPosition(Vector3 position)
    {
        if (base.GetComponent<RectTransform>() == null)
        {
            base.transform.localPosition = position;
            return;
        }

        base.GetComponent<RectTransform>().anchoredPosition3D = position;
    }

    public virtual void SetPosition(double x, double y, double z)
    {
        this.SetPosition(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual void SetPosition(double x, double y)
    {
        this.SetPosition(new Vector2((float) x, (float) y));
    }

    public virtual void SetPosition(Vector2 position)
    {
        this.SetPosition(new Vector3(position.x, position.y, this.GetPositionZ()));
    }

    public virtual void SetPositionX(double x)
    {
        this.SetPosition(new Vector2((float) x, this.GetPositionY()));
    }

    public virtual void SetPositionY(double y)
    {
        this.SetPosition(new Vector2(this.GetPositionX(), (float) y));
    }

    public virtual void SetPositionZ(double z)
    {
        this.SetPosition(new Vector3(this.GetPositionX(), this.GetPositionY(), (float) z));
    }

    public virtual float GetProgress()
    {
        if (base.GetComponent<Image>())
        {
            return base.GetComponent<Image>().fillAmount;
        }

        return 0f;
    }

    public virtual void SetProgress(double value)
    {
        if (base.GetComponent<Image>())
        {
            base.GetComponent<Image>().fillAmount = (float) value;
        }
    }

    public virtual Vector3 GetRotation()
    {
        return base.transform.localEulerAngles;
    }

    public virtual float GetRotationX()
    {
        return base.transform.localEulerAngles.x;
    }

    public virtual float GetRotationY()
    {
        return base.transform.localEulerAngles.y;
    }

    public virtual float GetRotationZ()
    {
        return base.transform.localEulerAngles.z;
    }

    public virtual void SetRotation(Vector3 rotation, bool isWorld = false)
    {
        if (!isWorld)
        {
            base.transform.localEulerAngles = rotation;
        }
        else
        {
            transform.eulerAngles = rotation;
        }
    }

    public virtual void SetRotation(double x, double y, double z)
    {
        base.transform.localEulerAngles = new Vector3((float) x, (float) y, (float) z);
    }

    public virtual void SetRotation(double rotation)
    {
        base.transform.localEulerAngles = new Vector3(0f, 0f, (float) rotation);
    }

    public virtual void SetRotationX(double rotation)
    {
        base.transform.localEulerAngles = new Vector3((float) rotation, base.transform.localEulerAngles.y,
            base.transform.localEulerAngles.z);
    }

    public virtual void SetRotationY(double rotation)
    {
        base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, (float) rotation,
            base.transform.localEulerAngles.z);
    }

    public virtual void SetRotationZ(double rotation)
    {
        base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x,
            base.transform.localEulerAngles.y, (float) rotation);
    }

    public virtual float GetScale()
    {
        return base.transform.localScale.x;
    }

    public virtual float GetScaleX()
    {
        return base.transform.localScale.x;
    }

    public virtual float GetScaleY()
    {
        return base.transform.localScale.y;
    }

    public virtual float GetScaleZ()
    {
        return base.transform.localScale.z;
    }

    public virtual void SetScale(double scale)
    {
        this.SetScale(new Vector3((float) scale, (float) scale, (float) scale));
    }

    public virtual void SetScale(double x, double y, double z)
    {
        this.SetScale(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual void SetScale(Vector3 scale)
    {
        base.transform.localScale = scale;
    }

    public virtual void SetScaleX(double scale)
    {
        this.SetScale(new Vector3((float) scale, this.GetScaleY(), this.GetScaleZ()));
    }

    public virtual void SetScaleY(double scale)
    {
        this.SetScale(new Vector3(this.GetScaleX(), (float) scale, this.GetScaleZ()));
    }

    public virtual void SetScaleZ(double scale)
    {
        this.SetScale(new Vector3(this.GetScaleX(), this.GetScaleY(), (float) scale));
    }

    public virtual bool GetFlipX()
    {
        return base.GetComponent<SpriteRenderer>().flipX;
    }

    public virtual bool GetFlipY()
    {
        return base.GetComponent<SpriteRenderer>().flipY;
    }

    public virtual void SetFlipX(bool state)
    {
        base.GetComponent<SpriteRenderer>().flipX = state;
    }

    public virtual void SetFlipY(bool state)
    {
        base.GetComponent<SpriteRenderer>().flipY = state;
    }
}