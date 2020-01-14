using UnityEngine;

public class Riemann : MonoBehaviour
{

    public Transform prismPrefab;

    private int resolution;

    Transform[] prisms;

    void OnEnable()
    {
        resolution = GameObject.Find("Res").GetComponent<Res>().GetRes();
        Debug.Log("Riemann: " + resolution);
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        prisms = new Transform[resolution * resolution];
        for (int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                Transform prism = Instantiate(prismPrefab);
                position.x = (x + 0.5f) * step - 1f;
                prism.localPosition = position;
                prism.localScale = scale;
                prism.SetParent(transform, false);
                prisms[i] = prism;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < prisms.Length; i++)
        {
            Transform prism = prisms[i];
            Vector3 scale = prism.localScale;
            Vector3 position = prism.localPosition;
            scale.y = Hemisphere(position.x, position.z);
            position.y += 0.5f * scale.y;
            prism.localScale = scale;
            prism.localPosition = position;
        }
        enabled = false;
    }

    float Hemisphere(float x, float z)
    {
        if (x * x + z * z < 1)
        {
            return Mathf.Sqrt(1 - x * x - z * z);
        }
        else
        {
            return 0f;
        }
    }
}