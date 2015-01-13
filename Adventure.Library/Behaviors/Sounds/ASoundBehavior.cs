
namespace Adventure.Library.Behaviors.Sounds
{
    public abstract class ASoundBehavior
    {
        public abstract string Execute();
    }

    public class Cry : ASoundBehavior
    {
        public override string Execute()
        {
            return "Mouhaaaaaaaaa agaggaga  !!!!";
        }
    }

    public class Gallop : ASoundBehavior
    {
        public override string Execute()
        {
            return "Yaaahahahaaa, Gallop !! Gallop !!";
        }
    }
   
    public class PrincessSpeak : ASoundBehavior
    {
        public override string Execute()
        {
            return "Heeeeeeelp !!!";
        }
    }

    public class Speak : ASoundBehavior
    {
        public override string Execute()
        {
            return "Hey, i can speak";
        }
    }
}
