using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private WaveDeformer wave;
     private SpriteRenderer sprite;
    [SerializeField] private HarpoonGun2 harp;
    [SerializeField] private Transform holder;
    private GameObject harpHead;

    private bool hasSplashed;
    public float size;
    public float zOffset;

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
        this.transform.position = new Vector3(harpHead.transform.position.x,harpHead.transform.position.y,transform.position.z);
        
       // Quaternion splashRotation =  Quaternion.Euler(0,0,-10*Mathf.Atan(harp.harpoon.transform.position.y-this.transform.position.y/harp.harpoon.transform.position.x-this.transform.position.x));
       //Quaternion splashRotation = Quaternion.Inverse(harpHead.transform.rotation);
       Quaternion q = harpHead.transform.rotation;
       Quaternion splashRotation = new Quaternion(-q.x,q.y,-q.z,q.w);
       this.transform.localScale = new Vector3(size,size,size);
        //if(splashRotation)
        this.transform.rotation =  splashRotation;
        anim.SetTrigger("Splash");
        
    }
    private void SplashEnd()
    {
        transform.parent = holder;
        transform.position = new Vector3(harpHead.transform.position.x,harpHead.transform.position.y, transform.position.z);
        sprite.enabled = false;
         this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,zOffset);
        hasSplashed = false;
    }
}
