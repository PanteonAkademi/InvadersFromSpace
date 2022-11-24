using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    private const float maxX = 2.18f;
    private const float minX = -2.18f;

    private float speed = 3f;
    private bool isShooting;
    private float cooldown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;

    void Update()
    {
#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
		{
            transform.Translate(Vector2.left * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
		{
            transform.Translate(Vector2.right * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.Space) && !isShooting)
		{
            StartCoroutine(Shoot());
		}
#endif
    }

    private IEnumerator Shoot()
	{
        isShooting = true;
        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
	}

}
