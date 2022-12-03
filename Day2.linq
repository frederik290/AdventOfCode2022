<Query Kind="Program" />

void Main()
{
	var input = AoC2022.GetInputLines(2);
	One(input);
	
	
}

void One(string[] input)
{
	var totalScore = 0;
	foreach (var line in input)
		totalScore += outcomes[line];
	totalScore.Dump();
}


Dictionary<string, int> outcomes = new Dictionary<string, int>()
{
	{"A X", 4}, // rock, rock 
	{"A Y", 8}, // rock, paper 
	{"A Z", 3}, // rock, scissors 
	
	{"B X", 1}, // paper, rock 
	{"B Y", 5}, // paper, paper
	{"B Z", 9}, // paper, scissors
	
	{"C X", 7}, // scissors, rock 
	{"C Y", 2}, // scissors, paper 
	{"C Z", 6}  // scissors, scissors
};



