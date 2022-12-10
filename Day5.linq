<Query Kind="Program" />

Stack<string>[] _stacks;
void Main()
{
	One(9, 8);


}

void One(int numberOfStacks, int initialMaxHeight)
{
	var stackInput = AoC2022.GetInputLines(5).Take(initialMaxHeight);
	var steps = from l in AoC2022.GetInputLines(5).Skip(initialMaxHeight + 2) let line = l + " "
				select new Step
				{
					Amount = int.Parse(line.Substring(5, 2).Trim()),
					From = int.Parse(line.Substring(12, 2).Trim()),
					To = int.Parse(line.Substring(17, 2).Trim())
				};

	_stacks = GetStacks(numberOfStacks, initialMaxHeight, stackInput.Reverse().ToArray());

	foreach (var step in steps)
		DoStep2(step);

	_stacks.Select(s => s.Peek()).Dump();
}

void DoStep(Step step)
{
	for (int i = 0; i < step.Amount; i++)
	{
		var cargoToMove = _stacks[step.From - 1].Pop();
		_stacks[step.To - 1].Push(cargoToMove);
	}
}

void DoStep2(Step step)
{
	var tempStack = new Stack<string>();
	for (int i = 0; i < step.Amount; i++)
	{
		var cargoToMove = _stacks[step.From - 1].Pop();
		tempStack.Push(cargoToMove);
	}
	for (int i = 0; i < step.Amount; i++)
	{
		var cargoToMove = tempStack.Pop();
		_stacks[step.To - 1].Push(cargoToMove);
	}
}

Stack<string>[] GetStacks(int numberOfStacks, int initialMaxHeight, string[] input)
{
	var stacks = new Stack<string>[numberOfStacks];
	Enumerable.Range(0, numberOfStacks).ToList().ForEach(i => stacks[i] = new Stack<string>());
	
	//read the stacks bottom up
	for (int i = 0; i < initialMaxHeight; i++)
	{
		var line = input[i];
		var stackToAddTo = 0;
		for (int j = 0; j < line.Length; j += 4)
		{
			var c = line.Substring(j + 1, 1);
			if (!string.IsNullOrWhiteSpace(c))
				stacks[stackToAddTo].Push(c);
			stackToAddTo++;
		}
	}
	return stacks;
}

public class Step
{
	public int Amount { get; set; }
	public int From { get; set; }
	public int To { get; set; }
}