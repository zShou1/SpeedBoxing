using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Node : Tweener
{
    protected bool isPaused;

    public virtual void Activate()
    {
        base.gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        base.gameObject.SetActive(false);
    }

    public virtual void SetField(double value)
    {
        base.GetComponent<UnityEngine.Camera>().fieldOfView = (float) value;
    }

    public virtual float GetField()
    {
        return base.GetComponent<UnityEngine.Camera>().fieldOfView;
    }

    public virtual void SetRenderTexture(RenderTexture texture)
    {
        base.GetComponent<UnityEngine.Camera>().targetTexture = texture;
    }

    protected virtual void OnEnable()
    {
        this.isPaused = false;
    }

    protected virtual void OnDisable()
    {
        this.StopTweens(true, false);
    }

    public virtual void ShowInHierarchy()
    {
        base.gameObject.hideFlags = HideFlags.None;
    }

    public virtual void HideInHierarchy()
    {
        base.gameObject.hideFlags = HideFlags.HideInHierarchy;
    }

    public virtual void SetMaterial(Material material)
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            base.GetComponent<SpriteRenderer>().material = material;
        }

        if (base.GetComponent<Image>())
        {
            base.GetComponent<Image>().material = material;
        }
    }

    public virtual void SetMesh(Mesh mesh)
    {
        try
        {
            base.GetComponent<MeshFilter>().sharedMesh = mesh;
            if (base.GetComponent<MeshCollider>() != null)
            {
                base.GetComponent<MeshCollider>().sharedMesh = mesh;
            }
        }
        catch
        {
            base.GetComponent<MeshFilter>().sharedMesh = null;
            if (base.GetComponent<MeshCollider>() != null)
            {
                base.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }

    public virtual Node GetParent()
    {
        return base.transform.parent?.GetComponent<Node>();
    }

    public virtual void SetParent(Node parent, bool position = false)
    {
        base.transform.SetParent((parent != null) ? parent.transform : null, position);
    }

    public virtual void SetLayer(int layer)
    {
        base.gameObject.layer = layer;
    }

    public virtual void SetSprite(Sprite sprite)
    {
        if (sprite != null)
        {
            string name = sprite.name;
            if (!(name == "white-square"))
            {
                if (base.GetComponent<SpriteRenderer>())
                {
                    base.GetComponent<SpriteRenderer>().sprite = sprite;
                }

                if (base.GetComponent<Image>())
                {
                    base.GetComponent<Image>().overrideSprite = sprite;
                    if (base.GetComponent<Image>().type == Image.Type.Simple)
                    {
                        base.GetComponent<Image>().SetNativeSize();
                    }
                }
            }
        }
    }

    public virtual void SetSprite(string path)
    {
        Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        if (sprite != null)
        {
            string name = sprite.name;
            if (!(name == "white-square"))
            {
                if (base.GetComponent<SpriteRenderer>())
                {
                    base.GetComponent<SpriteRenderer>().sprite = sprite;
                }

                if (base.GetComponent<Image>())
                {
                    base.GetComponent<Image>().overrideSprite = sprite;
                }

                if (base.GetComponent<Image>())
                {
                    base.GetComponent<Image>().SetNativeSize();
                }
            }
        }
    }

    public virtual void SetTexture(Texture texture)
    {
        if (base.GetComponent<MeshRenderer>())
        {
            base.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", texture);
        }

        if (base.GetComponent<SkinnedMeshRenderer>())
        {
            base.GetComponent<SkinnedMeshRenderer>().material.SetTexture("_BaseMap", texture);
        }
    }

    public virtual void SetTexture(string path)
    {
        Texture value = Resources.Load(path, typeof(Texture)) as Texture;
        if (base.GetComponent<MeshRenderer>())
        {
            base.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", value);
        }

        if (base.GetComponent<SkinnedMeshRenderer>())
        {
            base.GetComponent<SkinnedMeshRenderer>().material.SetTexture("_BaseMap", value);
        }
    }

    public virtual string GetName()
    {
        return base.gameObject.name;
    }

    public virtual void SetName(string name)
    {
        base.gameObject.name = name;
    }

    public virtual void Pause()
    {
        if (!this.isPaused)
        {
            this.isPaused = true;
            this.PauseTweens();
            Node[] componentsInChildren = base.GetComponentsInChildren<Node>();
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                componentsInChildren[i].Pause();
            }
        }
    }

    public virtual void Resume()
    {
        if (this.isPaused)
        {
            this.isPaused = false;
            this.ResumeTweens();
            Node[] componentsInChildren = base.GetComponentsInChildren<Node>();
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                componentsInChildren[i].Resume();
            }
        }
    }

    public virtual Vector3 GetVelocity()
    {
        if (base.GetComponent<Rigidbody>())
        {
            return base.GetComponent<Rigidbody>().linearVelocity;
        }

        if (base.GetComponent<Rigidbody2D>())
        {
            return base.GetComponent<Rigidbody2D>().linearVelocity;
        }

        return new Vector3(0f, 0f, 0f);
    }

    public virtual float GetVelocityX()
    {
        return this.GetVelocity().x;
    }

    public virtual float GetVelocityY()
    {
        return this.GetVelocity().y;
    }

    public virtual float GetVelocityZ()
    {
        return this.GetVelocity().z;
    }

    public virtual void SetVelocity(Vector3 velocity)
    {
        if (base.GetComponent<Rigidbody>())
        {
            base.GetComponent<Rigidbody>().linearVelocity = velocity;
        }

        if (base.GetComponent<Rigidbody2D>())
        {
            base.GetComponent<Rigidbody2D>().linearVelocity = velocity;
        }
    }

    public virtual void SetVelocity(double x, double y, double z)
    {
        this.SetVelocity(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual void SetVelocity(double x, double y)
    {
        this.SetVelocity(new Vector3((float) x, (float) y, 0f));
    }

    public virtual void SetVelocityX(double x)
    {
        this.SetVelocity(new Vector3((float) x, this.GetVelocity().y, this.GetVelocity().z));
    }

    public virtual void SetVelocityY(double y)
    {
        this.SetVelocity(new Vector3(this.GetVelocity().x, (float) y, this.GetVelocity().z));
    }

    public virtual void SetVelocityZ(double z)
    {
        this.SetVelocity(new Vector3(this.GetVelocity().x, this.GetVelocity().y, (float) z));
    }

    public virtual Vector3 GetAngularVelocity()
    {
        if (base.GetComponent<Rigidbody>())
        {
            return base.GetComponent<Rigidbody>().angularVelocity;
        }

        if (base.GetComponent<Rigidbody2D>())
        {
            return new Vector3(base.GetComponent<Rigidbody2D>().angularVelocity,
                base.GetComponent<Rigidbody2D>().angularVelocity, base.GetComponent<Rigidbody2D>().angularVelocity);
        }

        return new Vector3(0f, 0f, 0f);
    }

    public virtual float GetAngularVelocityX()
    {
        return this.GetAngularVelocity().x;
    }

    public virtual float GetAngularVelocityY()
    {
        return this.GetAngularVelocity().y;
    }

    public virtual float GetAngularVelocityZ()
    {
        return this.GetAngularVelocity().z;
    }

    public virtual void SetAngularVelocity(Vector3 velocity)
    {
        if (base.GetComponent<Rigidbody>())
        {
            base.GetComponent<Rigidbody>().angularVelocity = velocity;
        }
    }

    public virtual void SetAngularVelocity(float velocity)
    {
        if (base.GetComponent<Rigidbody2D>())
        {
            base.GetComponent<Rigidbody2D>().angularVelocity = velocity;
        }
    }

    public virtual void SetAngularVelocity(double x, double y, double z)
    {
        this.SetAngularVelocity(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual void SetAngularVelocity(double x, double y)
    {
        this.SetAngularVelocity(new Vector3((float) x, (float) y, 0f));
    }

    public virtual void SetAngularVelocityX(double x)
    {
        this.SetAngularVelocity(new Vector3((float) x, this.GetAngularVelocityY(), this.GetAngularVelocityZ()));
    }

    public virtual void SetAngularVelocityY(double y)
    {
        this.SetAngularVelocity(new Vector3(this.GetAngularVelocityX(), (float) y, this.GetAngularVelocityZ()));
    }

    public virtual void SetAngularVelocityZ(double z)
    {
        this.SetAngularVelocity(new Vector3(this.GetAngularVelocityX(), this.GetAngularVelocityY(), (float) z));
    }

    public virtual void SetForce(double x, double y, double z)
    {
        base.GetComponent<Rigidbody>().AddForce(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual void SetExplosionForce(Vector3 position, double radius, double power)
    {
        base.GetComponent<Rigidbody>().AddExplosionForce((float) power, position, (float) radius);
    }

    public virtual void SetTorque(double x, double y, double z)
    {
        base.GetComponent<Rigidbody>().AddTorque(new Vector3((float) x, (float) y, (float) z));
    }

    public virtual RigidbodyType2D GetBodyType()
    {
        return base.GetComponent<Rigidbody2D>().bodyType;
    }

    public virtual void SetBodyType(RigidbodyType2D type)
    {
        if (base.GetComponent<Rigidbody2D>() != null)
        {
            base.GetComponent<Rigidbody2D>().bodyType = type;
        }
    }

    public virtual bool GetGravity()
    {
        return base.GetComponent<Rigidbody>().useGravity;
    }

    public virtual void SetGravity(bool state)
    {
        if (base.GetComponent<Rigidbody>() != null)
        {
            base.GetComponent<Rigidbody>().useGravity = state;
        }
    }

    public virtual float GetGravityScale()
    {
        return base.GetComponent<Rigidbody2D>().gravityScale;
    }

    public virtual void SetGravityScale(double scale)
    {
        if (base.GetComponent<Rigidbody2D>())
        {
            base.GetComponent<Rigidbody2D>().gravityScale = (float) scale;
        }
    }

    public virtual bool GetKinematic()
    {
        return base.GetComponent<Rigidbody>() && base.GetComponent<Rigidbody>().isKinematic;
    }

    public virtual void SetKinematic(bool state)
    {
        if (base.GetComponent<Rigidbody>())
        {
            base.GetComponent<Rigidbody>().isKinematic = state;
        }
    }

    public virtual bool GetSimulate()
    {
        if (base.GetComponent<Rigidbody>())
        {
            return !base.GetComponent<Rigidbody>().isKinematic;
        }

        return base.GetComponent<Rigidbody2D>() && base.GetComponent<Rigidbody2D>().simulated;
    }

    public virtual void SetSimulate(bool state)
    {
        if (base.GetComponent<Rigidbody>())
        {
            base.GetComponent<Rigidbody>().isKinematic = !state;
        }

        if (base.GetComponent<Rigidbody2D>())
        {
            base.GetComponent<Rigidbody2D>().simulated = state;
        }
    }

    public virtual void DisableSimulations()
    {
        this.SetSimulate(false);
    }

    public virtual void EnableSimulations()
    {
        this.SetSimulate(true);
    }

    public virtual void ResetVelocity()
    {
        this.SetVelocity(0.0, 0.0, 0.0);
        this.SetAngularVelocity(0.0, 0.0, 0.0);
    }

    public virtual void EnableShadow()
    {
        base.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
    }

    public virtual void DisableShadow()
    {
        base.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
    }

    public virtual Vector3 GetSize()
    {
        return base.GetComponent<MeshRenderer>().bounds.size;
    }

    public virtual float GetWidth()
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            return base.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }

        if (base.GetComponent<RectTransform>())
        {
            return base.GetComponent<RectTransform>().rect.width;
        }

        return 0f;
    }

    public virtual float GetHeight()
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            return base.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        }

        if (base.GetComponent<RectTransform>())
        {
            return base.GetComponent<RectTransform>().rect.height;
        }

        return 0f;
    }

    public virtual float GetWidthScaled()
    {
        return this.GetWidth() * this.GetScale();
    }

    public virtual float GetHeightScaled()
    {
        return this.GetHeight() * this.GetScale();
    }

    public virtual void SetSize(double width, double height)
    {
        this.SetWidth(width);
        this.SetHeight(height);
    }

    public virtual void SetWidth(double width)
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            base.GetComponent<SpriteRenderer>().size =
                new Vector2((float) width, base.GetComponent<SpriteRenderer>().size.y);
        }

        if (base.GetComponent<RectTransform>())
        {
            base.GetComponent<RectTransform>().sizeDelta =
                new Vector2((float) width, base.GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    public virtual void SetHeight(double height)
    {
        if (base.GetComponent<SpriteRenderer>())
        {
            base.GetComponent<SpriteRenderer>().size =
                new Vector2(base.GetComponent<SpriteRenderer>().size.x, (float) height);
        }

        if (base.GetComponent<RectTransform>())
        {
            base.GetComponent<RectTransform>().sizeDelta =
                new Vector2(base.GetComponent<RectTransform>().sizeDelta.x, (float) height);
        }
    }

    public virtual void EnableTrail(bool clear = true)
    {
        if (base.GetComponent<TrailRenderer>())
        {
            base.GetComponent<TrailRenderer>().enabled = true;
            if (clear)
            {
                this.ClearTrail();
            }
        }
    }

    public virtual void DisableTrail()
    {
        if (base.GetComponent<TrailRenderer>())
        {
            base.GetComponent<TrailRenderer>().enabled = false;
        }
    }

    public virtual void ClearTrail()
    {
        if (base.GetComponent<TrailRenderer>())
        {
            base.GetComponent<TrailRenderer>().Clear();
        }
    }

    public virtual void SetVisible(bool visible)
    {
        base.GetComponent<MeshRenderer>().enabled = visible;
    }
}