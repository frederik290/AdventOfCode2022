<Query Kind="Program" />

void Main()
{
	var input = AoC2022.GetInputAsSingleLine(6);
	PartOne(input);
	PartTwo(input);
}

void PartOne(string input) => 
	GetStartOfBlock(input, 4)
	.Dump("Index of first unique 4 char substring");

void PartTwo(string input) =>
	GetStartOfBlock(input, 14)
	.Dump("Index of first unique 14 char substring");


int GetStartOfBlock(string input, int subStringLength) 
{
	var indexesToCheck = Enumerable.Range(subStringLength, input.Length);
	return indexesToCheck.First(i => HasUniqueChars(input.Substring(i-subStringLength, subStringLength)));
}

bool HasUniqueChars(string str) => str.Distinct().Count() == str.Length; 



