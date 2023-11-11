using UnityEngine;

public class Flowers : MonoBehaviour
{
    [SerializeField] private Transform[] pfFlowerArray;
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private int flowerAmount = 25;

    private void Awake()
    {
        float boundX = backgroundSpriteRenderer.bounds.extents.x;
        float boundY = backgroundSpriteRenderer.bounds.extents.y;

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
