using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class SeedData
{
    public static Stage ChooseStage = default!;

    public static void DoWork()
    {
        using var context = new BotDbContext();
        bool wasAction = false;

        if (!context.Steps.Any())
        {
            context.Steps.AddRange(CreateStep_Choose(out var routeList));
            context.Stages.Add(routeList);
            ChooseStage = routeList;

            context.Steps.AddRange(CreateStage_Start(out var startStage));
            context.Stages.Add(startStage);

            wasAction = true;
        }

        if (!context.Routes.Any())
        {
            context.Routes.Add(BTU.CreateRoute_BTU());
            context.Routes.Add(MUR.CreateRoute_MMUR());
            context.Routes.Add(EUR.CreateRoute_EUR());
            wasAction = true;
        }

        if (!context.Stages.Any())
        {
            // context.Stages.Add(CreateStage_Start());
            // wasAction = true;
        }


        if (wasAction)
        {
            context.SaveChanges();
            var unbinded = context.Targets.Where(t => t.IsBinded == false);
            foreach (var target in unbinded)
            {
                var pointer = new ContentPointer();

                foreach (var args in target!.Name!.Trim().Split(':'))
                {
                    Console.WriteLine($"Обработка {args}");
                    var part = args.Trim().Split('=');
                    if (part.Count() == 2)
                    {
                        var type = part[0];
                        var name = part[1];

                        switch (type)
                        {
                            case "route":
                                var route = context.Routes.Where(r => r.Name == name).SingleOrDefault();
                                //pointer.RouteId = route!.Id;
                                pointer.Route = route;
                                pointer.Type = pointer.Type | ContentType.Route;
                                context.Pointers.Update(pointer);
                                target.Pointer = pointer;
                                break;
                            case "stage":
                                var stage = context.Stages.Where(r => r.Name == name).SingleOrDefault();
                                //pointer.StageId = stage!.Id;
                                pointer.Stage = stage;
                                pointer.Type = pointer.Type | ContentType.Stage;
                                context.Pointers.Update(pointer);
                                target.Pointer = pointer;
                                break;
                            case "step":
                                var step = context.Steps.Where(r => r.Name == name).SingleOrDefault();
                                //pointer.StepId = step!.Id;
                                pointer.Step = step;
                                pointer.Type = pointer.Type | ContentType.Step;
                                context.Pointers.Update(pointer);
                                target.Pointer = pointer;
                                break;
                        }
                    }
                }
                target.IsBinded = true;
                //target.Name = null;
                context.Pointers.Add(pointer);
                context.Targets.Update(target);
                context.SaveChanges();
            }
        }
    }

    public static Step[] CreateStep_Choose(out Stage chooseStage)
    {
        var step0 = new Step()
        {
            Name = "choose_0",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOy2NXEKEdivM2CHICtQS1rXpwZfHiAALMwzEbhDm4So1m_ix_A0qYAQADAgADeQADKgQ"}, Caption ="🗓 <b>Выбери день</b> с хорошей погодой\n\n📱 <b>Заряди телефон</b> и возьми наушники\n\n🌨 Сейчас лучше <b>одеться потеплее</b>, мы всё-таки в Сибири\n\n📍 Отправляйся на <b>точку старта</b>, она будет в описании" }},
                Buttons = new() {
                    new() {Type = ButtonType.InlineReplace, Label ="По ту сторону Европейского квартала", Line = 1, Target = new(){Name = "step=choose_1"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Большой университет Томска", Line = 2, Target = new(){Name = "step=choose_2"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Муралы. Граффити. Заплатки.", Line= 3, Target = new(){Name = "step=choose_3" },
                }}}}
        };

        chooseStage = new Stage
        {
            Name = "routeList",
            Type = StageType.RouteList,
        };
        var order = new StepInStage() { AttachedStage = chooseStage, Payload = step0, Order = 1, Delay = 0 };
        chooseStage.Steps = new() { order };

        // по ту сторону
        var step1 = new Step()
        {
            Name = "choose_1",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOz2NXGgrm8D4s5Fyz6XEeKGPpOAS5AALTwzEbhDm4SgcoYc-8GEAXAQADAgADeQADKgQ"},Caption ="<b>По ту сторону Европейского квартала</b>\n\nЭто прогулка, во время которой мы увидим центр Томска с неожиданной стороны. Узнаем, где во дворах исторических корпусов Томского политеха профессора сажали картошку, а студенты играли в снежки. Посмотрим на стену, которой больше 110 лет, и на которой кто-то настойчиво пишет посвящения культовой группе Pink Floyd. Услышим исторические факты, малоизвестные легенды и мифы.\n\n<i>И даже немного поговорим про НЛО.</i>"}},
                Buttons = new() {
                    new() {Type = ButtonType.InlineReplace, Label ="Точка старта", Target = new(){Name = "step=choose_4"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };
        // большой универ
        var step2 = new Step()
        {
            Name = "choose_2",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOzWNXGeT5YGqExFLWtDaQJ0jloaYeAALSwzEbhDm4SvfViZaNQdKWAQADAgADeQADKgQ"},Caption="<b>«Большой университет Томска».</b>\n\nТомск – это город вузов.\nНа этом маршруте я покажу тебе первое в Томске студенческое общежитие, расскажу, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и что для этого нужно сделать.\n\nМы прогуляемся по университетским корпусам, библиотекам и главным студенческим улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними." }},
                Buttons = new() {
                    new() {Type = ButtonType.InlineReplace, Label ="Точка старта", Target = new(){Name = "step=choose_5"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };
        // муралы
        var step3 = new Step()
        {
            Name = "choose_3",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIO0WNXGiY4wIhFq1Es7FheEvJfiqYZAAKywzEbhDm4Sqp26tGNxR_eAQADAgADeQADKgQ"}, Caption = "<b>«Муралы. Граффити. Заплатки.»</b>\n\nЗдесь я покажу тебе, в каких местах Томска можно найти уличное искусство. От огромной надписи на стене библиотеки, до крошечных арт-заплаток, от нелегальных муралов, до наследия фестивалей.\n\nХочу, чтобы ты полюбил это новое искусство в старинном городе также, как и я." }},
                Buttons = new() {
                    new() {Type = ButtonType.InlineReplace, Label ="Точка старта", Target = new(){Name = "step=choose_6"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };

        // по ту сторону 8888
        var step4 = new Step()
        {
            Name = "choose_4",
            Fragments = new() { new() { Type = FragmentType.Location,
                Location = new(){
                    Latitude = 56.463957,
                    Longitude = 84.957005,
                    Address = "ул. Усова, 9Б ",
                    Label ="экспресс-кофейня «Территория Кофе»",
                },
                Buttons = new() {
                    new() {Type = ButtonType.InlineTransition, Label ="Идём гулять", Target = new(){Name = "route=eur"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };
        // большой универ88888
        var step5 = new Step()
        {
            Name = "choose_5",
            Fragments = new() { new() { Type = FragmentType.Location,
                Location = new(){
                    Latitude = 56.465376,
                    Longitude = 84.950432,
                    Address = "пр.Ленина, 30; возле главного входа",
                    Label ="Главный корпус Томского политического Университета ",
                },
                Buttons = new() {
                    new() {Type = ButtonType.InlineTransition, Label ="Идём гулять", Target = new(){Name = "route=btu"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };
        // муралы8888
        var step6 = new Step()
        {
            Name = "choose_6",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIO02NXHgrwnSKERaxsyQeY1HdAAAEtTQAC1sMxG4Q5uErsOZhvu3Ya-gEAAwIAA3kAAyoE"}, Caption ="Двор здания ул. Усова, 4а / ул. Советская, 73 с1"}},
                Buttons = new() {
                    new() {Type = ButtonType.InlineTransition, Label ="Идём гулять", Target = new(){Name = "route=mur"}},
                    new() {Type = ButtonType.InlineReplace, Label ="Назад", Target = new(){Name = "step=choose_0"}},
                }}}
        };


        return new Step[] { step0, step1, step2, step3, step4, step5, step6 };
    }

    public static Step[] CreateStage_Start(out Stage startStage)
    {
        var step1_1 = new Step()
        {
            Name = "start_1_1",
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIPF2NXRefh4lurEgrgR2aGPciAsVeqAAKcFAACitq4Ut5WDtOtkPQaKgQ"}}}},
        }}
        };

        var step1_2 = new Step()
        {
            Name = "start_1_2",
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sticker, Sticker = new(){FileId="CAACAgIAAxkBAAIPFWNXRTPXEnT6v7i9irqV52-JCuI6AAKMHwACndxhSsWJ5N_7-0cTKgQ"}}},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Маршруты по Томску", Target = new(){Name = "step=start_3"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="О проекте", Target = new(){Name = "step=start_2"}},
                }}}
        };

        var step1_3 = new Step()
        {
            Name = "start_1_3",
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIPGWNXRhQNkfLMNJyu1wqX_5YsbQnkAAKjFAACitq4UppZonQM4nTxKgQ"}}}},
        }}
        };

        startStage = new Stage
        {
            Name = "welcomeStage",
            Type = StageType.Welcome,
        };
        var order = new List<StepInStage>
        {
            new StepInStage() { AttachedStage = startStage, Payload = step1_1, Order = 2, Delay = 0 },
            new StepInStage() { AttachedStage = startStage, Payload = step1_2, Order = 1, Delay = 0 },
            new StepInStage() { AttachedStage = startStage, Payload = step1_3, Order = 3, Delay = 0 },
        };
        startStage.Steps = order;

        var step2 = new Step()
        {
            Name = "start_2",
            Fragments = new() { new() { Type = FragmentType.Text,
                Text = "<b>О проекте</b>\nВ процессе заполнения",
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Маршруты по Томску", Target = new(){Name = "step=start_3"}},
                }}}
        };

        var step3 = new Step()
        {
            Name = "start_3",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIPG2NXRjzGrIqWAv2R3FDO6yIUW6GKAALMwzEbhDm4So1m_ix_A0qYAQADAgADeQADKgQ"}, Caption ="🗓 <b>Выбери день</b> с хорошей погодой\n\n📱 <b>Заряди телефон</b> и возьми наушники\n\n🌨 Сейчас лучше <b>одеться потеплее</b>, мы всё-таки в Сибири\n\n📍 Отправляйся на <b>точку старта</b>, она будет в описании"}},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="По ту сторону Европейского квартала", Line = 1, Target = new(){Name = "step=start_4"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Большой университет Томска", Line = 2, Target = new(){Name = "step=start_6"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Муралы. Граффити. Заплатки.", Line= 3, Target = new(){Name = "step=start_8" },
                }}}}
        };

        var step4 = new Step()
        {
            Name = "start_4",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIPHWNXRlqPcuoyR-rWREpR17-AVI72AALTwzEbhDm4SgcoYc-8GEAXAQADAgADeQADKgQ"},Caption ="<b>По ту сторону Европейского квартала</b>\n\nЭто прогулка, во время которой мы увидим центр Томска с неожиданной стороны. Узнаем, где во дворах исторических корпусов Томского политеха профессора сажали картошку, а студенты играли в снежки. Посмотрим на стену, которой больше 110 лет, и на которой кто-то настойчиво пишет посвящения культовой группе Pink Floyd. Услышим исторические факты, малоизвестные легенды и мифы.\n\n<i>И даже немного поговорим про НЛО.</i>" }},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Точка старта", Target = new(){Name = "step=start_5"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };

        var step6 = new Step()
        {
            Name = "start_6",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIPH2NXRmpyntiC_ngHwvnjZcndBn0XAALSwzEbhDm4SvfViZaNQdKWAQADAgADeQADKgQ"},Caption="<b>«Большой университет Томска».</b>\n\nТомск – это город вузов.\nНа этом маршруте я покажу тебе первое в Томске студенческое общежитие, расскажу, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и что для этого нужно сделать.\n\nМы прогуляемся по университетским корпусам, библиотекам и главным студенческим улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними."}},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Точка старта", Target = new(){Name = "step=start_9"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };

        var step8 = new Step()
        {
            Name = "start_8",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIPI2NXRowfRoVkbROVVHt5L8maTUHaAAKywzEbhDm4Sqp26tGNxR_eAQADAgADeQADKgQ"}, Caption = "<b>«Муралы. Граффити. Заплатки.»</b>\n\nЗдесь я покажу тебе, в каких местах Томска можно найти уличное искусство. От огромной надписи на стене библиотеки, до крошечных арт-заплаток, от нелегальных муралов, до наследия фестивалей.\n\nХочу, чтобы ты полюбил это новое искусство в старинном городе также, как и я."}},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Точка старта", Target = new(){Name = "step=start_7"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };


        var step5 = new Step()
        {
            Name = "start_5",
            Fragments = new() { new() { Type = FragmentType.Location,
                Location = new(){
                    Latitude = 56.463957,
                    Longitude = 84.957005,
                    Address = "ул. Усова, 9Б ",
                    Label ="экспресс-кофейня «Территория Кофе»",
                },
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Идём гулять", Target = new(){Name = "route=eur"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };

        var step7 = new Step()
        {
            Name = "start_7",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIPJWNXRqUxrLzsQo_TxQABiQpS3eVv1QAC1sMxG4Q5uErsOZhvu3Ya-gEAAwIAA3kAAyoE"}, Caption ="Двор здания ул. Усова, 4а / ул. Советская, 73 с1"}},
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Идём гулять", Target = new(){Name = "route=mur"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };

        var step9 = new Step()
        {
            Name = "start_9",
            Fragments = new() { new() { Type = FragmentType.Location,
                Location = new(){
                    Latitude = 56.465376,
                    Longitude = 84.950432,
                    Address = "пр.Ленина, 30; возле главного входа",
                    Label ="Главный корпус Томского политического Университета ",
                },
                Buttons = new() {
                    new() {Type = ButtonType.KeyboardTransition, Label ="Идём гулять", Target = new(){Name = "route=btu"}},
                    new() {Type = ButtonType.KeyboardTransition, Label ="Назад", Target = new(){Name = "step=start_3"}},
                }}}
        };


        return new Step[] { step2, step3, step4, step5, step6, step7, step8, step9 };
    }
}