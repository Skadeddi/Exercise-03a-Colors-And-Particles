using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWalls : MonoBehaviour
{
    private SpriteRenderer BISR;

    private void Start()
    {
        BISR = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            StartCoroutine(flash());
    }

    private IEnumerator flash()
    {
        float time = 0;
        BISR.color = new Vector4(1, 0, 0, 1);
        while (BISR.color.g != 1)
        {
            time += Time.deltaTime;
            BISR.color = new Vector4(1, Mathf.Lerp(0, 1, time), Mathf.Lerp(0, 1, time), 1);
            yield return new WaitForEndOfFrame();
        }
    }
}
