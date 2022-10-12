namespace Montreal.Bot.Poc.Infrastructure;

public enum MakerState
{
    Initial, Base,
    FragmentCreation, ButtonCreation, StepCreation, StageCreation, RouteCreation
}

public enum PersonState
{
    Initial, Start, Step, Stage, Route
}

public enum Trigger
{
    Text, Command, Callback, Fragment, Target
}

//------------------------------------

public enum FragmentType
{
    Text,
    Photo, Video, VideoNote, Voice, Audio, Sticker, Location,
    Timer
}

public enum StageType
{
    Regular, Start, Final
}

public enum ButtonType
{
    Inline, Keyboard,
}


public enum TargetType
{
    Step, Stage, Route
}

[Flags]
public enum Condition
{

}