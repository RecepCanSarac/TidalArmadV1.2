using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportBullet : MonoBehaviour
{
    public GameObject Object;

    private Transform target;
    public float bulletSpeed = 5f;

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;

            direction.Normalize();

            transform.position = (Vector2)transform.position + direction * bulletSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyMoveController>() != null)
        {
            StartCoroutine(enemy(other.gameObject));
        }
        if (other.gameObject.GetComponent<BloopEnemyMove>() != null)
        {
            StartCoroutine(bloob(other.gameObject));
        }
    }
    IEnumerator enemy(GameObject enemy)
    {
        stopEnemy(enemy);
        GameObject obj = Instantiate(Object, enemy.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(obj);
        GoEnemy(enemy);
    }
    IEnumerator bloob(GameObject enemy)
    {
        StopBloob(enemy);
        GameObject obj = Instantiate(Object, enemy.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        Destroy(obj);
        GoBloob(enemy);
    }
    void stopEnemy(GameObject enemy)
    {
        enemy.GetComponent<EnemyMoveController>().currentSpeed = 0;
    }
    void GoEnemy(GameObject enemy)
    {
        enemy.GetComponent<EnemyMoveController>().currentSpeed = enemy.GetComponent<EnemyMoveController>().enemy.speed;
    }
    void StopBloob(GameObject enemy)
    {
        enemy.GetComponent<BloopEnemyMove>().xMove = 0;
        enemy.GetComponent<BloopEnemyMove>().frequency = 0;
    }
    void GoBloob(GameObject enemy)
    {
        enemy.GetComponent<BloopEnemyMove>().xMove = enemy.GetComponent<BloopEnemyMove>().currentXMove;
        enemy.GetComponent<BloopEnemyMove>().frequency = enemy.GetComponent<BloopEnemyMove>().currnetFrequency;
    }
}
