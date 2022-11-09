using Montreal.Bot.Poc.Infrastructure.Behaviours;

namespace Montreal.Bot.Poc.Tests;

public class PersonBehviourTests
{
    [Fact]
    public void Test1()
    {

    }
}

// var stage = new Stage
// {
//     Id = 1,
//     Name = "Init",
//     Type = StageType.Start,
// };
// var stepOrder = new List<StepInStage>()
//         {
//             new()
//             {
//                 Id = 10,
//                 AttachedStage = stage,
//                 Order = 2,
//                 Payload = new()
//                 {
//                     Fragments = new()
//                     {
//                         new Fragment()
//                         {
//                             Type = FragmentType.Text,
//                             Text = "Текст 2"
//                         }
//                     }
//                 }
//             },
//             new()
//             {
//                 Id = 10,
//                 AttachedStage = stage,
//                 Order = 1,
//                 Payload = new()
//                 {
//                     Fragments = new()
//                     {
//                         new Fragment()
//                         {
//                             Type = FragmentType.Text,
//                             Text = "Текст 1"
//                         }
//                     }
//                 }
//             }
//         };
// stage.Steps = stepOrder;