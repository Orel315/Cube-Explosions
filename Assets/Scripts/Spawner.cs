using UnityEngine;

public class Spawner : MonoBehaviour
{

    private int _maxChildrenCount = 6;
    private int _minChildrenCount = 2;

    public void SpawnChildrens(Cube cube)
    {
        int childrenCount = Random.Range(_minChildrenCount, _maxChildrenCount + 1);

        Cube[] childrenCubes = new Cube[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            childrenCubes[i] = Instantiate(cube, cube.transform.position, Quaternion.identity);
            childrenCubes[i].ReduceParameters(); 
        }
    }
}