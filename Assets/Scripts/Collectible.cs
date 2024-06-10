using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType cType;
    GameObject player;
    public bool collected, magneting;

    public enum CollectibleType
    {
       Bones,
       Magnet
    }
    private void Update()
    {
        
        if (cType == CollectibleType.Bones && collected == false)
        {
            //if ((transform.position.z - player.transform.position.z) < 2)
            {
                magneting = true;
       
                //StartCoroutine(ToParent());
            }
        }
    }
    public IEnumerator ToParent()
    {
        collected = true;
       // transform.parent = player.transform.parent;
        transform.DOLocalMove(Vector3.zero + new Vector3(0, 1, 0), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    
        
    }
}
