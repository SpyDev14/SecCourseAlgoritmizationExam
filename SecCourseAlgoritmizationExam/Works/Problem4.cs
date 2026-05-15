using System.Collections.Immutable;

namespace Content.Works;

internal class Problem4 : BaseProblem
{
	public override string Number => "4";
	protected override string RawDescription => @"
		Три группы студентов, в каждой из которых 20 человек,
		в сессию сдавали по 3 экзамена. Сведения об оценках
		каждой группы хранятся в двумерных массивах. Определить
		худшую по средней оценке группу.
	";

	public override void Execute()
	{
		const int EXAMS_COUNT = 3;
		const int STUDENTS_COUNT = 20;

		ImmutableList<int[,]> data = new List<int[,]>
		{
			// ..., ..., мин. оценка, макс. оценка + 1
			CreateRandom2DMatrix(STUDENTS_COUNT, EXAMS_COUNT, 2, 5+1),
			CreateRandom2DMatrix(STUDENTS_COUNT, EXAMS_COUNT, 2, 5+1),
			CreateRandom2DMatrix(STUDENTS_COUNT, EXAMS_COUNT, 2, 5+1),
		}.ToImmutableList();


		float[] averages = new float[data.Count];
		for (int groupIdx = 0; groupIdx < data.Count; groupIdx++)
		{
			int[,] groupData = data[groupIdx];
			// Чтобы не делать отдельный цикл для вывода засунул сюда
			PrintMatrix(groupData);

			int sum = 0;
			int count = 0;
			for (int student = 0; student < groupData.GetLength(0); student++)
				for (int exam = 0; exam < groupData.GetLength(1); exam++)
				{
					sum += groupData[student, exam];
					count++;
				}

			averages[groupIdx] = (float)sum / count;
		}

		int worstGroupIdx = 0;
		float minAverage = averages[0];
		for (int i = 1; i < averages.Length; i++)
		{
			float avg = averages[i];
			Console.WriteLine($"Ср. балл группы {i}: {avg}");
			if (avg < minAverage)
			{
				minAverage = avg;
				worstGroupIdx = i;
			}
		}

		Console.WriteLine($"Худшая группа: {worstGroupIdx} (ср. балл {minAverage})");
	}
}
