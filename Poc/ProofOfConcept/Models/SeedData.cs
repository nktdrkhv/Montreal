using System.Text.RegularExpressions;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class SeedData
{
    public static void DoWork()
    {
        using var context = new BotDbContext();
        bool wasAction = false;

        if (!context.Stages.Any())
        {
            context.Stages.Add(CreateStage_Start());
            wasAction = true;
        }

        if (!context.Routes.Any())
        {
            context.Routes.Add(CreateRoute_BTU());
            wasAction = true;
        }

        if (wasAction)
        {
            context.SaveChanges();

            var unbinded = context.Targets.Where(t => t.IsBinded == false);
            foreach (var target in unbinded)
            {
                var pointer = new ContentPointer();
                context.Pointers.Add(pointer);
                context.SaveChanges();
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
                target.Name = null;
                context.Targets.Update(target);
                context.SaveChanges();
            }
        }
    }

    public static Route CreateRoute_BTU()
    {
        var stage1 = CreateStage_BTU_1();
        var stage2 = CreateStage_BTU_2();
        var stage3 = CreateStage_BTU_3();
        var stage4 = CreateStage_BTU_4();
        var stage5 = CreateStage_BTU_5();
        var stage6 = CreateStage_BTU_6();

        var route = new Route()
        {
            Name = "btu",
            Label = "🏛 Большой томский университет",
            Description = "Томск – это город вузов. На этом маршруте я расскажу тебе, где было первое в Томске студенческое общежитие, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и о многом другом. Мы прогуляемся по университетам, библиотекам, корпусам и основным улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними.",
            InitialStage = stage1
        };
        var stages = new List<StageSequence>()
        {
            new() {AttachedRoute = route, From = stage1, To = stage2},
            new() {AttachedRoute = route, From = stage2, To = stage3},
            new() {AttachedRoute = route, From = stage2, To = stage4},
            new() {AttachedRoute = route, From = stage3, To = stage4},
            new() {AttachedRoute = route, From = stage4, To = stage5},
            new() {AttachedRoute = route, From = stage5, To = stage6},
        };
        route.Stages = stages;
        return route;
    }

    public static Stage CreateStage_Start()
    {
        var fragment1_1 = new Fragment() { Type = FragmentType.Text, Text = "Привет! Здорово, что ты зашел сюда! Давай вместе погуляем по моему любимому Томску? Меня зовут Ефим, я студент, учусь в Томском политехе. Мы с друзьями знаем по-настоящему классные и атмосферные места в нашем самом студенческом городе. Я тебе всё расскажу и покажу – просто выбери маршрут, с которого хочешь начать. По дороге поболтаем – больше всего я люблю знакомиться с интересными людьми. Ну, что, куда пойдем?" };
        var step1 = new Step() { Name = "start_1", Label = "Знакомство", Fragments = new() { fragment1_1 } };

        var fragment2_1 = new Fragment() { Type = FragmentType.Text, Text = "У меня для тебя есть готовые маршруты:" };
        var step2 = new Step() { Name = "start_2", Label = "Готовые маршруты", Fragments = new() { fragment2_1 } };

        var fragment3_1 = new Fragment() { Type = FragmentType.Text, Text = "1. «По ту сторону Европейского квартала» – это прогулка, во время которой ты узнаешь центр Томска с неожиданной стороны. Где во дворах исторических корпусов Томского политеха профессора сажали картошку, студенты играли в снежки, а на стене, которой больше 110 лет, кто-то настойчиво пишет посвящения культовой группе Pink Floyd. Исторические факты, малоизвестные легенды и мифы. И даже немного про НЛО." };
        var step3 = new Step() { Name = "start_3", Label = "Описание Европейского квартала", Fragments = new() { fragment3_1 } };

        var fragment4_1 = new Fragment() { Type = FragmentType.Text, Text = "2. «Большой томский университет» – Томск – это город вузов. На этом маршруте я расскажу тебе, где было первое в Томске студенческое общежитие, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и о многом другом. Мы прогуляемся по университетам, библиотекам, корпусам и основным улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними." };
        var step4 = new Step() { Name = "start_4", Label = "Описание Большого томского университета", Fragments = new() { fragment4_1 } };

        var fragment5_1 = new Fragment() { Type = FragmentType.Text, Text = "Я учусь уже на третьем курсе и скоро стану инженером. У меня много друзей — из политеха и других универов. Томск — тусовочный и молодежный. Здесь всегда можно найти хорошую компанию, чтобы сходить на выставку или на концерт, выпить кофе или просто погулять. А еще мне нравится исследовать город и расспрашивать о нем разных умных людей. Иногда такое узнаешь — прям вау! Конечно, хочется поделиться такими открытиями. Так что выбирай, куда пойдем!" };
        var step5 = new Step() { Name = "start_5", Label = "Мне нравится исследовать город", Fragments = new() { fragment5_1 } };

        var buttons6 = new List<Button>()
        {
            new(){ Type = ButtonType.KeyboardTransition, Target = new() { Name = "route=btu"}}
        };
        var fragment6_1 = new Fragment() { Type = FragmentType.Text, Text = "Выбирай маршрут, по которому пойдем гулять!", Buttons = buttons6 };
        var step6 = new Step() { Name = "start_6", Label = "Выбор маршрута", Fragments = new() { fragment6_1 } };

        var stageStart = new Stage() { Name = "start", Type = StageType.Start };

        var order1 = new StepInStage() { AttachedStage = stageStart, Payload = step1, Order = 1, Delay = 1 };
        var order2 = new StepInStage() { AttachedStage = stageStart, Payload = step2, Order = 2, Delay = 1 };
        var order3 = new StepInStage() { AttachedStage = stageStart, Payload = step3, Order = 3, Delay = 1 };
        var order4 = new StepInStage() { AttachedStage = stageStart, Payload = step4, Order = 4, Delay = 1 };
        var order5 = new StepInStage() { AttachedStage = stageStart, Payload = step5, Order = 5, Delay = 1 };
        var order6 = new StepInStage() { AttachedStage = stageStart, Payload = step6, Order = 6, Delay = 1 };

        stageStart.Steps = new() { order1, order2, order3, order4, order5, order6 };

        return stageStart;
    }

    public static Stage CreateStage_BTU_1()
    {
        var fragment7_1 = new Fragment() { Type = FragmentType.Text, Text = "А ты знал, что Томск считается одним из главных студенческих городов России? Между прочим, по количеству студентов Томская область – третья в России после Москвы и Санкт-Петербурга. По сути, Томск – это город-университет. И в 2019 году все вузы и научно-исследовательские институты объединились в мега-проект «Большой университет Томска». Давай-ка прогуляемся по нашему городу-университету! Кстати, по дороге ты можешь встретить местную – белок. Не забудь взять с собой какие-нибудь лакомства – орехи или семечки, чтобы их порадовать." };
        var step7 = new Step() { Name = "btu_1_7", Label = "Томск – город-университет", Fragments = new() { fragment7_1 } };

        var fragment8_1 = new Fragment() { Type = FragmentType.Text, Text = "Давай будем гулять в светлое время суток! Выбери день с хорошей погодой. Возьми с собой наушники и бутылку воды." };
        var step8 = new Step() { Name = "btu_1_8", Label = "Давай гулять", Fragments = new() { fragment8_1 } };

        var fragment9_1 = new Fragment() { Type = FragmentType.Text, Text = "Взгляни на карту – это наш маршрут. Ты можешь передвигаться пешком, а можешь часть маршрута проехать на общественном транспорте. Выбирай сам! (КАРТА)" };
        var step9 = new Step() { Name = "btu_1_9", Label = "Наш маршрут", Fragments = new() { fragment9_1 } };

        var buttons10 = new List<Button>()
        {
            new(){ Type = ButtonType.KeyboardTransition, Label = "⚠️ Хочу другой маршрут", Target = new() { Name = "stage=start:step=start_6"}},
            new(){ Type = ButtonType.KeyboardTransition, Label = "🎯 Давай", Target = new() { Name = "stage=btu_2"}}
        };
        var fragment10_1 = new Fragment() { Type = FragmentType.Text, Text = "Ну что? Идем?", Buttons = buttons10 };
        var step10 = new Step() { Name = "btu_1_10", Fragments = new() { fragment10_1 } };

        var stage1 = new Stage() { Name = "btu_1", Label = "Выбор Большого томского университета", Type = StageType.Regular };

        var order7 = new StepInStage() { AttachedStage = stage1, Payload = step7, Order = 1, Delay = 1 };
        var order8 = new StepInStage() { AttachedStage = stage1, Payload = step8, Order = 2, Delay = 1 };
        var order9 = new StepInStage() { AttachedStage = stage1, Payload = step9, Order = 3, Delay = 1 };
        var order10 = new StepInStage() { AttachedStage = stage1, Payload = step10, Order = 4, Delay = 1 };

        stage1.Steps = new() { order7, order8, order9, order10 };

        return stage1;
    }

    public static Stage CreateStage_BTU_2()
    {
        var fragment11_1 = new Fragment()
        {
            Type = FragmentType.Media,
            Media = new() {
            new() { Id = 1, Photo = new() { FileId = "AgACAgIAAxkBAAICC2NRwpC_uoG9Z7Gl7XyCGU0nk3O1AAL2wTEbbzyQSgY0Wai4TpT5AQADAgADeQADKgQ" }, Caption = "ГК ТПУ" } }
        };
        var step11 = new Step() { Name = "btu_2_11", Fragments = new() { fragment11_1 } };

        var fragment12_1 = new Fragment()
        {
            Type = FragmentType.Text,
            Text = "Начинаем прогулку с места, где был открыт первый за Уралом технический вуз. Это Томский политехнический университет. Адрес Главного корпуса вуза: проспект Ленина, 30. Посмотри, сильно ли здание изменилось за более чем 120 лет? Кстати, в начале ХХ века этот корпус носил название Лекционный потому, что был открыт первым из всех в 1900 году, и именно здесь начались занятия у будущих инженеров."
        };
        var step12 = new Step() { Name = "btu_2_12", Fragments = new() { fragment12_1 } };

        var fragment13_1 = new Fragment()
        {
            Type = FragmentType.Media,
            Media = new() {
            new() { Id = 2, Photo = new() { FileId = "AgACAgIAAxkBAAICDWNRwuOA-V55l8aXt2Rfe19JX9loAAL3wTEbbzyQSj3e2qZqnhlSAQADAgADeQADKgQ" }, Caption = "ГК ТПУ, начало XX века" } }
        };
        var step13 = new Step() { Name = "btu_2_13", Fragments = new() { fragment13_1 } };

        var buttons14_1 = new List<Button>()
        {
            new(){ Type = ButtonType.KeyboardTransition, Label = "💁‍♂️ Да, хочу узнать", Target = new() { Name = "stage=btu_3"}},
            new(){ Type = ButtonType.KeyboardTransition, Label = "🙅‍♂️ Нет, не хочу", Target = new() { Name = "stage=btu_4"}}
        };
        var fragment14_1 = new Fragment()
        {
            Type = FragmentType.Text,
            Buttons = buttons14_1,
            Text = "Посмотри вокруг! Ты видишь первый университетский квартал в Томске. И это всё – Томский политех. Сейчас у вуза 32 учебных и лабораторных корпуса.  Если хочешь узнать про Главный корпус ТПУ и университетский квартал больше, можешь послушать историю строительства первого вузовского кампуса."
        };
        var step14 = new Step() { Name = "btu_2_14", Fragments = new() { fragment14_1 } };

        var stage2 = new Stage()
        {
            Name = "btu_2",
            Label = "Начало прогулки",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 1,
                Latitude = 56.465386,
                Longitude = 84.950481,
                Label = "Вход в ГК ТПУ",
                Address = "Ленина, 30; главный вход"
            }
        };

        var order11 = new StepInStage() { AttachedStage = stage2, Payload = step11, Order = 1, Delay = 1 };
        var order12 = new StepInStage() { AttachedStage = stage2, Payload = step12, Order = 2, Delay = 1 };
        var order13 = new StepInStage() { AttachedStage = stage2, Payload = step13, Order = 3, Delay = 1 };
        var order14 = new StepInStage() { AttachedStage = stage2, Payload = step14, Order = 4, Delay = 1 };

        stage2.Steps = new() { order12, order13, order14, order11 };

        return stage2;
    }

    public static Stage CreateStage_BTU_3()
    {
        var step15 = new Step()
        {
            Name = "btu_3_15",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 3,
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICRWNR5HEDLpmLOdNtkqShs6oJlg15AALjGwADhZFK1ChHroXBv7MqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Istoriya-glavnogo-korpusa-TPU-10-21",
                            Label = "Расшифровка"
                        }
                    }
                }
            }
        };
        var step16 = new Step()
        {
            Name = "btu_3_16",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Если тебе интересно, как же жили томские профессора в начале XX века, то предлагаю посетить очень интересный музей. Это настоящая профессорская квартира, где можно увидеть подлинную мебель, предметы быта, фотографии, картины и другие уникальные свидетельства эпохи. И все это – без всяких заграждений – можно рассмотреть и потрогать. И музей этот совсем рядом с нашим маршрутом, можешь зайти и туда.",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.InlineLink,
                            Label = "Вот ссылка",
                            Link ="https://museum.tomsk.ru/"
                        }
                    }
                }
            }
        };
        var step17 = new Step()
        {
            Name = "btu_3_17",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 4,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICZmNSamVCfzfh46shAeTh1jCbivafAAKTxDEbxMCYSrNA7upQr7HsAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };

        var stage3 = new Stage()
        {
            Name = "btu_3",
            Label = "Про главный корпус ТПУ",
            Type = StageType.Regular,
        };
        var order3 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage3, Payload = step15, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage3, Payload = step16, Order = 2, Delay = 1 },
            new() {AttachedStage =  stage3, Payload = step17, Order = 3, Delay = 1 },
        };
        stage3.Steps = order3;

        return stage3;
    }

    public static Stage CreateStage_BTU_4()
    {
        var step18 = new Step()
        {
            Name = "btu_4_18",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Ну, а мы идем с тобой дальше. Поворачивай направо и иди в сторону университетской лестницы.",
                }
            }
        };
        var step19 = new Step()
        {
            Name = "btu_4_19",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 5,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICD2NRwvAg8pFrpZnyrlsPoR4iVA0AA_jBMRtvPJBKSLQovL1PfjcBAAMCAAN5AAMqBA"}
                        }
                    }
                }
            }
        };
        var step20 = new Step()
        {
            Name = "btu_4_20",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Спускайся вниз по лестнице к самому первому университету на территории русской Азии. Но при этом не забывай смотреть по сторонам! Видишь на другой стороне проспекта Ленина памятник? Посвящен он Сергею Мироновичу Кирову. Он когда-то тоже хотел быть студентом, посещал подготовительные курсы Томского технологического института, но не сложилось – увлекся революцией и стал известным советским государственным и политическим деятелем.",
                }
            }
        };
        var step21 = new Step()
        {
            Name = "btu_4_21",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 6,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICEWNRwvjq1uH4hrIJY1P13aWkhXvgAAL5wTEbbzyQSvdKSN2TWdbIAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step22 = new Step()
        {
            Name = "btu_4_22",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Но Кирова в Томске не забыли. У студентов ТПУ есть давняя традиция: перекрашивать в яркие цвета сапоги у памятника в дни экзаменов, выпускных или перед защитой диплома. Но долго «обновками» Киров не хвастается – обычно служба кампуса ТПУ моментально перекрашивает сапоги обратно в белый цвет. Но студенты не сдаются, поэтому история повторяется регулярно.",
                }
            }
        };
        var step23 = new Step()
        {
            Name = "btu_4_23",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 7,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICE2NRwwLuzf2Ai45L1G6U8FuL6XrnAAL6wTEbbzyQSj0zTvxWI6uyAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step24 = new Step()
        {
            Name = "btu_4_24",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "А буквально рядом с тобой, за забором, расположилась уникальная Университетская роща. Не каждый город может похвастаться таким старинным лесом в центре. Рощу заложили в 1885 году во время строительства Императорского университета. И сейчас это одна из главных достопримечательностей города.",
                }
            }
        };
        var step25 = new Step()
        {
            Name = "btu_4_25",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 8,
                            Caption = "Мы почти дошли до здания первого университетского общежития! Посмотри, как оно выглядело в начале ХХ века.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICFWNRwwWVQBPKGZ5A7HR60pPKz8bQAAL7wTEbbzyQSuSWIPRFQkaSAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };

        var stage4 = new Stage()
        {
            Name = "btu_4",
            Label = "Дорога до университетских общажитий",
            Type = StageType.Regular,
        };
        var order4 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage4, Payload = step18, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step19, Order = 2, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step20, Order = 3, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step21, Order = 4, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step22, Order = 5, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step23, Order = 6, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step24, Order = 7, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step25, Order = 8, Delay = 1 },
        };
        stage4.Steps = order4;
        return stage4;
    }

    public static Stage CreateStage_BTU_5()
    {
        var step26 = new Step()
        {
            Name = "btu_5_26",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 9,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICF2NRwwx0NSZkNjKx6BokjcjU4zzDAAL8wTEbbzyQSucc0OKRiWllAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step27 = new Step()
        {
            Name = "btu_5_27",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "«Приют для учащихся» или Дом общежития студентов –так называлось первое студенческое общежитие Императорского Томского университета. Общежитие вмещало чуть более 75 студентов. Раньше считали, что, сколько в комнате окон, столько и студентов должно проживать в этой комнате. Да, шикарные условия, скажу вам! Ну, а сейчас, это третий корпус ТГУ, где проходят занятия у студентов. Загляни за угол! Ты увидишь здания Научной библиотеки Томского государственного университета.",
                }
            }
        };

        var stage5 = new Stage()
        {
            Name = "btu_5",
            Label = "Научная библиотека ТГУ",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 2,
                Latitude = 56.467007,
                Longitude = 84.950389,
                Label = "3-й корпус ТГУ",
                Address = "пр. Ленина, 34"
            },
        };
        var order5 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage5, Payload = step26, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage5, Payload = step27, Order = 2, Delay = 1 },
        };
        stage5.Steps = order5;
        return stage5;
    }

    public static Stage CreateStage_BTU_6()
    {
        var step28 = new Step()
        {
            Name = "btu_6_28",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 10,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICGWNRwxSwH-kOsbg_o6cQ5DwQtWLGAAL9wTEbbzyQStADONvz5PnqAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step29 = new Step()
        {
            Name = "btu_6_29",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 11,
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICR2NR5LIIAAEvLYc1ArTu9Tp_7fbRRwAC5BsAA4WRSmRfH9nJhI6LKgQ" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Nauchka-10-21",
                        }
                    }
                }
            }
        };
        var step30 = new Step()
        {
            Name = "btu_6_30",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Надеюсь, тебе понравилась история «Научки»! А теперь давай прогуляемся с тобой по Университетской роще до главного корпуса Томского государственного университета. Если нам повезет, то в роще мы сможем встретить белок. Ты приготовил для них угощения? Пройди под переходом между зданиями библиотеки и поворачивай направо за старым корпусом. ",
                }
            }
        };
        var step31 = new Step()
        {
            Name = "btu_6_31",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 12,
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAICG2NRwxgaI-s35qC2jDwz0qhmcxnBAAL-wTEbbzyQSsLoBRkumHKDAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };

        var stage6 = new Stage()
        {
            Name = "btu_6",
            Label = "Научная библиотека ТГУ",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 3,
                Latitude = 56.467561,
                Longitude = 84.950342,
                Label = "Научная библиотека ТГУ",
                Address = "пр. Ленина, 34а"
            },
        };
        var order6 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage6, Payload = step28, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage6, Payload = step29, Order = 2, Delay = 1 },
            new() {AttachedStage =  stage6, Payload = step30, Order = 3, Delay = 1 },
            new() {AttachedStage =  stage6, Payload = step31, Order = 4, Delay = 1 },
        };
        stage6.Steps = order6;
        return stage6;
    }

    public static Stage CreateStage_BTU_00()
    {
        //text
        var step00 = new Step()
        {
            Name = "step_00_00",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "",
                            Target = new() { Name = "" }
                        }
                    }
                }
            }
        };

        // audio
        var step01 = new Step()
        {
            Name = "step_00_01",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 13,
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "",
                        }
                    }
                }
            }
        };

        // photo
        var step02 = new Step()
        {
            Name = "step_00_02",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Id = 14,
                            Caption = "",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = ""}
                        }
                    }
                }
            }
        };

        var stage00 = new Stage()
        {
            Name = "00",
            Label = "",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 0,
                Latitude = 0.05,
                Longitude = 0.08,
                Label = "",
                Address = ""
            },
        };
        var order00 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage00, Payload = step00, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage00, Payload = step00, Order = 2, Delay = 1 },
        };
        stage00.Steps = order00;

        return stage00;
    }
}