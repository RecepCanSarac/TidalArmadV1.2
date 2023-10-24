using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TowerObject))]
public class TowerController : MonoBehaviour
{
    private TowerObject obj;

    [SerializeField] LayerMask detectLayer;
    [SerializeField] Transform towerHead;

    Transform nearestEnemy = null;
    bool attacking = false;
    bool isMirrored = false;
    float attackRate = 0;

    private void Start()
    {
        obj = GetComponent<TowerObject>();
        attackRate = obj.TowerData.attackSpeed;
    }

    private void Update()
    {
        if (attacking && nearestEnemy is not null)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, obj.TowerData.detectRange, detectLayer);

        if (enemies.Length > 0)
        {
            Transform newNearestEnemy = enemies.OrderBy((x) => Vector2.Distance(transform.position, x.transform.position)).FirstOrDefault().transform;

            if (newNearestEnemy != nearestEnemy)
            {
                nearestEnemy = newNearestEnemy;
                attacking = true;
            }
        }
        else
        {
            attacking = false;
            nearestEnemy = null;
        }
    }

    void Attack()
    {
        attackRate += Time.deltaTime;
        if (nearestEnemy != null)
        {
            if (attackRate > obj.TowerData.attackSpeed / 1)
            {
                obj.SpawnBullet(nearestEnemy.position, towerHead.localScale.x);
                attackRate = 0;
            }
        }
       
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        if (nearestEnemy != null)
        {
            Vector2 direction = nearestEnemy.position - towerHead.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (Mathf.Abs(angle) > 90f && Mathf.Abs(angle) < 270f)
            {
                if (!isMirrored)
                    MirrorObject();
                angle += 180;
            }
            else
            {
                if (isMirrored)
                    MirrorObject();
            }

            angle = isMirrored ? angle - 10f : angle + 10f;

            towerHead.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void MirrorObject()
    {
        Vector3 scale = towerHead.localScale;
        scale.x *= -1f;
        towerHead.localScale = scale;
        isMirrored = !isMirrored;
    }
}