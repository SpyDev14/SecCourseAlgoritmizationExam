namespace Content.Works;

internal abstract class BaseProblem
{
	public abstract string Number { get; }
	protected abstract string RawDescription { get; }
	public string Description => RawDescription.Trim().Replace("\t", "");

	public abstract void Execute();
}
