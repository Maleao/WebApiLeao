namespace WebApiLeao.Domain.Entities
{
    public class Cursos
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
