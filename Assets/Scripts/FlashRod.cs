using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRod : MonoBehaviour
{
    public GameObject rodImage;
    private SpriteRenderer BISR;
    public ParticleSystem rodParts;

    private void Start()
    {
        BISR = rodImage.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(flash());
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject tempParts = Instantiate(rodParts, collision.GetContact(0).point, Quaternion.Euler(-90, 0, 0)).gameObject;
            Destroy(tempParts, 0.5f);
        }
    }

    private IEnumerator flash()
    {
        float time = 0;
        BISR.color = new Vector4(1, 1, 1, 1);
        while (BISR.color.g != 0)
        {
            time += Time.deltaTime;
            BISR.color = new Vector4(1, Mathf.Lerp(1, 0, time), Mathf.Lerp(1, 0, time), 1);
            yield return new WaitForEndOfFrame();
        }
    }
}
