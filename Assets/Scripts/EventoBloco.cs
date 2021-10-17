using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EventoBloco : MonoBehaviour
{
    [SerializeField] private float _velocidadeDoTexto;

    [SerializeField] private TextMeshProUGUI _texto;
    [SerializeField] private string[] perguntas;

    [SerializeField] private TextMeshProUGUI _textoAcao;
    [SerializeField] private string[] acoes;

    [SerializeField] private TextMeshProUGUI _A;
    [SerializeField] private TextMeshProUGUI _B;
    [SerializeField] private TextMeshProUGUI _C;
    [SerializeField] private TextMeshProUGUI _D;
    [SerializeField] private int[] arrayResposta;
    //Opcoes de resposta
    [SerializeField] private string[] a;
    [SerializeField] private string[] b;
    [SerializeField] private string[] c;
    [SerializeField] private string[] d;

    //Feedbak ao jogador
    [SerializeField] private string[] correto;
    [SerializeField] private string[] errado;

    //possiveis posições
    [SerializeField] private Transform[] posicoes;
    //posições atuais de cada jogador
    [SerializeField] private int[] posicaoJogadores;
    //pontuação dos jogadores
    private int[] pontuacoes;

    //Indice para perguntas ou ações, aleatorias
    private int indice;

    private void Start()
    {
        //apenas teste
        Perguntas();
    }
    private void lancarDado()
    {
        //lancar dado ativando animação do dado e sorteando um número entre 1 e 6
    }

    private void Mover(int num)
    {
        //Ativa animação de movimentação do icone e aciona pergunta ou ação
        PerguntasAcoes();
    }

    //Gerador randômico de perguntas e ações
    private void PerguntasAcoes()
    {
        int x = Random.Range(0, 100);
        if(x <= 70)
        {
            Perguntas();
        }
        else
        {
            Acoes();
        }
    }

    private void Perguntas()
    {
        indice = Random.Range(0, perguntas.Length);

        _texto.text = perguntas[indice];
        _A.text = a[indice];
        _B.text = b[indice];
        _C.text = c[indice];
        _D.text = d[indice];
        StartCoroutine(EfeitoLetraPorLetra());
    }
    private IEnumerator EfeitoLetraPorLetra()
    {
        _A.maxVisibleCharacters = 0;
        _B.maxVisibleCharacters = 0;
        _C.maxVisibleCharacters = 0;
        _D.maxVisibleCharacters = 0;

        int caracteresTotais = _texto.text.Length;
        _texto.maxVisibleCharacters = 0;

        for (int i = 0; i <= caracteresTotais; i++)
        {
            _texto.maxVisibleCharacters = i;
            yield return new WaitForSeconds(_velocidadeDoTexto);
        }
        _A.maxVisibleCharacters = _A.text.Length;
        _B.maxVisibleCharacters = _B.text.Length;
        _C.maxVisibleCharacters = _C.text.Length;
        _D.maxVisibleCharacters = _D.text.Length;
    }

    //acionado pelo jogador ao selecionar a opção de resposta
    public void verificaResposta(int res)
    {
        if (arrayResposta[indice] == res)
        {
            //correto
            passaVez();
        }
        else 
        {
            //incorreto
            passaVez();
        }
    }
    private void Acoes()
    {
        //acoes
        passaVez();
    }

    //passa para a vez do próximo jogador
    private void passaVez()
    {
        //passa para a vez do próximo jogador
    }
}
