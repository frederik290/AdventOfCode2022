<Query Kind="Program" />

void Main()
{
	One();
	Two();
	
}

void One()
{	
	var coveredRanges = from line in AoC2022.GetInputLines(4)
						let p = line.Split(new[]{'-', ','})
								.Select(int.Parse).ToArray()
						where p[0] >= p[2] && p[1] <= p[3] ||p[2] >= p[0] && p[3] <= p[1]
						select p;

	coveredRanges.Count().Dump("Pairs with one range covering the other");	
}

void Two()
{
	var coveredRanges = from line in AoC2022.GetInputLines(4)
						let p = line.Split(new[] { '-', ',' })
								.Select(int.Parse).ToArray()
						let r1 = Enumerable.Range(p[0], p[1]-p[0]+1)
						let r2 = Enumerable.Range(p[2], p[3]-p[2]+1)
						where r1.Intersect(r2).Any()
						select p;

	coveredRanges.Count().Dump("Overlapping pairs");
	
}