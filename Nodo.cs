namespace ArvoresBin
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Menor { get; set; }
        public Nodo Maior { get; set; }
        public Nodo(int valor)
        {
            Valor = valor;
        }
        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}