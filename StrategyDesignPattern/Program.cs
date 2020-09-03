using System;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LearningMethod learningMethod = new LearningMethod();

            Console.WriteLine("What subject would you like to learn?");
            var subject = Console.ReadLine();
            learningMethod.SetSubject(subject);

            Console.WriteLine("What learning strategy would you like to use (1-3)?");
            int input = int.Parse(Console.ReadKey().KeyChar.ToString());

            switch (input)
            {
                case 1:
                    learningMethod.SetLearningStrategy(new Visual());
                    learningMethod.Learn();
                    break;

                case 2:
                    learningMethod.SetLearningStrategy(new Reading());
                    learningMethod.Learn();
                    break;

                case 3:
                    learningMethod.SetLearningStrategy(new Listenig());
                    learningMethod.Learn();
                    break;

                default:
                    Console.WriteLine("Invalid Selection!");
                    break;
            }
            Console.ReadKey();
        }

    }
        abstract class LearnStrategy
    {
            public abstract void Learn(string subject);
        }
    /// <summary>
    /// A Concrete Strategy class
    /// </summary>
    class Visual : LearnStrategy
    {
        public override void Learn(string subject)
        {
            Console.WriteLine("\nI would like to learn " + subject + " by visualisation.");
        }
    }

    /// <summary>
    /// A Concrete Strategy class
    /// </summary>
    class Reading : LearnStrategy
    {
        public override void Learn(string subject)
        {
            Console.WriteLine("\nI would like to learn " + subject + " by reading.");
        }
    }

    /// <summary>
    /// A Concrete Strategy class
    /// </summary>
    class Listenig : LearnStrategy
    {
        public override void Learn(string subject)
        {
            Console.WriteLine("\nI would like to learn " + subject + " by listening.");
        }
    }

    /// <summary>
    /// The Context class, which maintains a reference to the chosen Strategy.
    /// </summary>
    class LearningMethod
    {
        private string Subject;
        private LearnStrategy _learnStrategy;
     

        public void SetLearningStrategy(LearnStrategy learnStrategy)
        {
            this._learnStrategy = learnStrategy;
        }

        public void SetSubject(string name)
        {
            Subject = name;
        }

        public void Learn()
        {
            _learnStrategy.Learn(Subject);
            Console.WriteLine();
        }
    }
}
