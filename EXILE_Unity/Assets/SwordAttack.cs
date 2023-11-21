using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("EnemyBody"))
        {
            collider.transform.parent.GetComponent<Enemy>().Damage(1);
            Debug.Log(collider.transform.parent.GetComponent<Enemy>().health);
            if (collider.transform.parent.GetComponent<Enemy>().health <= 0)
            {
                for (int i = UnityEngine.Random.Range(1, 3); i < 5; i++)
                {
                    ItemWorld.DropItem(collider.transform.position,
                        new Item {itemType = Item.ItemType.Meat, amount = 1});
                }
                
                Destroy(collider.transform.parent.gameObject);
            }
        }
    }
}
