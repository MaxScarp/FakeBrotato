using UnityEngine;

public class Flowers : MonoBehaviour
{
    [SerializeField] private Transform[] pfFlowerArray;
    [SerializeField] private PolygonCollider2D boundingCollider;
    [SerializeField] private int flowerAmount = 25;

    private void Awake()
    {
        float boundX = boundingCollider.bounds.extents.x;
        float boundY = boundingCollider.bounds.extents.y;

        for (int i = 0; i < flowerAmount; i++)
        {
            int flowerIndex = Random.Range(0, pfFlowerArray.Length);
            float x = Random.Range(-boundX, boundX);
            float y = Random.Range(-boundY, boundY);

            Vector3 position = new Vector3(x, y);

            Instantiate(pfFlowerArray[flowerIndex], position, Quaternion.identity, transform);
        }

        enabled = false;
    }
}
