using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeController : MonoBehaviour
{
    public float fuerzaSalto = 10;
    public float velocidad = 5;
    public float correr=10;
    private bool EstaSaltando = false;
    private bool EstaMuerto = false;
    private bool EstaDestruido = false;
    private bool EstaCorriendo=true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    
    private const int ANIMATION_QUIETO = 0;
     private const int ANIMATION_CAMINAR = 1;
    private const int ANIMATION_CORRER = 2;
    private const int ANIMATION_SALTAR = 3;   
    private const int ANIMATION_ATACK = 4;
 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
       
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(EstaSaltando==false){
                 CambiarAnimacion(ANIMATION_CAMINAR);//Accion correr 
            }else{
                CambiarAnimacion(ANIMATION_SALTAR);
            }
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
          
            spriteRenderer.flipX = true;
            if(Input.GetKey(KeyCode.X)){
                rb.velocity = new Vector2(-correr, rb.velocity.y);//velocidad de mi objeto
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                if(EstaSaltando==false){
                 CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                }else{
                    CambiarAnimacion(ANIMATION_SALTAR);
                }
            }
            if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
            {
                CambiarAnimacion(ANIMATION_SALTAR);
                Saltar();       
                EstaSaltando = true;
                EstaCorriendo = false;
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if(EstaSaltando==false){
                 CambiarAnimacion(ANIMATION_CAMINAR);//Accion correr 
            }else{
                CambiarAnimacion(ANIMATION_SALTAR);
            }
            rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto           
            spriteRenderer.flipX = false;

            if(Input.GetKey(KeyCode.X)){
                rb.velocity = new Vector2(correr, rb.velocity.y);//velocidad de mi objeto
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                if(EstaSaltando==false){
                 CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                }else{
                    CambiarAnimacion(ANIMATION_SALTAR);
                }
            }
            if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
            {
                CambiarAnimacion(ANIMATION_SALTAR);
                Saltar();       
                EstaSaltando = true;
                EstaCorriendo = false;
            }
        }else if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
        {
            CambiarAnimacion(ANIMATION_SALTAR);
            Saltar();       
            EstaSaltando = true;
            EstaCorriendo = false;
        }else if(Input.GetKey(KeyCode.Z))
        {
            CambiarAnimacion(ANIMATION_ATACK);
        }
        else if(EstaSaltando==false)    
        {
            CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
            rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
        }
       
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "suelo"){
            EstaSaltando = false;
        }
    }
    private void Saltar()
    {
         
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }
      private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
