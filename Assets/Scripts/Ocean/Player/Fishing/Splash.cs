using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private WaveDeformer wave;
     private SpriteRenderer sprite;
    [SerializeField] private HarpoonGun2 harp;
    private GameObject harpHead;

    private bool hasSplashed;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sprite.enabled = false;
        harpHead = harp.harpHead;

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
        float closestX = 10000f;
        int closestIndex = 0; 
        for(int i =0; i<positions.Length; i++)
        {
            if(Mathf.Abs(positions[i].x - harpHead.transform.position.x) < closestX)
            {
                closestIndex = i;
            }
        }
        if(harpHead.transform.position.y < positions[closestIndex].y){
            SplashAnimation();
        }
    }
    
    private void SplashAnimation() 
    { 
        transform.parent = null;
        sprite.enabled = true;
        hasSplashed = true;
        this.transform.position = new Vector3(harpHead.transform.position.x,harpHead.transform.position.y,0f);
        this.transform.rotation = Quaternion.Euler(0,0,-harpHead.transform.rotation.z);
        Debug.Log(-harpHead.transform.rotation.z);
       
        anim.SetTrigger("Splash");
    }
    private void SplashEnd()
    {
        transform.parent = harpHead.transform;
        transform.position = harpHead.transform.position;
        sprite.enabled = false;
        hasSplashed = false;
    }
}
