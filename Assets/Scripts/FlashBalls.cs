using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBalls : MonoBehaviour
{
    public GameObject ballImage;
    private SpriteRenderer BISR;

    private void Start()
    {
        BISR = ballImage.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(flash());
    }

    private IEnumerator flash()
    {
        float time = 0;
        BISR.color = new Vector4(1, 1, 1, 1);
        while(BISR.color.g != 0)
        {
            time += Time.deltaTime;
            BISR.color = new Vector4(1, Mathf.Lerp(1, 0, time), Mathf.Lerp(1, 0, time), 1);
            yield return new WaitForEndOfFrame();
        }
    }
}
