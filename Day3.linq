<Query Kind="Program" />

void Main()
{
	var input = AoC2022.GetInputLines(3);
	One(input);	
	Two(input);
}

void One(string[] input)
{
	var sum = input.Select(GetCommonItemType)
		 .Select(ItemToPriority)
		 .Sum();
		 
	sum.Dump("Sum of priorities of common item types");
}

void Two(string[] input)
{
	var groupsOfThree = input.Select((line, index) => new { line, index }) 					// select the line and its index
						.GroupBy(obj => obj.index / 3);										// then split into groups of three usin the index
						
	var commonItemsPrThreeBags = groupsOfThree.Select(group => group.ElementAt(0).line		// get the first element of the group
										.Intersect(group.ElementAt(1).line)					// intersect with the second
										.Intersect(group.ElementAt(2).line))				// and the third element 
										.SelectMany(x => x); 								// then flatten the structure as only one item is left 
										
	
	commonItemsPrThreeBags.Select(ItemToPriority)
						  .Sum()
						  .Dump("Total item sum of groups");
	
}

char GetCommonItemType(string rucksack)
{
	var middel = rucksack.Length/2;
	var p1 = rucksack.Substring(0, middel);
	var p2 = rucksack.Substring(middel, middel);
	return p1.Intersect(p2).First();
}

int ItemToPriority (char c) => !char.IsUpper(c)?c-96:c-64+26;


