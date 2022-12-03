<Query Kind="Program" />

void Main()
{
	var input = CoA2022.GetInputLines(1);
	One(input);
	Two(input);
	
	
}

void Two(string[] input)
{
	var calories = new List<int>();
	var currentCal = 0;
	foreach (var line in input)
	{
		if (!string.IsNullOrWhiteSpace(line))
			currentCal += int.Parse(line);
		else
		{
			calories.Add(currentCal);
			currentCal = 0;
		}
	}
	calories.Sort();
	calories.Reverse();
	calories.Take(3).Sum().Dump();
}

void One(string[] input)
{
	var maxCal = 0;
	var currentCal = 0;
	foreach (var line in input)
	{
		if(!string.IsNullOrWhiteSpace(line))
			currentCal += int.Parse(line);
		else
		{
			if(currentCal > maxCal)
				maxCal = currentCal;
			currentCal = 0;
		}		
	}
	maxCal.Dump();
}