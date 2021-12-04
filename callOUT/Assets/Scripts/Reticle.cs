using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
     [SerializeField] RectTransform reticle;
     [SerializeField] Rigidbody player;
     public float restingSize;
     public float maxSize;
     public float speedReturnMultiplier;
     public float speedReturn;
     float currentSize;
    // Start is called before the first frame update
    void Update()
    {
       if (isMoving)
       {
           currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * player.velocity.sqrMagnitude * speedReturnMultiplier);
       }
       else
           {
               currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speedReturn);
           }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);

        print(player.velocity.sqrMagnitude);
    }

    bool isMoving
    {
        get
       {
           if(player.velocity.sqrMagnitude > 85f
           )
            return true;
            else
            return false;
       }
    }

}
