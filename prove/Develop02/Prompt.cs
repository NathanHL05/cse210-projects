public class Prompt
{
    public List<string> _prompts = new List<string>()
        {
        "Who was the most interesting person I interacted with today?",
        "How did I see the hand of the Lord in my life today?",
        "What's one thing that went well today?",
        "What's something you're looking forward to this week?",
        "What made you smile recently?",
        "What's one small thing you want to improve tomorrow?",
        "What's a place where you feel calm, and why?",
        "What's a habit you'd like to build?",
        "What's something you're grateful for right now?",
        "What's a challenge you handled better than expected?",
        "What's a song, movie, or book you've enjoyed lately and why?",
        "What's a thought that keeps returning to you?",
        "What's something you wish you had more time for?",
        "What's a recent moment you're proud of?",
        "What's something you want to learn?",
        "What's a value that matters to you?",
        "What's a memory that makes you feel warm inside?",
        "What's something you want to let go of?",
        "What's a dream or goal that feels exciting?",
        "What's a compliment you've received that stuck with you?",
        "What's something you want to say 'yes' to more often?",
        "What's something you want to say 'no' to more often?"
        };

    public string randomPrompt()
    {
        int length = _prompts.Count;
        Random random = new Random();
        return _prompts[random.Next(length)];
    }

}