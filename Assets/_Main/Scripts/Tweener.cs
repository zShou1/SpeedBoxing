using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

public class Tweener : Base
{
    protected List<Sequence> sequences = new List<Sequence>();

    protected Tween tween;

    protected Sequence sequence;

    public virtual Tween Field(double time, double value)
    {
        this.GetSequence()
            .Append(this.SetTween(base.GetComponent<UnityEngine.Camera>().DOFieldOfView((float) value, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(double time, double fade)
    {
        if (null != base.GetComponent<CanvasGroup>())
        {
            return this.Fade(base.GetComponent<CanvasGroup>(), time, fade);
        }

        if (null != base.GetComponent<SpriteRenderer>())
        {
            return this.Fade(base.GetComponent<SpriteRenderer>(), time, fade);
        }

        if (null != base.GetComponent<Image>())
        {
            return this.Fade(base.GetComponent<Image>(), time, fade);
        }

        if (null != base.GetComponent<UnityEngine.UI.Text>())
        {
            return this.Fade(base.GetComponent<UnityEngine.UI.Text>(), time, fade);
        }

        if (null != base.GetComponent<LineRenderer>())
        {
            return this.Fade(base.GetComponent<LineRenderer>(), time, fade);
        }

        if (null != base.GetComponent<Renderer>())
        {
            return this.Fade(base.GetComponent<Renderer>(), time, fade);
        }

        return null;
    }

    public virtual Tween Fade(double time, double start, double finish)
    {
        if (null != base.GetComponent<LineRenderer>())
        {
            return this.Fade(base.GetComponent<LineRenderer>(), time, start, finish);
        }

        return null;
    }

    public virtual Tween Fade(SpriteRenderer component, double time, double fade)
    {
        this.GetSequence().Append(this.SetTween(component.DOFade((float) fade, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(Image component, double time, double fade)
    {
        this.GetSequence().Append(this.SetTween(component.DOFade((float) fade, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(UnityEngine.UI.Text component, double time, double fade)
    {
        this.GetSequence().Append(this.SetTween(component.DOFade((float) fade, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(CanvasGroup component, double time, double fade)
    {
        this.GetSequence().Append(this.SetTween(component.DOFade((float) fade, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(LineRenderer component, double time, double start, double finish)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(
            new Color2(new Color(1f, 1f, 1f, (float) start), new Color(1f, 1f, 1f, (float) start)),
            new Color2(new Color(1f, 1f, 1f, (float) finish), new Color(1f, 1f, 1f, (float) finish)), (float) time)));
        return this.GetTween();
    }

    public virtual Tween Fade(Renderer component, double time, double fade)
    {
        this.GetSequence().Append(this.SetTween(component.material.DOFade((float) fade, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(double time, double r, double g, double b, double a = 1.0)
    {
        return this.Color(time, new Color((float) r, (float) g, (float) b, (float) a));
    }

    public virtual Tween Color(double time, Color color)
    {
        if (null != base.GetComponent<Camera>())
        {
            return this.Color(base.GetComponent<UnityEngine.Camera>(), time, color);
        }

        if (null != base.GetComponent<SpriteRenderer>())
        {
            return this.Color(base.GetComponent<SpriteRenderer>(), time, color);
        }

        if (null != base.GetComponent<MeshRenderer>())
        {
            return this.Color(base.GetComponent<MeshRenderer>(), time, color);
        }

        if (null != base.GetComponent<Material>())
        {
            return this.Color(base.GetComponent<Material>(), time, color);
        }

        if (null != base.GetComponent<Image>())
        {
            return this.Color(base.GetComponent<Image>(), time, color);
        }

        if (null != base.GetComponent<UnityEngine.UI.Text>())
        {
            return this.Color(base.GetComponent<UnityEngine.UI.Text>(), time, color);
        }

        if (null != base.GetComponent<LineRenderer>())
        {
            return this.Color(base.GetComponent<LineRenderer>(), time, color);
        }

        return null;
    }

    public virtual Tween Color(UnityEngine.Camera component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(SpriteRenderer component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(Material component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(Image component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(UnityEngine.UI.Text component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(MeshRenderer component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.material.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Color(LineRenderer component, double time, Color color)
    {
        this.GetSequence().Append(this.SetTween(component.DOColor(new Color2(component.startColor, component.endColor),
            new Color2(color, color), (float) time)));
        return this.GetTween();
    }

    public virtual Tween SharedColor(double time, Color color)
    {
        this.GetSequence()
            .Append(this.SetTween(base.GetComponent<MeshRenderer>().sharedMaterial.DOColor(color, (float) time)));
        return this.GetTween();
    }

    public virtual Tween SetTween(Tween tween)
    {
        this.tween = tween;
        return tween;
    }

    public virtual Tween GetTween()
    {
        return this.tween;
    }

    protected virtual void CreateSequence()
    {
        this.sequences.Add(this.sequence = DOTween.Sequence());
    }

    protected virtual void DestroySequence(Sequence sequence, bool complete = false)
    {
        sequence.Kill(complete);
        this.sequences.Remove(sequence);
    }

    protected virtual void PauseSequence(Sequence sequence)
    {
        sequence.Pause<Sequence>();
    }

    protected virtual void ResumeSequence(Sequence sequence)
    {
        sequence.Play<Sequence>();
    }

    public virtual Tween Spawn(params Tween[] tweeners)
    {
        return null;
    }

    public virtual Sequence Sequence(params Tween[] sequences)
    {
        Sequence result = this.sequence;
        this.sequence = null;
        return result;
    }

    public virtual Sequence GetSequence()
    {
        if (this.sequence == null)
        {
            this.CreateSequence();
        }

        return this.sequence;
    }

    public virtual void StopTweens(bool reset = false, bool complete = false)
    {
        for (int i = this.sequences.Count - 1; i >= 0; i--)
        {
            if (reset || !"button.animation".Equals(this.sequences[i].stringId))
            {
                this.DestroySequence(this.sequences[i], complete);
            }
        }

        if (reset && this.sequences.Count > 0)
        {
            DOTween.Kill(this, complete);
        }

        this.sequences.Clear();
    }

    public virtual void PauseTweens()
    {
        for (int i = this.sequences.Count - 1; i >= 0; i--)
        {
            this.PauseSequence(this.sequences[i]);
        }
    }

    public virtual void ResumeTweens()
    {
        for (int i = this.sequences.Count - 1; i >= 0; i--)
        {
            this.ResumeSequence(this.sequences[i]);
        }
    }

    public virtual void StopTween(string name, bool complete = false)
    {
        for (int i = this.sequences.Count - 1; i >= 0; i--)
        {
            if (name.Equals(this.sequences[i].stringId))
            {
                this.DestroySequence(this.sequences[i], complete);
            }
        }
    }

    public virtual List<Sequence> GetTweens()
    {
        return this.sequences;
    }

    public virtual Tween GetTween(string name)
    {
        for (int i = this.sequences.Count - 1; i >= 0; i--)
        {
            if (name.Equals(this.sequences[i].stringId) && this.sequences[i].IsPlaying())
            {
                return this.sequences[i];
            }
        }

        return null;
    }

    public virtual Tween Delay(double time)
    {
        return this.GetSequence().AppendInterval((float) time);
    }

    public virtual Tween Delay(double time, TweenCallback callback)
    {
        return this.GetSequence().AppendInterval((float) time).AppendCallback(callback);
    }

    public virtual Tween Delay(double min, double max)
    {
        return this.Delay((double) Math.Random(min, max));
    }

    public virtual Tween Finish(TweenCallback callback)
    {
        this.GetSequence().AppendCallback(callback);
        return null;
    }

    public virtual Tween Complete(TweenCallback callback)
    {
        this.GetSequence().OnComplete(callback);
        return null;
    }

    public virtual Tween Kill(TweenCallback callback)
    {
        this.GetSequence().OnKill(callback);
        return null;
    }

    public virtual Tween Loops()
    {
        this.GetSequence().SetLoops(-1, LoopType.Restart);
        return null;
    }

    public virtual Tween Loops(int count = -1, LoopType type = LoopType.Restart)
    {
        this.GetSequence().SetLoops(count, type);
        return null;
    }

    public virtual Tween Loops(LoopType type = LoopType.Restart)
    {
        this.GetSequence().SetLoops(-1, type);
        return null;
    }

    public virtual Tween Name(string name)
    {
        this.GetSequence().SetId(name);
        return null;
    }

    public virtual Tween Move(double time, Vector3 point)
    {
        return this.Move(time, (double) point.x, (double) point.y, (double) point.z);
    }

    public virtual Tween Move(double time, double x, double y, double z = 0.0)
    {
        if (base.GetComponent<RectTransform>() == null)
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DOLocalMove(new Vector3((float) x, (float) y, (float) z),
                    (float) time, false)));
        }
        else
        {
            this.GetSequence().Append(this.SetTween(base.GetComponent<RectTransform>()
                .DOAnchorPos3D(new Vector3((float) x, (float) y, (float) z), (float) time, false)));
        }

        return this.GetTween();
    }

    public virtual Tween MoveBy(double time, double x, double y, double z, bool local = true)
    {
        if (local)
        {
            this.GetSequence()
                .Append(this.SetTween(
                    base.transform.DOBlendableLocalMoveBy(new Vector3((float) x, (float) y, (float) z), (float) time,
                        false)));
        }
        else
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DOBlendableMoveBy(new Vector3((float) x, (float) y, (float) z),
                    (float) time, false)));
        }

        return this.GetTween();
    }

    public virtual Tween MoveBy(double time, double x, double y, bool local = true)
    {
        if (local)
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DOBlendableLocalMoveBy(new Vector3((float) x, (float) y, 0f),
                    (float) time, false)));
        }
        else
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DOBlendableMoveBy(new Vector3((float) x, (float) y, 0f),
                    (float) time, false)));
        }

        return this.GetTween();
    }

    public virtual Tween OffsetMaxX(double time, double x)
    {
        this.GetSequence().Append(this.Value(time, (double) base.GetComponent<RectTransform>().offsetMax.y, -x,
            delegate(float value)
            {
                base.GetComponent<RectTransform>().offsetMax =
                    new Vector2(value, base.GetComponent<RectTransform>().offsetMax.y);
            }));
        return this.GetTween();
    }

    public virtual Tween OffsetMaxY(double time, double y)
    {
        this.GetSequence().Append(this.Value(time, (double) base.GetComponent<RectTransform>().offsetMax.y, -y,
            delegate(float value)
            {
                base.GetComponent<RectTransform>().offsetMax =
                    new Vector2(base.GetComponent<RectTransform>().offsetMax.x, value);
            }));
        return this.GetTween();
    }

    public virtual Tween OffsetMinX(double time, double x)
    {
        this.GetSequence().Append(this.Value(time, (double) base.GetComponent<RectTransform>().offsetMin.y, x,
            delegate(float value)
            {
                base.GetComponent<RectTransform>().offsetMin =
                    new Vector2(value, base.GetComponent<RectTransform>().offsetMin.y);
            }));
        return this.GetTween();
    }

    public virtual Tween OffsetMinY(double time, double y)
    {
        this.GetSequence().Append(this.Value(time, (double) base.GetComponent<RectTransform>().offsetMin.y, y,
            delegate(float value)
            {
                base.GetComponent<RectTransform>().offsetMin =
                    new Vector2(base.GetComponent<RectTransform>().offsetMin.x, value);
            }));
        return this.GetTween();
    }

    public virtual Tween Pitch(double time, double pitch)
    {
        if (null != base.GetComponent<AudioSource>())
        {
            return this.Pitch(base.GetComponent<AudioSource>(), time, pitch);
        }

        return null;
    }

    public virtual Tween Pitch(AudioSource component, double time, double pitch)
    {
        this.GetSequence().Append(this.SetTween(component.DOPitch((float) pitch, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Progress(double time, double value)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Image>().DOFillAmount((float) value, (float) time)));
        return this.GetTween();
    }

    public virtual Tween RBMove(Vector3 to, double duration, bool snapping = false)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Rigidbody>().DOMove(to, (float) duration, snapping)));
        return this.GetTween();
    }

    public virtual Tween RBMoveX(double to, double duration, bool snapping = false)
    {
        this.GetSequence()
            .Append(this.SetTween(base.GetComponent<Rigidbody>().DOMoveX((float) to, (float) duration, snapping)));
        return this.GetTween();
    }

    public virtual Tween RBMoveY(double to, double duration, bool snapping = false)
    {
        this.GetSequence()
            .Append(this.SetTween(base.GetComponent<Rigidbody>().DOMoveY((float) to, (float) duration, snapping)));
        return this.GetTween();
    }

    public virtual Tween RBMoveZ(double to, double duration, bool snapping = false)
    {
        this.GetSequence()
            .Append(this.SetTween(base.GetComponent<Rigidbody>().DOMoveZ((float) to, (float) duration, snapping)));
        return this.GetTween();
    }

    public virtual Tween RBRotate(Vector3 to, double duration, RotateMode mode = RotateMode.Fast)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Rigidbody>().DORotate(to, (float) duration, mode)));
        return this.GetTween();
    }

    public virtual Tween Rotate(double time, double x, double y, double z, bool localRotate = false)
    {
        if (localRotate)
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DOLocalRotate(new Vector3((float) x, (float) y, (float) z),
                    (float) time, RotateMode.Fast)));
        }
        else
        {
            this.GetSequence()
                .Append(this.SetTween(base.transform.DORotate(new Vector3((float) x, (float) y, (float) z),
                    (float) time, RotateMode.Fast)));
        }

        return this.GetTween();
    }

    public virtual Tween Rotate(double time, Vector3 vector3, bool localRotate = false)
    {
        return this.Rotate(time, (double) vector3.x, (double) vector3.y, (double) vector3.z, localRotate);
    }

    public virtual Tween Rotate(double time, Quaternion quaternion)
    {
        this.GetSequence().Append(this.SetTween(base.transform.DORotateQuaternion(quaternion, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Rotate(double time, double rotation)
    {
        return this.Rotate(time, (double) base.transform.localEulerAngles.x, (double) base.transform.localEulerAngles.y,
            rotation, false);
    }

    public virtual Tween RotateBy(double time, double x, double y, double z)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Transform>()
            .DOBlendableLocalRotateBy(new Vector3((float) x, (float) y, (float) z), (float) time,
                RotateMode.FastBeyond360)));
        return this.GetTween();
    }

    public virtual Tween RotateBy(double time, double rotation)
    {
        return this.RotateBy(time, 0.0, 0.0, rotation);
    }

    public virtual Tween Scale(double time, double x, double y, double z)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Transform>()
            .DOScale(new Vector3((float) x, (float) y, (float) z), (float) time)));
        return this.GetTween();
    }

    public virtual Tween Scale(double time, double scale)
    {
        return this.Scale(time, scale, scale, scale);
    }

    public virtual Tween ScaleBy(double time, double x, double y, double z)
    {
        this.GetSequence()
            .Append(this.SetTween(
                base.transform.DOBlendableScaleBy(new Vector3((float) x, (float) y, (float) z), (float) time)));
        return this.GetTween();
    }

    public virtual Tween ScaleBy(double time, double scale)
    {
        return this.ScaleBy(time, scale, scale, scale);
    }

    public virtual Tween Shake(double time, double strength, double vibrate, double randomness, bool fade)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Transform>()
            .DOShakePosition((float) time, (float) strength, (int) vibrate, (float) randomness, false, fade)));
        return this.GetTween();
    }

    public virtual Tween Shake(double time, Vector3 strength, double vibrate, double randomness, bool fade)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<Transform>()
            .DOShakePosition((float) time, strength, (int) vibrate, (float) randomness, false, fade)));
        return this.GetTween();
    }

    public virtual Tween Size(double time, double x, double y)
    {
        this.GetSequence().Append(this.SetTween(base.GetComponent<RectTransform>()
            .DOSizeDelta(new Vector2((float) x, (float) y), (float) time, false)));
        return this.GetTween();
    }

    public virtual void SetTweenSpeed(string name, double speed)
    {
        if (this.GetTween(name) != null)
        {
            this.GetTween(name).timeScale = (float) speed;
        }
    }

    public virtual void SetTweensSpeed(double speed)
    {
        using (List<Sequence>.Enumerator enumerator = this.GetTweens().GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                enumerator.Current.timeScale = (float) speed;
            }
        }
    }

    public virtual Tween Value(double time, double start, double finish, DOSetter<float> action)
    {
        this.GetSequence().Append(this.SetTween(DOTween.To(action, (float) start, (float) finish, (float) time)));
        return this.GetTween();
    }

    public virtual Tween Volume(double time, double volume)
    {
        if (null != base.GetComponent<AudioSource>())
        {
            return this.Volume(base.GetComponent<AudioSource>(), time, volume);
        }

        return null;
    }

    public virtual Tween Volume(AudioSource component, double time, double volume)
    {
        this.GetSequence().Append(this.SetTween(component.DOFade((float) volume, (float) time)));
        return this.GetTween();
    }
}