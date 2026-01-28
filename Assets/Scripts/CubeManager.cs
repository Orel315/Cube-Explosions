using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cubePrefab;
    [SerializeField] private int _minCubesToSpawn = 2;
    [SerializeField] private int _maxCubesToSpawn = 6;
    [SerializeField] private float explosionForce = 0.1f;

    private int relativeToTheCube = 2;
    private int decreaseChance = 2;
    private float splitChance = 1.0f;
    private float decreaseValue = 0.5f;
    private float minimumDecreaseChance = 0.05f;
    private float delayedRemovalForExplosion = 0.1f;

    private void OnMouseDown()
    {
        if (Random.value < splitChance)
        {
            Destroy(gameObject, delayedRemovalForExplosion);
            int newCubesCount = Random.Range(_minCubesToSpawn, _maxCubesToSpawn);

            for (int i = 0; i < newCubesCount; i++)
            {
                CreateNewCube();
            }

            splitChance = Mathf.Max(splitChance / decreaseChance, minimumDecreaseChance);
            Rigidbody[] rbs = FindObjectsOfType<Rigidbody>();

            foreach (Rigidbody rb in rbs)
            {
                if (rb.gameObject != gameObject)
                {
                    Vector3 direction = rb.position - transform.position;
                    rb.AddForce(direction.normalized * explosionForce, ForceMode.Impulse);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateNewCube()
    {
        GameObject newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        newCube.transform.localScale = transform.localScale * decreaseValue;
        newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
        newCube.AddComponent<BoxCollider>();
        Vector3 randomPosition = Random.insideUnitSphere * relativeToTheCube;
        newCube.transform.position = transform.position + randomPosition;
    }
}