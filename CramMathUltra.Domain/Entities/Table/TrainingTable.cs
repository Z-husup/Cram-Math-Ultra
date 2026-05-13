using CramMathUltra.Domain.Enums;

namespace CramMathUltra.Domain.Entities.Table;

public class TrainingTable
{
    public int Size { get; set; }

    public OperationType Operation { get; set; }

    public List<TableCell> Cells { get; set; } = [];
}