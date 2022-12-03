<Query Kind="Program" />

void Main()
{
	var input = AoC2022.GetInputLines(2);
	One(input);
	Two(input);	
}

void One(string[] input)
{
	var totalScore = 0;
	foreach (var line in input)
		totalScore += outcomes[line];
	totalScore.Dump();
}

void Two(string[] input)
{
	var totalScore = 0;
	foreach (var line in input)
		totalScore += strategies[line];
	totalScore.Dump();
}

static Dictionary<string, int> outcomes = new Dictionary<string, int>()
{
	{ "A X", 4}, // rock, rock 
	{ "A Y", 8}, // rock, paper 
	{ "A Z", 3}, // rock, scissors 
	
	{ "B X", 1}, // paper, rock 
	{ "B Y", 5}, // paper, paper
	{ "B Z", 9}, // paper, scissors
	
	{ "C X", 7}, // scissors, rock 
	{ "C Y", 2}, // scissors, paper 
	{ "C Z", 6}  // scissors, scissors
};


Dictionary<string, int> strategies = new Dictionary<string, int>()
{
	{"A X", outcomes["A Z"]}, // rock, loose 
	{"A Y", outcomes["A X"]}, // rock, draw 
	{"A Z", outcomes["A Y"]}, // rock, win  
	
	{"B X", outcomes["B X"]}, // paper, loose 
	{"B Y", outcomes["B Y"]}, // paper, draw
	{"B Z", outcomes["B Z"]}, // paper, win
	
	{"C X", outcomes["C Y"]}, // scissors, loose 
	{"C Y", outcomes["C Z"]}, // scissors, draw 
	{"C Z", outcomes["C X"]}  // scissors, win 
};




