using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolText : MonoBehaviour
{

    public Transform volTextPrefab;

    Transform[] volTexts;

    private int resolution;

    void OnEnable()
    {
        resolution = GameObject.Find("Res").GetComponent<Res>().GetRes();
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * 0.02f;
        Vector3 position;
        position.y = 0f;
        volTexts = new Transform[resolution * resolution];
        for (int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                Transform volText = Instantiate(volTextPrefab);
                position.x = (x + 0.5f) * step - 1f;
                volText.localPosition = position;
                volText.localScale = scale;
                volText.SetParent(transform, false);
                volTexts[i] = volText;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < volTexts.Length; i++)
        {
            Transform volText = volTexts[i];
            Vector3 scale = volText.localScale;
            Vector3 position = volText.localPosition;
            volText.gameObject.GetComponent<TextMesh>().text = Riemann(position.x, position.z, resolution);
            position.y += 0.5f * scale.y;
            volText.localScale = scale;
            volText.localPosition = position;
        }
        enabled = false;
    }

    double F(double x, double y)
    {
        if (Math.Pow(x, 2) + Math.Pow(y, 2) < 1)
        {
            return Math.Sqrt(1 - (Math.Pow(x, 2) + Math.Pow(y, 2)));
        }
        else
        {
            return 0;
        }
    }

    List<double> Points(double n)
    {
        List<double> lst = new List<double>();
        lst.Add((1 / n) - 1);
        for (int point = 0; point < n - 1; point++)
        {
            lst.Add(lst[lst.Count - 1] + (2 / n));
        }
        return lst;
    }

    String Riemann(double x, double y, double n)
    {
        return (Math.Round(Math.Pow((2.0 / n), 2.0) * F(x, y), 5)).ToString();
    }

}