using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [Range(0.0f, 1.0f)]
    public float textureSpeed;
    
    

    // Update is called once per frame
    void Update()
    {
        if(player.Components.Rigidbody.velocity.x != 0)
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", GetComponent<Renderer>().material.GetTextureOffset("_MainTex") + new Vector2(textureSpeed, 0) * Time.deltaTime * player.Components.Rigidbody.velocity.x);
    }
}
