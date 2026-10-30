using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _dailyPrompts = new List<string>()
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "What challenged you today?",
        "What are you grateful for today?",
        "What would you do differently tomorrow?"
    };

    public List<string> _persuasivePrompts = new List<string>()
    {
        "What is an opinion you strongly believe in, and why?",
        "What is a change you would make in your community?",
        "What is a cause you think more people should support?",
        "What is a habit you would encourage others to develop?",
        "Should college education be free? Explain your position."
    };

    public List<string> _expositoryPrompts = new List<string>()
    {
        "Explain something new you learned recently.",
        "How does a skill you use every day work?",
        "What makes a good study routine?",
        "Explain a topic you wish more people understood.",
        "What steps would you take to reach a personal goal?"
    };

    public List<string> _narrativePrompts = new List<string>()
    {
        "Describe a memorable event from your childhood.",
        "Tell the story of a time you overcame a challenge.",
        "Describe a trip that changed your perspective.",
        "Tell the story of a surprising encounter.",
        "Describe a moment when you felt proud of yourself."
    };

    public List<string> _literaryPrompts = new List<string>()
    {
        "What book or story has influenced your thinking, and why?",
        "Which fictional character do you relate to most?",
        "Describe a lesson you learned from a story.",
        "What would you change about the ending of a book you read?",
        "How did a character change during a story you enjoyed?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt(List<string> prompts)
    {
        int index = _random.Next(prompts.Count);

        return prompts[index];
    }

    public string GetSurprisePrompt()
    {
        List<string> allPrompts = new List<string>();

        allPrompts.AddRange(_dailyPrompts);
        allPrompts.AddRange(_persuasivePrompts);
        allPrompts.AddRange(_expositoryPrompts);
        allPrompts.AddRange(_narrativePrompts);
        allPrompts.AddRange(_literaryPrompts);

        return GetRandomPrompt(allPrompts);
    }
}