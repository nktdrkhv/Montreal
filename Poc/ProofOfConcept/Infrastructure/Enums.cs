namespace Montreal.Bot.Poc.Models;

public enum MakerState
{
    Initial,
}

public enum PersonState
{

}

public enum Trigger
{
    Text, Command, Callback, Media
}

//------------------------------------

public enum FragmentType
{
    Photo, Video, VideoNote, Voice, Audio, Sticker, Location, Venue,
    Timer
}

public enum StageType
{
    Regular, Initial, Final
}

public enum ButtonType
{
    Inline, Keyboard,
    InlineLink, KeyboardLink
}


public enum TargetType
{
    Step, Stage, Route
}

[Flags]
public enum Condition
{

}