using UnityEngine;

public class Bomber
{
    public void Explode(Cube cube)
    {
        Vector3 explodePoint = cube.transform.position;

        Collider[] overlappdeColliders = Physics.OverlapSphere(explodePoint,cube.ExplosionRadius);

        foreach (Collider collider in overlappdeColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(cube.ExplosionForce, explodePoint, cube.ExplosionRadius);
                
            }
        }
    }
}