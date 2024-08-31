namespace TaskManagement.Domain.Enums
{
	public enum ViewLevel
	{
		Public,
		Private,
		SpecificGroup
	}

	public enum Priority
	{
		High = 1,
		Medium = 2,
		Low = 3
	}

	public enum Status
	{
		Open = 1,
		InProgress = 2,
		Hold = 3,
		WaitingForApproval = 4,
		Closed = 5
	}

	public enum SeverityLevel
	{
		Severe = 1,
		High = 2,
		Moderate = 3,
		Low = 4,
		NA = 5
	}
}
