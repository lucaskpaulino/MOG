using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{

    public LineRenderer linha;
    public Transform ponto0, ponto1, ponto2, ponto3, ponto4;



    private int qntPontos = 1000;
    private Vector3[] posicoes = new Vector3[1000];
    // Start is called before the first frame update
    void Start()
    {
        linha.positionCount =qntPontos;
        Debug.Log(" " + CalculaBezier(0, ponto0.position, ponto1.position, ponto2.position, ponto3.position, ponto4.position));
    }

    // Update is called once per frame
    void Update()
    {
        DesenhaCurva();

        
    }


    private void DesenhaCurva()
    {
        for(int i = 1; i<=qntPontos; i++)
        {
            float t = i / (float)qntPontos;
            //Chama a Função Responsável pelo calculo da curva
            posicoes[i-1] = CalculaBezier(t, ponto0.position, ponto1.position, ponto2.position, ponto3.position, ponto4.position);

            //Força a Interpolação a curva com o p0 e p5
            //posicoes[0] = ponto0.position;  
            
           
        }
        
        linha.SetPositions(posicoes);

    }

    private Vector2 CalculaBezier(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
    {
        // P = (1−t)5P0 + 5(1−t)4tP1 +5(1−t)4tP2 +5(1−t)4tP3 +5(1−t)4tP4 + t5P5

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;
        float uuuu = uuu* uu * u;
        float tttt = ttt* tt * t;


        Vector2 p = uuuu * p0;
        p += 4 * uuu * t * p1;
        p += 4 * uu * tt * p2;
        p += 4 * u * ttt * p3;
        p +=  tttt * p4;
        


        return p;
    }
}
