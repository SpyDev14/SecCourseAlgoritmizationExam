using System.Collections;

namespace Content.Works;

internal class Problem2 : BaseProblem
{
	public override string Number => "2";
	protected override string RawDescription => @"
		Вводить в переменную х последовательно 25 чисел х.
		Найти сумму тех чисел, которые больше заданного М.
		Если таких чисел нет, то выдать сообщение.
		М вводится с клавиатуры.
	";

	public override void Execute()
	{
		const int SIZE = 25;
		bool manualInput = InputBool($"Ввести все значения ({SIZE} чисел) вручную?");

		int[] numbers;
		if (manualInput)
		{
			numbers = new int[SIZE];
			for (int i = 0; i < numbers.Length; i++)
				numbers[i] = InputNum<int>($"Введите целое число (осталось {numbers.Length - i})");
		}
		else
		{
			int amplitude = InputNum<int>(
				"Введите амплитуду для генерации (макс. отколонение от нуля) для генерации"
			);
			numbers = CreateRandomArray(SIZE, -amplitude, amplitude);
			Console.WriteLine($"numbers = {numbers.ReprEnumerable()}\n");
		}
		int m = InputNum<int>("Введите M");

		int summ = 0;
		// M может быть = -1, и мы встретим 0.
		// Сумма будет 0, но мы встретили число больше.
		bool seen = false;
		foreach (int num in numbers) if (num > m)
		{
			summ += num;
			seen = true;
		}

		if (seen) Console.WriteLine($"Сумма чисел больших, чем {m} равна: {summ}");
		else Console.WriteLine($"Чисел больше {m} нет в переданном массиве.");
	}
}
