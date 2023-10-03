using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEye : MonoBehaviour
{
    public Transform closetEnemy;
    public GameObject[] multipleEnemies;
    public Tower tower;
    public bool shouldShoot;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponentInParent<Tower>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(closetEnemy != null)
        {
            LookAtEnemy();
            if(shouldShoot == true)
            {
                tower.Shoot();
            }
        }
        closetEnemy = GetClosetEnemy();
    }
    public void LookAtEnemy()
    {
        Vector2 lookDirection = closetEnemy.transform.position - transform.position;
        transform.up = new Vector2(lookDirection.x,lookDirection.y);
    }
    public Transform GetClosetEnemy()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closetDistance = Mathf.Infinity;
        Transform enemyPos = null;
        foreach(GameObject enemy in multipleEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position,enemy.transform.position);
            if(currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                enemyPos = enemy.transform;
            }
        }
        return enemyPos;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            shouldShoot = true;
            closetEnemy = GetClosetEnemy();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            shouldShoot = false;
        }
    }
}
