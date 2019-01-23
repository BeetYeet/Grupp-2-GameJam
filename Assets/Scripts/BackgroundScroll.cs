using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material[] mat;

    [SerializeField]
    float parallaxScalarDifference = 0.25f, scalar = 0.05f;

    void Awake()
    {
        mat = GetComponent<Renderer>().materials;
    }

    void Update()
    {
        //mat[0].SetTextureOffset("_MainTex", new Vector2(0, Time.time * scalar));
        //mat[1].SetTextureOffset("_MainTex", new Vector2(0, Time.time * scalar * parallaxScalarDifference));

        for (int i = 0; i < mat.Length; i++)
            mat[i].SetTextureOffset("_MainTex", new Vector2(0, Time.time * scalar * ((Mathf.Abs(scalar - parallaxScalarDifference)) * i)));
    }
}
