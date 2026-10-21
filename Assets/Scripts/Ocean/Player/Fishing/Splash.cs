using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private WaveDeformer wave;
     private SpriteRenderer sprite;
    [SerializeField] private HarpoonGun2 harp;
    [SerializeField] private GameObject splashPrefab;
    [SerializeField] private FishEngineReal engine;
    private GameObject harpHead;

    public bool hasSplashed;
    public float size;
    public float zOffset;

    private void Start()
    {
        harpHead = harp.harpHead;
    }
    private void Update()
    {
        if(harp.hasFire && !hasSplashed)
        {
            checkSplash(wave.GetVertices());
        }
         if(!harp.hasFire)
        {
            hasSplashed = false;
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
        

        hasSplashed = true;

        
        //this.transform.position = new Vector3(harpHead.transform.position.x,harpHead.transform.position.y,transform.position.z);

        float fraction = ((harpHead.transform.position.x - harp.harpEnd.transform.position.x)/(harpHead.transform.position.y -harp.harpEnd.transform.position.y));
        float radianZ = Mathf.Atan(fraction); // uses basic trig to find the angle to set rotation. 
        Quaternion splashRotation =  Quaternion.Euler(0,0,Mathf.Rad2Deg*radianZ*-1);
        Vector3 position = new Vector3(harpHead.transform.position.x,harpHead.transform.position.y,zOffset);
        GameObject splash = Instantiate(splashPrefab, position, splashRotation);
        splash.transform.localScale = new Vector3(size,size,size);
        var script = splash.GetComponent<Floater>();
        script.wave = this.wave;
        script.speed = this.engine;
        
        
    }
   
}
