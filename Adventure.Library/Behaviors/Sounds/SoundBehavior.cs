
namespace Adventure.Library.Behaviors.Sounds
{
    public abstract class ASoundBehavior
    {
        public abstract string Execute();
    }

    public partial class Cry : ASoundBehavior
    {
        public override string Execute()
        {
            return "Mouhaaaaaaaaa agaggaga  !!!!";
        }
    }

    public partial class Gallop : ASoundBehavior
    {
        public override string Execute()
        {
            return "Yaaahahahaaa, Gallop !! Gallop !!";
        }
    }

    public partial class PrincessSpeak : ASoundBehavior
    {
        public override string Execute()
        {
            return "Heeeeeeelp !!!";
        }
    }

    public partial class KingSpeak : ASoundBehavior
    {
        public override string Execute()
        {
            return "Apporter moi à manger !!!";
        }
    }

    public partial class Speak : ASoundBehavior
    {
        public override string Execute()
        {
            return "Hey, i can speak";
        }
    }
}
