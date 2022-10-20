namespace Montreal.Bot.Poc.Infrastructure;

public enum MakerState
{
    Initial, Base,
    FragmentCreation, ButtonCreation, StepCreation, StageCreation, RouteCreation
}

public enum PersonState { Initial, Start, Finish, Preparing, Demonstration, Viewing, Polling, DataInput }

public enum Trigger { Text, Command, Media, Pointer, PollAnswer }

//------------------------------------

[Flags]
public enum ContentType { None = 0, Step = 1, Stage = 2, Route = 4, All = 7 }

public enum MediaType { Photo, Video, VideoNote, Voice, Audio, Sticker }

public enum FragmentType { Text, Media, Location, Timer, Poll }

public enum StageType { Regular, Start, Final }

public enum ButtonType { InlineLink, InlineTransition, KeyboardTransition }

public enum SoundType { Sound, Voice }

//------------------------------------

[Flags]
public enum Condition { }