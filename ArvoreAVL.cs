using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArvoresBin
{
    internal class ArvoreAVL
    {
        private Nodo _raiz;

        #region Inserir
        public void Inserir(int valor)
        {
            Nodo novoNodo = new(valor);

            if (_raiz == null)
            {
                Console.WriteLine($"º Valor '{novoNodo.Valor}' inserido na lista");
                _raiz = novoNodo;
                return;
            }

            _raiz = Inserir(novoNodo, _raiz);
        }
        private Nodo Inserir(Nodo novoNodo, Nodo raizAtual)
        {
            if (raizAtual == null)
            {
                return novoNodo;
            }

            if (novoNodo.Valor < raizAtual.Valor)
            {
                raizAtual.Menor = Inserir(novoNodo, raizAtual.Menor);
            }
            else if (novoNodo.Valor > raizAtual.Valor)
            {
                raizAtual.Maior = Inserir(novoNodo, raizAtual.Maior);
            }
            else
            {
                // Valor já existe na árvore, não faz nada
                return raizAtual;
            }

            raizAtual = BalancearArvore(raizAtual);
            return raizAtual;
        }
        #endregion

        #region Balanceamento
        private Nodo BalancearArvore(Nodo nodo)
        {
            int fatorBalanceamento = FatorDeBalanceamento(nodo);

            //valores entre -1 e 1 indicam que a arvore esta balanceada
            if (fatorBalanceamento > 1)
            {
                //Arvore desbalanceada
                if (FatorDeBalanceamento(nodo.Menor) >= 0)
                {
                    return RotacaoDireita(nodo);
                }
                else
                {
                    nodo.Menor = RotacaoEsquerda(nodo.Menor);
                    return RotacaoDireita(nodo);
                }
            }
            else if (fatorBalanceamento < -1)
            {
                //Arvore desbalanceada
                if (FatorDeBalanceamento(nodo.Maior) <= 0)
                {
                    return RotacaoEsquerda(nodo);
                }
                else
                {
                    nodo.Maior = RotacaoDireita(nodo.Maior);
                    return RotacaoEsquerda(nodo);
                }
            }

            return nodo;
        }
        private int FatorDeBalanceamento(Nodo nodo)
        {
            return ObtemAltura(nodo.Menor) - ObtemAltura(nodo.Maior);
        }
        private int ObtemAltura(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }

            return 1 + Math.Max(ObtemAltura(nodo.Menor), ObtemAltura(nodo.Maior));
        }
        #endregion

        #region Rotacoes
        private Nodo RotacaoEsquerda(Nodo nodo)
        {
            if (nodo == null || nodo.Maior == null)
            {
                return nodo;
            }

            Nodo pivo = nodo.Maior;
            nodo.Maior = pivo.Menor;
            pivo.Menor = nodo;
            return pivo;
        }

        private Nodo RotacaoDireita(Nodo nodo)
        {
            if (nodo == null || nodo.Menor == null)
            {
                return nodo;
            }

            Nodo pivo = nodo.Menor;
            nodo.Menor = pivo.Maior;
            pivo.Maior = nodo;
            return pivo;
        }

        #endregion

        #region Exibir
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
        #endregion

        #region ContemItem
        public bool ContemItem(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return false;
            }

            return BuscaItem(_raiz, valor);
        }
        private bool BuscaItem(Nodo nodo, int valor)
        {
            if (nodo.Valor == valor)
                return true;

            bool encontrado = false;

            if (nodo.Menor != null)
            {
                encontrado = BuscaItem(nodo.Menor, valor);
                if (encontrado) return true;
            }

            if (nodo.Maior != null)
            {
                encontrado = BuscaItem(nodo.Maior, valor);
                if (encontrado) return true;
            }

            return encontrado;
        }
        #endregion

        #region Remover
        public void Remover(int valor)
        {
            if (_raiz == null)
            {
                Console.WriteLine("A árvore está vazia");
                return;
            }

            _raiz = Remover(_raiz, valor);
        }

        private Nodo Remover(Nodo raizAtual, int valor)
        {
            if (raizAtual == null)
                return raizAtual;

            if (valor < raizAtual.Valor)
                raizAtual.Menor = Remover(raizAtual.Menor, valor);
            else if (valor > raizAtual.Valor)
                raizAtual.Maior = Remover(raizAtual.Maior, valor);
            else
            {
                if (raizAtual.Menor == null || raizAtual.Maior == null)
                {
                    Nodo temp = null;
                    if (raizAtual.Menor == null)
                        temp = raizAtual.Maior;
                    else
                        temp = raizAtual.Menor;

                    if (temp == null)
                        raizAtual = null;
                    else
                        raizAtual = temp;
                }
                else
                {
                    Nodo temp = NodoMinimo(raizAtual.Maior);
                    raizAtual.Valor = temp.Valor;
                    raizAtual.Maior = Remover(raizAtual.Maior, temp.Valor);
                }
            }

            if (raizAtual == null)
            {
                return raizAtual;
            }

            raizAtual = BalancearArvore(raizAtual);
            return raizAtual;
        }

        private Nodo NodoMinimo(Nodo nodo)
        {
            Nodo atual = nodo;

            while (atual.Menor != null)
            {
                atual = atual.Menor;
            }

            return atual;
        }

        #endregion
    }
}
