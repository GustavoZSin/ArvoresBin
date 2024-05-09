using ArvoresBin;

/*#region Ex1
Console.WriteLine($"------------ Exercício 1 ------------");
Arvore arv1 = new();
arv1.Inserir(7);
arv1.Inserir(4);
arv1.Inserir(8);
arv1.Inserir(5);
arv1.Inserir(6);
arv1.Inserir(3);
arv1.Inserir(4);
arv1.Inserir(9);
arv1.Inserir(1);
arv1.Inserir(2);

int vExist = 8;
int vNotExist = 20;

bool exist = arv1.Buscar(8);
bool notExist = arv1.Buscar(20);

Console.WriteLine($"\nResultado da busca para o valor '{vExist}': {exist}");
Console.WriteLine($"Resultado da busca para o valor '{vNotExist}': {notExist}");

arv1.Remover(7);
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex2
Console.WriteLine($"\n------------ Exercício 2 ------------");
Arvore arv2 = new();
arv2.Inserir(7);
arv2.Inserir(4);
arv2.Inserir(8);
arv2.Inserir(5);
arv2.Inserir(6);
arv2.Inserir(3);
arv2.Inserir(4);
arv2.Inserir(9);
arv2.Inserir(1);
arv2.Inserir(2);

Console.WriteLine();

arv2.TravessiaEmOrdem();
arv2.TravessiaPreOrdem();
arv2.TravessiaPosOrdem();
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex3
Console.WriteLine($"\n------------ Exercício 3 ------------");
Console.WriteLine("Altura = " + arv2.DescobreAltura());
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex4
Console.WriteLine($"\n------------ Exercício 4 ------------");
int valorChecado = 6;
Console.WriteLine($"Nível do valor '{valorChecado}': " + arv2.Nivel(valorChecado));
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex5
Console.WriteLine($"\n------------ Exercício 5 ------------");
arv2.MenorValor();
arv2.MaiorValor();
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex6
Console.WriteLine($"\n------------ Exercício 6 ------------");
bool ehAbb = arv2.VerificarABB();
Console.WriteLine($"Árvore é uma árvore binária de busca? {ehAbb}");
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex7
Console.WriteLine($"\n------------ Exercício 7 ------------");
List<List<int>> niveis = arv2.ObterNiveis();

Console.WriteLine("Elementos de cada nível da árvore binária:");
foreach (var nivel in niveis)
{
    Console.WriteLine(string.Join(", ", nivel));
}
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex8
Console.WriteLine($"\n------------ Exercício 8 ------------");
int valorBuscado = 6;
List<int> valoresAteONo = arv2.ObterValoresAteONo(valorBuscado);
string resultado = valoresAteONo.Count() == 0 ? "Valor não encontrado na árvore" : string.Join(", ", valoresAteONo);

Console.WriteLine($"Valores até o valor {valorBuscado} ==> {resultado}");
Console.WriteLine($"-------------------------------------");
#endregion

#region Ex9
Console.WriteLine($"\n------------ Exercício 9 ------------");
arv2.TravessiaPreOrdem();
arv2.Inverter();
arv2.TravessiaPreOrdem();
Console.WriteLine($"-------------------------------------");
#endregion*/

Console.WriteLine("Árvore Normal");
Arvore arv = new();
arv.Inserir(9);
arv.Inserir(0);
arv.Inserir(8);
arv.Inserir(1);
arv.Inserir(7);
arv.Inserir(2);
arv.Inserir(6);
arv.Inserir(3);
arv.Inserir(5);
arv.Inserir(4);
arv.TravessiaEmOrdem();


Console.WriteLine("Árvore AVL");
ArvoreAVL arvAVL = new();
arvAVL.Inserir(9);
arvAVL.Inserir(0);
arvAVL.Inserir(8);
arvAVL.Inserir(1);
arvAVL.Inserir(7);
arvAVL.Inserir(2);
arvAVL.Inserir(6);
arvAVL.Inserir(3);
arvAVL.Inserir(5);
arvAVL.Inserir(4);
arvAVL.TravessiaEmOrdem();

int numeroExiste = 5;
Console.WriteLine($"A árvore contém o número {numeroExiste}: {arvAVL.ContemItem(numeroExiste)}");
int numeroNaoExiste = 21;
Console.WriteLine($"A árvore contém o número {numeroNaoExiste}: {arvAVL.ContemItem(numeroNaoExiste)}");

arvAVL.Remover(7);
arvAVL.TravessiaEmOrdem();

Console.WriteLine();