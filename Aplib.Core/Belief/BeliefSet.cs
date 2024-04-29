using System;
using System.Linq;

namespace Aplib.Core.Belief
{
    /// <summary>
    /// The <see cref="BeliefSet"/> class can be inherited to define a set of beliefs for an agent.
    /// All <i>public fields</i> of type <see cref="IBelief"/> that are defined in the inheriting class
    /// are automatically updated when calling <see cref="UpdateBeliefs"/>.
    /// </summary>
    public abstract class BeliefSet : IBeliefSet
    {
        /// <summary>
        /// An array storing all <i>public fields</i> of type <see cref="IBelief"/> that are defined in the inheriting class.
        /// </summary>
        private readonly IBelief[] _beliefs;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeliefSet"/> class, 
        /// and stores all <i>public fields</i> of type <see cref="IBelief"/> (that have been defined in the inheriting class) in an array.
        /// All public <see cref="IBelief"/> fields are then automatically updated when calling <see cref="UpdateBeliefs"/>.
        /// </summary>
        protected BeliefSet()
        {
            _beliefs = GetType()
                .GetFields()
                .Where(field => typeof(IBelief).IsAssignableFrom(field.FieldType))
                .Select(field => (IBelief)field.GetValue(this))
                .ToArray();

            Console.WriteLine("Hello it is me, thingamajig number 2, I am way cooler than my father, the thingamajig, because I can print cool ascii art! Look:");
            Console.WriteLine("  _______ _        _______           _______         ");
            Console.WriteLine(" |__   __(_)      |__   __|         |__   __|        ");
            Console.WriteLine("    | |   _  ___     | | __ _  ___     | | ___   ___ ");
            Console.WriteLine("    | |  | |/ __|    | |/ _` |/ __|    | |/ _ \\ / _ ");
            Console.WriteLine("    | |  | | (__     | | (_| | (__     | | (_) |  __/");
            
            Console.WriteLine("Editor's note: thingamajig is not so cool after all, didn't even finish the ascii art. Shame on you, thingamajig 2!");
        }

        /// <summary>
        /// Updates all objects of type <see cref="IBelief"/> that are defined as <i>public fields</i> in the inheriting class.
        /// </summary>
        public void UpdateBeliefs()
        {
            foreach (IBelief belief in _beliefs) belief.UpdateBelief();
        }
    }
}
