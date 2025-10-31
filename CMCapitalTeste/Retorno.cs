namespace CMCapitalAvaliacao
{
    public class Retorno<T>
    {
        public string mensagem { get; set; }
        public bool sucesso {  get; set; }
        public T? Value { get; set; }
    }
}
