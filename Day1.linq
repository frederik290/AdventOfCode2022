<Query Kind="Program">
  <GACReference>System.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</GACReference>
</Query>

void Main()
{
	var input = AoC2022.GetInputAsSingleLine(1);
	PartOne(input);
	PartTwo(input);
	
}

void PartOne(string input) => GetCaloriesPerElf(input).First()
							  .Dump("Calories carried by max-carrying elf");
							  
void PartTwo(string input) => GetCaloriesPerElf(input).Take(3).Sum()
							  .Dump("Callories carried by top 3 elves");

IEnumerable<int> GetCaloriesPerElf(string input) =>
		from elf in input.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None)
		let calories = elf.Split('\n').Select(int.Parse).Sum()
		orderby calories descending
		select calories;

