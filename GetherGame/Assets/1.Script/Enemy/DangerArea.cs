using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    SpriteRenderer sprite;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeInOut());
        StartCoroutine(DieArea());
    }

    IEnumerator FadeInOut()
    {
        Color NowColor = sprite.color;
        Color TargetColor = new Color(1, 0.15f, 0.15f,0);
        for(float i=0;i<1;i+=0.05f)
        {
            yield return new WaitForSeconds(0.01f);
            sprite.color = Color.Lerp(NowColor, TargetColor, i);
        }
        for(float i=0;i<1;i+=0.05f)
        {
            yield return new WaitForSeconds(0.01f);
            sprite.color = Color.Lerp(TargetColor, NowColor, i);
        }
        StartCoroutine(FadeInOut());
    }

    IEnumerator DieArea()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
