using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;  //Se crea nueva variable para almacena la variable Textura
    // Start is called before the first frame update
    void Start()
    {
        
    }


    //Ver el tutorial minuto 12:40
    // Update is called once per frame
    void Update()
    {                                                                                  // este numero representa la cantidad de frame en el eje x moviendose en la unidad de unity                
        fondo.material.mainTextureOffset= fondo.material.mainTextureOffset + new Vector2(0.065f,0) * Time.deltaTime;
    }
}
