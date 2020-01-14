using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;

    public int resolution = 100;

	Transform[] points;

    void Start()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        points = new Transform[resolution * resolution];
        for (int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                Transform point = Instantiate(pointPrefab);
                position.x = (x + 0.5f) * step - 1f;
                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform, false);
                points[i] = point;
            }
        }
    }

	void Update ()
    {
		for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
            position.y = Hemisphere(position.x, position.z);
			point.localPosition = position;
		}
	}

    float Hemisphere (float x, float z)
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