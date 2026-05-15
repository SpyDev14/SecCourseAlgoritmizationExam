namespace Content.CommandExceptions;

// Используется как goto: прерывает обработку Execute работы, если был ввод break в InputNum
internal class BreakWorkExecuting : Exception;
internal class ProgrammExit : Exception;