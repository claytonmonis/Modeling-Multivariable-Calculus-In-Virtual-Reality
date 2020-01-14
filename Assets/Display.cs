using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    private int n;

    void OnEnable()
    {
        n = GameObject.Find("Res").GetComponent<Res>().GetRes();
        double r = Riemann(n);
        double d = Math.Abs(2.0943951023931953 - Riemann(n));
        double p = 100 * d / 2.0943951023931953;
        GetComponent<TextMesh>().text = "Volume of hemisphere: 2.0943951024 cubic units\n\nNumber of prisms: " + n + " x " + n + " = " + Math.Pow(n, 2) + "\nVolume of Riemann Prisms: " + Math.Round(r, 10) + " cubic units \nDifference: " + Math.Round(d, 10) + " cubic units\nPercent Difference: " + Math.Round(p, 8) + "%";
    }

    double F(double x, double y)
    {
        if(Math.Pow(x, 2) + Math.Pow(y, 2) < 1)
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

    double Riemann (double n)
    {
        double vol = 0;
        foreach(double x in Points(n))
        {
            foreach(double y in Points(n))
            {
                vol += (Math.Pow((2 / n), 2) * F(x, y));
            }
        }

        if (Double.IsNaN(vol))
        {
            return 0;
        }
        else
        {
            return vol;
        }
    }
}