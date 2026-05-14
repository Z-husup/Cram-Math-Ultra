using CramMathUltra.Application.Models;

namespace CramMathUltra.Presentation.Screens.Modes;

public class TableRenderer
{
    public string Render(GameState state)
    {
        int size = state.TableSize;

        var lines = new List<string>();

        for (int r = 0; r < size; r++)
        {
            var row = "";

            for (int c = 0; c < size; c++)
            {
                var value = (r + 1) * (c + 1);

                string cell;

                if (state.TableSolved[r, c])
                    cell = value.ToString().PadLeft(3);
                else if (r == state.Row && c == state.Col)
                    cell = " ? ".PadLeft(3);
                else
                    cell = " . ".PadLeft(3);

                row += cell + " ";
            }

            lines.Add(row);
        }

        return $@"
TABLE FILL ({size}x{size})

{state.CurrentQuestion}

{string.Join("\n", lines)}

Correct: {state.Correct}
Wrong:   {state.Wrong}

Answer:
";
    }
}