
namespace Adventure.Library.Behaviors.Fighting
{
    public abstract class AFightBehavior
    {
        public abstract string Execute();
    }

    public class FightOnHorse : AFightBehavior
    {
        public override string Execute()
        {
            return "I'm crushing and slice !!!";
        }
    }

    public class FightWithAx : AFightBehavior
    {
        public override string Execute()
        {
            return "I'm using my Ax to slice you !!!";
        }
    }

    public class FightWithBow : AFightBehavior
    {
        public override string Execute()
        {
            return "I'm pierce you with my bow !!";
        }
    }
}
