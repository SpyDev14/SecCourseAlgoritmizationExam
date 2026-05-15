namespace Content.Works;

internal class Problem1 : BaseProblem
{
	public override string Number => "1";
	protected override string RawDescription => @"
		Ввести два числа. Если они не равны, то заменить каждое
		из них на большее, а если равны, то заменить их нулями.
	";

	public override void Execute()
	{
		int x = InputNum<int>("Введите X");
		int y = InputNum<int>("Введите Y");

		if (x == y)
			(x, y) = (0, 0);
		else if (x > y)
			y = x;
		else
			x = y;

		Console.WriteLine("Результат:");
		Console.WriteLine($"X = {x}");
		Console.WriteLine($"Y = {y}");
	}
}
