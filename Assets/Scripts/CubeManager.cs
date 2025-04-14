using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeGenerator[] generatedCube = new CubeGenerator[5];

    public float timer = 0.0f;
    public float interval = 3.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            RandomizeCubeActivation();
            timer = 0.0f;
        }
    }

    public void RandomizeCubeActivation()
    {
        for (int i = 0; i < generatedCube.Length; i++) 
        {
            int randomNum = Random.Range(0, 2);
            if (randomNum == 1)
            {
                generatedCube[i].GenCube();
            }
        }
    }
}
