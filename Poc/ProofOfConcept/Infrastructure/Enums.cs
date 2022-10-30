namespace Montreal.Bot.Poc.Infrastructure;

public enum MakerState
{
    Initial, Base,
    FragmentCreation, ButtonCreation, StepCreation, StageCreation, RouteCreation
}

public enum PersonState { Initializing, Starting, Viewing, Polling, DataInput }

public enum Trigger { Text, Command, Media, Pointer, PollAnswer }

//------------------------------------

[Flags]
public enum ContentType { None = 0, Step = 1, Stage = 2, Route = 4, All = 7 }

public enum StageType { Regular, Welcome, RouteList, Final }

public enum SpotType { None, Label, Address, Number }

public enum FragmentType { Text, Media, Location, Timer, Poll }

public enum MediaType { Photo, Video, VideoNote, Sound, Sticker }

public enum SoundType { Audio, Voice }

public enum ButtonType { InlinePause, InlineShare, InlineNotification, InlineLink, InlineReplace, InlineTransition, KeyboardTransition }
//inlineNotification

//------------------------------------

[Flags]
public enum Condition { }