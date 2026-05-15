namespace Content.Works;

internal class Problem3 : BaseProblem
{
	public override string Number => "3";
	protected override string RawDescription => @"
		Дан одномерный целочисленный массив А, состоящий из N
		элементов, N — заданное натуральное число. Составить
		программу нахождения числа нечетных элементов, имеющих
		нечетные индексы.
	";

	public override void Execute()
	{
		int size = InputNum<int>(
			"Введите размер массива",
			validation: PreparedValidations.OnlyPositiveIntsValidation
		);

		int[] nums;
		{
			int amplitude = InputNum<int>(
				"Введите амплитуду для генерации (макс. отколонение от нуля) для генерации"
			);
			nums = CreateRandomArray(size, -amplitude, amplitude);
		}

		int count = 0;
		for (int i = 0; i < nums.Length; i++)
			if (i % 2 == 1 && Math.Abs(nums[i]) % 2 == 1) count++;

		Console.WriteLine($"Кол-во: {count}");
	}
}
