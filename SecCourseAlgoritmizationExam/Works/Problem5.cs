using System.Text.RegularExpressions;

namespace Content.Works;

internal class Problem5 : BaseProblem
{
	public override string Number => "5";
	protected override string RawDescription => @"
		Дана строка, в которой содержится осмысленное
		текстовое сообщение. Слова сообщения разделяются
		пробелами и знаками препинания. Подсчитать сколько
		раз заданное слово встречается в сообщении.
	";

	public override void Execute()
	{
		// Край_слова(буквы)Край_слова
		const string REGEX = @"\b\w+\b";

		string text = InputStr("Введите осмысленный текст").ToLower();
		string targetWord = InputStr("Введите слово для поиска").ToLower();

		// Сумму можно посчитать и обычным циклом for
		int count = Regex.Matches(text, REGEX)
			.Count(m => m.Value == targetWord);

		Console.WriteLine($"Слово \"{targetWord}\" встречается: {count} раз");
	}
}
