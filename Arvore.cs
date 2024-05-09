using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoresBin
{
    public class Arvore
    {
        private Nodo _raiz;

        #region Inserir, Buscar e Remover
        public void Inserir(int valor)
        {
            Nodo novoNodo = new(valor);

            if (_raiz == null)
            {
                Console.WriteLine($"º Valor '{novoNodo.Valor}' inserido na lista");
                _raiz = novoNodo;
                return;
            }

            Inserir(novoNodo, _raiz);
        }
        private void Inserir(Nodo nodo, Nodo nodoReferencia)
        {
            if (nodo.Valor > nodoReferencia.Valor)
            {
                if (nodoReferencia.Maior == null)
                {
                    nodoReferencia.Maior = nodo;
                    Console.WriteLine($"º Valor '{nodo.Valor}' inserido na lista");
                }
                else
                    Inserir(nodo, nodoReferencia.Maior);
            }
            else
            {
                if (nodoReferencia.Menor == null)
                {
                    Console.WriteLine($"º Valor '{nodo.Valor}' inserido na lista");
                    nodoReferencia.Menor = nodo;
                }
                else
                    Inserir(nodo, nodoReferencia.Menor);
            }
        }

        public bool Buscar(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return false;
            }

            return Buscar(valor, _raiz);
        }
        private bool Buscar(int valor, Nodo referencia)
        {
            if (valor == referencia.Valor)
                return true;
            else if (valor > referencia.Valor)
            {
                if (referencia.Maior != null)
                    return Buscar(valor, referencia.Maior);
            }
            else
            {
                if (referencia.Menor != null)
                    return Buscar(valor, referencia.Menor);
            }

            return false;
        }

        public void Remover(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            Remover(valor, _raiz);
        }
        private void Remover(int valor, Nodo referencia)
        {
            if (valor == referencia.Valor)
            {
                if (referencia.Menor != null)
                {
                    Nodo maiorNodoDoMenor = referencia.Menor;
                    while (maiorNodoDoMenor.Maior != null)
                    {
                        maiorNodoDoMenor = maiorNodoDoMenor.Maior;
                    }
                    maiorNodoDoMenor.Maior = referencia.Maior;
                    //referencia.Menor = maiorNodoDoMenor;
                    _raiz = referencia.Menor;

                    //deleta o nodo e redireciona os demais
                }
            }
            else if (valor > referencia.Valor)
            {
                if (referencia.Maior != null)
                    Remover(valor, referencia.Maior);
            }
            else
            {
                if (referencia.Menor != null)
                    Remover(valor, referencia.Menor);
            }
        }
        #endregion

        #region Travessias
        public void TravessiaEmOrdem()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            Console.Write("Travessia em Ordem: ");
            TravessiaEmOrdem(_raiz);
            Console.WriteLine("");
        }
        private void TravessiaEmOrdem(Nodo nodo)
        {
            if (nodo.Menor != null)
                TravessiaEmOrdem(nodo.Menor);

            Console.Write($" - {nodo.Valor}");

            if (nodo.Maior != null)
                TravessiaEmOrdem(nodo.Maior);
        }

        public void TravessiaPreOrdem()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            Console.Write("Travessia em Pré-Ordem: ");
            TravessiaPreOrdem(_raiz);
            Console.WriteLine("");
        }
        private void TravessiaPreOrdem(Nodo nodo)
        {
            Console.Write($" - {nodo.Valor}");

            if (nodo.Menor != null)
                TravessiaPreOrdem(nodo.Menor);

            if (nodo.Maior != null)
                TravessiaPreOrdem(nodo.Maior);
        }

        public void TravessiaPosOrdem()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            Console.Write("Travessia em Pós-Ordem: ");
            TravessiaPosOrdem(_raiz);
            Console.WriteLine("");
        }
        private void TravessiaPosOrdem(Nodo nodo)
        {
            if (nodo.Maior != null)
                TravessiaPosOrdem(nodo.Maior);

            if (nodo.Menor != null)
                TravessiaPosOrdem(nodo.Menor);

            Console.Write($" - {nodo.Valor}");
        }
        #endregion

        #region Altura, Nível e Valores
        public int DescobreAltura()
        {
            if (_raiz == null)
                return 0;

            int altura = DescobreAltura(_raiz);

            return altura;
        }
        private int DescobreAltura(Nodo nodo)
        {
            int alturaEsq = 0;
            int alturaDir = 0;

            if (nodo.Menor != null)
                alturaEsq = DescobreAltura(nodo.Menor);

            if (nodo.Maior != null)
                alturaDir = DescobreAltura(nodo.Maior);

            if (alturaEsq > alturaDir)
                return alturaEsq + 1;
            else
                return alturaDir + 1;
        }

        public string Nivel(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine();
                return "Árvore não existe";
            }

            int nivel = Nivel(valor, 0, _raiz);

            string resultado = nivel == 0 ? "Valor não encontrado" : nivel.ToString();

            return resultado;
        }
        private int Nivel(int valor, int nivelAtual, Nodo nodo)
        {
            //Caso não encontre o valor na árvore retorna 0 (valor não encontrado)
            if (nodo == null) return 0;

            if (nodo.Valor == valor)
                return nivelAtual + 1;

            int nivelEsquerda = Nivel(valor, nivelAtual + 1, nodo.Maior);
            if (nivelEsquerda != 0)
                return nivelEsquerda;

            int nivelDireita = Nivel(valor, nivelAtual + 1, nodo.Menor);
            return nivelDireita;
        }

        public void MenorValor()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            MenorValor(_raiz);
        }
        private void MenorValor(Nodo nodo)
        {
            if (nodo.Menor != null)
                MenorValor(nodo.Menor);
            else
                Console.WriteLine("Menor Valor da Árvore: " + nodo.Valor);
        }

        public void MaiorValor()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            MaiorValor(_raiz);
        }
        private void MaiorValor(Nodo nodo)
        {
            if (nodo.Maior != null)
                MaiorValor(nodo.Maior);
            else
                Console.WriteLine("Maior Valor da Árvore: " + nodo.Valor);
        }

        public List<List<int>> ObterNiveis()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return null;
            }

            List<List<int>> niveis = new List<List<int>>();
            return ObterNiveisRecursivo(_raiz, niveis, 0);
        }
        private List<List<int>> ObterNiveisRecursivo(Nodo nodo, List<List<int>> niveis, int nivelAtual)
        {
            if (niveis.Count <= nivelAtual)
            {
                niveis.Add(new List<int>());
            }

            niveis[nivelAtual].Add(nodo.Valor);

            // Chamamos a função recursivamente para os filhos do nó
            if (nodo.Menor != null)
                niveis = ObterNiveisRecursivo(nodo.Menor, niveis, nivelAtual + 1);

            if (nodo.Maior != null)
                niveis = ObterNiveisRecursivo(nodo.Maior, niveis, nivelAtual + 1);

            return niveis;
        }

        #endregion

        #region VerificarABB, ObterValoresAteONo e Inverter
        public bool VerificarABB()
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return false;
            }

            return VerificarABB(_raiz);
        }
        private bool VerificarABB(Nodo nodo)
        {
            bool ehAbb;

            if (nodo.Menor != null)
            {
                if (nodo.Maior != null)
                {
                    if (nodo.Menor.Valor < nodo.Maior.Valor)
                    {
                        ehAbb = VerificarABB(nodo.Menor);
                        if (!ehAbb)
                            return false;
                    }
                    else
                        return false;
                }
                else
                {
                    ehAbb = VerificarABB(nodo.Menor);
                    if (!ehAbb)
                        return false;
                }
            }

            if (nodo.Maior != null)
            {
                if (nodo.Menor != null)
                {
                    if (nodo.Menor.Valor < nodo.Maior.Valor)
                    {
                        ehAbb = VerificarABB(nodo.Maior);
                        if (!ehAbb)
                            return false;
                    }
                    else
                        return false;
                }
                else
                {
                    ehAbb = VerificarABB(nodo.Maior);
                    if (!ehAbb)
                        return false;
                }
            }

            return true;
        }

        public List<int> ObterValoresAteONo(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return null;
            }

            List<int> valores = new List<int>();
            bool valorEncontrado = false;
            (valores, valorEncontrado) = ObterValoresAteONo(_raiz, valor, valores, valorEncontrado);
            valores.Reverse();

            return valores;
        }
        private (List<int>, bool) ObterValoresAteONo(Nodo nodo, int valor, List<int> valores, bool valorEncontrado)
        {
            if (nodo.Valor == valor)
            {
                valores.Add(nodo.Valor);
                return (valores, true);
            }

            if (nodo.Menor != null)
            {
                (valores, valorEncontrado) = ObterValoresAteONo(nodo.Menor, valor, valores, valorEncontrado);
                if (valorEncontrado)
                {
                    valores.Add(nodo.Valor);
                }
            }

            if (!valorEncontrado)
            {
                if (nodo.Maior != null)
                {
                    (valores, valorEncontrado) = ObterValoresAteONo(nodo.Maior, valor, valores, valorEncontrado);
                    if (valorEncontrado)
                    {
                        valores.Add(nodo.Valor);
                    }
                }
            }

            return (valores, valorEncontrado);
        }

        public void Inverter()
        {
            if (_raiz == null)
                Console.WriteLine("A árvore está vazia");

            Inverter(_raiz);
        }
        private void Inverter(Nodo nodo)
        {
            Nodo aux = nodo.Menor;

            nodo.Menor = nodo.Maior;
            nodo.Maior = aux;

            if (nodo.Menor != null)
                Inverter(nodo.Menor);

            if (nodo.Maior != null)
                Inverter(nodo.Maior);
        }
        #endregion
    }
}