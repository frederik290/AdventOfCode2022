<Query Kind="Program" />

void Main()
{
	var input = AoC2022.GetInputLines(4);
	One(input);
	
}

void One(string[] input)
{	
	var coveredRanges = from line in input
						let p = line.Split(new[]{'-', ','})
								.Select(int.Parse).ToArray()
						where p[0] >= p[2] && p[1] <= p[3] ||p[2] >= p[0] && p[3] <= p[1]
						select p;

	coveredRanges.Count().Dump("Pairs with one range covering the other");					
}

