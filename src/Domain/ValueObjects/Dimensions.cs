namespace Domain.ValueObjects;

public class Dimensions
{
    public decimal? Height { get; set; }
    public decimal? Width { get; set; }
    public decimal? Depth { get; set; }


    public Dimensions(decimal altura, decimal largura, decimal profundidade)
    {
        Validations.ValidateIfLessThan(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
        Validations.ValidateIfLessThan(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
        Validations.ValidateIfLessThan(profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

        Height = altura;
        Width = largura;
        Depth = profundidade;
    }
}
