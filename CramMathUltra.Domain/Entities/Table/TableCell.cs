namespace CramMathUltra.Domain.Entities.Table;

public class TableCell
{
    public int Row { get; set; }
    public int Column { get; set; }

    public int CorrectValue { get; set; }

    public int? UserValue { get; set; }
    
    public bool IsPrefilled { get; set; }

    public bool IsSolved =>
        UserValue == CorrectValue;
}