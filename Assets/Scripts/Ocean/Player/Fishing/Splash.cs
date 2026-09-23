using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private WaveDeformer wave;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private HarpoonGun2 harp;

    private bool hasSplashed;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.enabled = false;

    }
    private void Update()
    {
        if(harp.hasFire && !hasSplashed)
        {
            checkSplash(wave.GetVertices());
        }
    }

    private void checkSplash(Vector2[] positions)
    {
        for(int i =0; i<positions.Length; i++)
        {
            if(positions[i].y > transform.position.y)
            {
                SplashAnimation(positions[i]);
                i= 1000; 
            }
        }
    }
    
    private void SplashAnimation(Vector2 location) 
    {
        sprite.enabled = true;
        this.transform.position = new Vector3(location.x,location.y,0f);
        anim.SetTrigger("Splash");
    }
}
