using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour
{
    private static CrossFade instance;
    private static Animator anim;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    public static void Load(Loader.Scene scene)
    {
        instance.StartCoroutine(instance.FadeOut(scene));
    }

    public static void LoadCurrentScene()
    {
        instance.StartCoroutine(instance.FadeOutCurrent());
    }

    IEnumerator FadeOut(Loader.Scene scene)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        Loader.Load(scene);
    }

    IEnumerator FadeOutCurrent()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        Loader.LoadCurrentScene();
    }
}
