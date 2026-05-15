using System.Text;

namespace Content.TextWriters;

public class IndentedTextWriter(TextWriter original, int level, int levelSize = 4) : TextWriter
{
	private int _paddingSize = level * levelSize;
	private TextWriter _original = original;

	public override Encoding Encoding => Encoding.UTF8;
	public override void Write(char[]? buffer)
	{
		if (buffer == null)
			return;

		var sb = new StringBuilder();
		var paddingStr = new string(' ', _paddingSize);

		sb.Append(paddingStr);
		for (int i = 0; i < buffer.Length; i++)
		{
			char c = buffer[i];

			sb.Append(c);
			if (c == '\n' && i < buffer.Length - 1)
				sb.Append(paddingStr);
		}

		// Не очень эффективно, но кому какое дело, тут вообще
		// на столько заморачиваться - грех, это же простая практическая
		// (хотя не думаю, что это будет читать какой-нибудь рекрутер)
		var newBuffer = sb.ToString().ToCharArray();

		_original.Write(newBuffer);
	}
}
