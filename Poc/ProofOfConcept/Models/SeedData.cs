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
        var stage7 = CreateStage_BTU_7();
        var stage8 = CreateStage_BTU_8();
        var stage9 = CreateStage_BTU_9();
        var stage10 = CreateStage_BTU_10();
        var stage11 = CreateStage_BTU_11();
        var stage12 = CreateStage_BTU_12();
        var stage13 = CreateStage_BTU_13();
        var stage14 = CreateStage_BTU_14();
        var stage15 = CreateStage_BTU_15();
        var stage16 = CreateStage_BTU_16();
        var stage17 = CreateStage_BTU_17();

        var route = new Route()
        {
            Name = "btu",
            Label = "🏛 Большой томский университет",
            Description = "Томск – это город вузов. На этом маршруте я покажу тебе первое в Томске студенческое общежитие, расскажу, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и что для этого нужно сделать. Мы прогуляемся по университетским корпусам, библиотекам и главным студенческим улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними.",
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
            new() {AttachedRoute = route, From = stage6, To = stage7},
            new() {AttachedRoute = route, From = stage7, To = stage8},
            new() {AttachedRoute = route, From = stage7, To = stage11},
            new() {AttachedRoute = route, From = stage8, To = stage9},
            new() {AttachedRoute = route, From = stage8, To = stage10},
            new() {AttachedRoute = route, From = stage11, To = stage12},
            new() {AttachedRoute = route, From = stage12, To = stage13},
            new() {AttachedRoute = route, From = stage13, To = stage14},
            new() {AttachedRoute = route, From = stage14, To = stage15},
            new() {AttachedRoute = route, From = stage15, To = stage16},
            new() {AttachedRoute = route, From = stage16, To = stage17},
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

        var fragment3_1 = new Fragment() { Type = FragmentType.Text, Text = "1. «По ту сторону Европейского квартала» – это прогулка, во время которой мы увидим центр Томска с неожиданной стороны. Узнаем, где во дворах исторических корпусов Томского политеха профессора сажали картошку, а студенты играли в снежки. Посмотрим на стену, которой больше 110 лет, и на которой кто-то настойчиво пишет посвящения культовой группе Pink Floyd. Услышим исторические факты, малоизвестные легенды и мифы. И даже немного поговорим про НЛО." };
        var step3 = new Step() { Name = "start_3", Label = "Описание Европейского квартала", Fragments = new() { fragment3_1 } };

        var fragment4_1 = new Fragment() { Type = FragmentType.Text, Text = "2. «Большой томский университет» – Томск – это город вузов. На этом маршруте я расскажу тебе, где было первое в Томске студенческое общежитие, зачем студенты красят сапоги Кирову, какой памятник приносит томским студентам удачу, и о многом другом. Мы прогуляемся по университетам, библиотекам, корпусам и основным улицам Томска. Ты узнаешь не только об истории вузов, но и об открытиях и судьбах ученых и исследователей, связанных с ними." };
        var step4 = new Step() { Name = "start_4", Label = "Описание Большого томского университета", Fragments = new() { fragment4_1 } };

        var fragment5_1 = new Fragment() { Type = FragmentType.Text, Text = "Я учусь уже на третьем курсе и скоро стану инженером. У меня много друзей — из политеха и других универов. Томск — тусовочный и молодежный город. Здесь всегда можно найти хорошую компанию, чтобы сходить на выставку или на концерт, выпить кофе или просто погулять. А еще мне нравится исследовать Томск и расспрашивать о нем разных умных людей. Иногда такое узнаешь — прям вау! Конечно, хочется поделиться такими открытиями. Так что выбирай, куда пойдем)  " };
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
        var fragment7_1 = new Fragment() { Type = FragmentType.Text, Text = "А ты знал, что официально Томск — студенческая столица России? Администрация города зарегистрировала соответствующий товарный знак в специальном государственном реестре. По количеству студентов Томск на третьем место после Москвы и Санкт-Петербурга, а еще он входит в международный рейтинг лучших городов для студентов. По сути, Томск – это город-университет. И в 2019 году все вузы и научно-исследовательские институты объединились в мегапроект «Большой университет Томска». Давай-ка прогуляемся по нашему городу-университету! Кстати, по дороге ты можешь встретить местных любимиц – белок. Не забудь взять с собой какие-нибудь лакомства – орехи или семечки, чтобы их порадовать." };
        var step7 = new Step() { Name = "btu_1_7", Label = "Томск – город-университет", Fragments = new() { fragment7_1 } };

        var fragment8_1 = new Fragment() { Type = FragmentType.Text, Text = "Давай будем гулять в светлое время суток! Выбери день с хорошей погодой. Возьми с собой наушники и бутылку воды. " };
        var step8 = new Step() { Name = "btu_1_8", Label = "Давай гулять", Fragments = new() { fragment8_1 } };

        var step9 = new Step()
        {
            Label = "Наш маршрут",
            Name = "btu_1_9",
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFWGNUkqW8RDeAgE-KGeIdAlhLR_UMAAJPvzEbL4aoSrJNKVYh7U6QAQADAgADeQADKgQ"},
                            Caption = "Взгляни на карту – это наш маршрут. Ты можешь передвигаться пешком, а можешь часть маршрута проехать на общественном транспорте. Выбирай сам!",
                        }
                    }
                }
            }
        };

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
            new() { Photo = new() { FileId = "AgACAgIAAxkBAAIFXGNUk7zo6zkSXQABIZTtrYJs_IjoXwACUL8xGy-GqEpfSz5k-GafYgEAAwIAA3kAAyoE" }, Caption = "Главный корпус ТПУ" } }
        };
        var step11 = new Step() { Name = "btu_2_11", Fragments = new() { fragment11_1 } };

        var fragment12_1 = new Fragment()
        {
            Type = FragmentType.Text,
            Text = "Начинаем прогулку с места, где был открыт первый за Уралом технический вуз. Это Томский политехнический университет. Адрес Главного корпуса вуза: проспект Ленина, 30. Посмотри, сильно ли здание изменилось за более чем 120 лет? В начале ХХ века этот корпус носил название Лекционный, потому что был открыт первым в 1900 году, и именно здесь начались занятия у будущих инженеров."
        };
        var step12 = new Step() { Name = "btu_2_12", Fragments = new() { fragment12_1 } };

        var fragment13_1 = new Fragment()
        {
            Type = FragmentType.Media,
            Media = new() {
            new() { /*Id = 2,*/ Photo = new() { FileId = "AgACAgIAAxkBAAIFXmNUlA27HQs_yrgxuJ9zRcnHBsBLAAJRvzEbL4aoSm_wHBXC3z2LAQADAgADeQADKgQ" }, Caption = "Главный корпус ТПУ, начало XX в." } }
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
            Text = "Посмотри вокруг! Ты видишь первый университетский квартал в Томске. И это всё – Томский политех. Сейчас у вуза 32 учебных и лабораторных корпуса. Если хочешь узнать про Главный корпус ТПУ и университетский квартал больше, послушай историю строительства первого вузовского кампуса. "
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
                Address = "Ленина, 30; Главный вход"
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
                            Link = "https://telegra.ph/Istoriya-glavnogo-korpusa-TPU-10-23",
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
                    Text = "Если тебе интересно, как же жили томские профессора в начале XX века, то предлагаю посетить очень интересный музей. Это настоящая профессорская квартира, где можно увидеть подлинную мебель, предметы быта, фотографии, картины и другие уникальные свидетельства эпохи. И все это – без всяких заграждений – можно рассмотреть и потрогать. И музей этот совсем рядом с нашим маршрутом, можешь зайти и туда. Вот ссылка на сайт:\nhttps://museum.tomsk.ru/",
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
                            /*Id = 4,*/
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFYGNUlS2Ri-mzPbdA7Iy9yqPhF7teAAJSvzEbL4aoSpw_1R4-3VQJAQADAgADeQADKgQ"}
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
        var step19 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFYmNUlc_KLSoAAbAQ9BQs4APXq2C8UQACVL8xGy-GqEpdD8bwHis69gEAAwIAA3kAAyoE"},
                            Caption = "Ну, а мы идем с тобой дальше. Поворачивай направо и иди в сторону университетской лестницы.",
                        }
                    }
                }
            }
        };
        var step21 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFZGNUlqGfZsQakWx6FfeQz4kpNcGqAAJVvzEbL4aoSiP8lipHm8dcAQADAgADeQADKgQ"},
                            Caption = "Спускайся вниз по лестнице к самому первому университету на территории русской Азии. Но при этом не забывай смотреть по сторонам! Видишь на другой стороне проспекта Ленина памятник? Посвящен он Сергею Мироновичу Кирову. Он когда-то тоже хотел быть студентом, посещал подготовительные курсы Томского технологического института, но не сложилось – увлекся революцией и впоследствии стал крупным советским государственным и политическим деятелем."
                        }
                    }
                }
            }
        };
        var step22 = new Step()
        {
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
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFZmNUl35BznqUH7NTcwxhdyth1xcMAAJWvzEbL4aoSuFgsLgS2Y9wAQADAgADeQADKgQ"},
                            Caption = "А буквально рядом с тобой, за забором, расположилась уникальная Университетская роща. Не каждый город может похвастаться таким старинным парком. Рощу заложили в 1885 году во время строительства Императорского университета. И сейчас это одна из главных достопримечательностей города."
                        }
                    }
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
                            Caption = "Мы почти дошли до здания первого университетского общежития! Посмотри, как оно выглядело в начале ХХ века.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFaGNUmAH54X8_nHBqwfaz6ppwWt6gAAJXvzEbL4aoSgzqWT2A598tAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };

        var stage4 = new Stage()
        {
            Name = "btu_4",
            Label = "Дорога до университетских общежитий",
            Type = StageType.Regular,
        };
        var order4 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage4, Payload = step19, Order = 1, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step21, Order = 2, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step22, Order = 3, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step23, Order = 4, Delay = 1 },
            new() {AttachedStage =  stage4, Payload = step25, Order = 5, Delay = 1 },
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
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFamNUmJd9NfP2hw34_SmAd0PClohsAAJYvzEbL4aoShUMbZQ9KYXIAQADAgADeQADKgQ"}
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
                    Text = "«Приют для учащихся» или Дом общежития студентов –так называлось первое студенческое общежитие Императорского Томского университета. Общежитие вмещало чуть более 75 студентов. Раньше считали, что, сколько в комнате окон, столько и студентов должно там жить. Да, шикарные условия, скажу вам! Ну а сейчас, это третий корпус ТГУ, где проходят занятия у современных студентов. Загляни за угол! Ты увидишь здания Научной библиотеки Томского государственного университета.",
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
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFbGNUmOi1hEyb_DEV6gmFQHHUgdndAAJZvzEbL4aoStF4YwWmS_IJAQADAgADeQADKgQ"}
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
                            Link = "https://telegra.ph/Istoriya-Nauchki-10-23",
                        }
                    }
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
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIFbmNUmasmPHG7lTBlSPTWQA8IRLmcAAJavzEbL4aoSt_RgTA8kPx3AQADAgADeQADKgQ"},
                            Caption = "Надеюсь, тебе понравилась история «Научки»! А теперь давай прогуляемся с тобой по Университетской роще до главного корпуса Томского государственного университета. Если нам повезет, то в роще мы сможем встретить белок. Ты приготовил для них угощения? Пройди под переходом между зданиями библиотеки и поворачивай направо за старым корпусом.",
                        }
                    },
                    // Buttons = new(){
                    //     new(){Type = ButtonType.RemoveKayboard}
                    // }
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
            new() {AttachedStage =  stage6, Payload = step31, Order = 3, Delay = 1 },
        };
        stage6.Steps = order6;
        return stage6;
    }

    public static Stage CreateStage_BTU_7()
    {
        var step32 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Ты в Университетской роще! Можешь наслаждаться природой, но не забывай внимательно смотреть по сторонам – Университетская роща полна интересных деталей. Хочешь, расскажу?",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "🔘 Да",
                            Target = new() { Name = "stage=btu_8" }
                        },
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "⚪️ Нет",
                            Target = new() { Name = "stage=btu_11" }
                        }
                    }
                },
            }
        };
        var stage7 = new Stage()
        {
            Name = "btu_7",
            Label = "Университетская роща",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 4,
                Latitude = 56.467919,
                Longitude = 84.948684,
                Label = "Университетская роща",
                Address = "Ленина, 34а; Университетская роща"
            },
        };
        var order7 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage7, Payload = step32, Order = 1, Delay = 1 },
        };
        stage7.Steps = order7;
        return stage7;
    }

    public static Stage CreateStage_BTU_8()
    {
        var step33 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo10
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIF3mNUqYkP_WgMUrjCycDTP4k3YWHkAAJevzEbL4aoSvrLOJixN-UXAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step34 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                        new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICSWNR5Ls6XX_AzExkFBnRcYHwphfhAALlGwADhZFKHvdPoFz2c5gqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/To-chto-bylo-na-meste-Nauchki-10-23",
                        }
                    }
                }
            }
        };
        var step35 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo11
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIF4mNUqnu50ZPCnf4fpR0mnJjpECUAA1-_MRsvhqhK3z84cPjj3OMBAAMCAAN5AAMqBA"}
                        }
                    }
                }
            }
        };
        var step36 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                        new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICS2NR5MQfJcagPHx7L0tIk4-Dh9bdAALmGwADhZFKktdS_ve15iEqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Pamyatnik-Grigoriyu-Potaninu-10-23",
                        }
                    }
                }
            }
        };
        var step37 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo12
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIF5GNUqzYJsafWsB8dDSBVzeGcqMOeAAJgvzEbL4aoSqUYR1znF6XUAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step38 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                        new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICTWNR5NFrFLFJVtydZVLwGYAv9XvwAALnGwADhZFKHxGXSo4HjkgqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/O-Potanine-10-23",
                        }
                    }
                }
            }
        };
        var step39 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo13
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIF5mNUq-3KiQVC55DwyYZ-ULYv4JbDAAJhvzEbL4aoSlN3_wJsC5UMAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step40 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                        new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICT2NR5NqDYBQrdwIn6r0fDlIgtRPfAALoGwADhZFKKjQbS3SljYwqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Derevya-ryadom-s-TGU-10-23",
                        }
                    }
                }
            }
        };
        var step41 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Раз уж мы с тобой рядом с ёлками, то предлагаю найти каменные скульптуры — они где-то рядом. Называют их каменными бабами — скорее всего, из-за созвучного названия – балбал.\nНашёл?",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "🔘 Да",
                            Target = new() { Name = "btu_9" }
                        },
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "⚪️ Нет",
                            Target = new() { Name = "btu_10" }
                        },
                    }
                }
            }
        };
        var stage8 = new Stage()
        {
            Name = "btu_8",
            Type = StageType.Regular,
        };
        var order8 = new List<StepInStage>()
        {
            new() {AttachedStage = stage8, Payload = step33, Order = 1, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step34, Order = 2, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step35, Order = 3, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step36, Order = 4, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step37, Order = 5, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step38, Order = 6, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step39, Order = 7, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step40, Order = 8, Delay = 1 },
            new() {AttachedStage = stage8, Payload = step41, Order = 9, Delay = 1 },
        };
        stage8.Steps = order8;
        return stage8;
    }

    public static Stage CreateStage_BTU_9()
    {
        var step42 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Такие каменные изваяния воздвигали на просторах Евразии в VI-IX веках во времена тюркских каганатов. Эти скульптуры посвящали воинам-героям и знатным людям. В ТГУ средневековые изваяния попали из Семиречья и Алтая в 1886 – 1900 годах. Со дня установки и до нашего времени каменные бабы успели обрасти легендами и стали неотъемлемой частью Университетской рощи.",
                }
            }
        };
        var stage9 = new Stage()
        {
            Name = "btu_9",
            Type = StageType.Regular,
        };
        var order9 = new List<StepInStage>()
        {
            new() {AttachedStage = stage9, Payload = step42, Order = 1, Delay = 1 },

        };
        stage9.Steps = order9;
        return stage9;
    }

    public static Stage CreateStage_BTU_10()
    {
        var step43 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo14
                            Caption = "Посмотри внимательнее! Ну, вот же они!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIGRmNUxtvdoEZdGm4sgMnElTdkPCymAAJqvzEbL4aoSuYOQpaclo8BAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step44 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Такие каменные изваяния воздвигали на просторах Евразии в VI-IX веках во времена тюркских каганатов. Эти скульптуры посвящали воинам-героям и знатным людям. В ТГУ средневековые изваяния попали из Семиречья и Алтая в 1886 – 1900 годах. Со дня установки и до нашего времени каменные бабы успели обрасти легендами и стали неотъемлемой частью Университетской рощи.",
                }
            }
        };
        var step45 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo15
                            Caption = "Есть в роще и еще один, более молодой памятник. Посвящен он покровителям и устроителям Императорского томского университета – Дмитрию Ивановичу Менделееву и Василию Марковичу Флоринскому. Средства на установку собирали благодарные сибиряки – выпускники университета и меценаты. Скульптура украсила рощу в 2018 году. У этого памятника есть название – профессора Флоринский и Менделеев обсуждают проект Первого Сибирского университета. ",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIGSGNUx7naXk1kyp3Jefhv0nZG2OcpAAJsvzEbL4aoStWdhYCR1TQiAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step46 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "А вот и он – первый университет Сибири!",
                }
            }
        };
        var stage10 = new Stage()
        {
            Name = "btu_10",
            Type = StageType.Regular,
        };
        var order10 = new List<StepInStage>()
        {
            new() {AttachedStage = stage10, Payload = step43, Order = 1, Delay = 1 },
            new() {AttachedStage = stage10, Payload = step44, Order = 2, Delay = 1 },
            new() {AttachedStage = stage10, Payload = step45, Order = 3, Delay = 1 },
            new() {AttachedStage = stage10, Payload = step46, Order = 4, Delay = 1 },

        };
        stage10.Steps = order10;
        return stage10;
    }

    public static Stage CreateStage_BTU_11()
    {
        var step47 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Прогуляйся по университетской роще, подыши чистым воздухом, послушай пение птиц. Как дойдешь до главного корпуса Томского государственного университета, скажи. ",
                }
            }
        };
        var stage11 = new Stage()
        {
            Name = "btu_11",
            Type = StageType.Regular,
        };
        var order11 = new List<StepInStage>()
        {
            new() {AttachedStage = stage11, Payload = step47, Order = 1, Delay = 1 },

        };
        stage11.Steps = order11;
        return stage11;
    }

    public static Stage CreateStage_BTU_12()
    {
        var step48 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo16
                            Caption = "Предлагаю походить возле или вокруг корпуса. А пока ходишь-бродишь, я расскажу тебе немного про историю вуза.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIG0WNU1FaWIwTP2BteeUGb0ByGPtstAAJ8vzEbL4aoSiBl0dnBiVhqAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step49 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                        new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICUWNR5OMb3h0AAVaEhNjoXqpEw5oVNwAC6RsAA4WRSoyO9hMwh3WVKgQ" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Tomsk-a-ne-Omsk-10-23",
                        }
                    }
                }
            }
        };
        var step50 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Дай знать, когда закончишь.",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "🚩 Закончил",
                            Target = new() { Name = "stage=btu_13" }
                        }
                    }
                }
            }
        };
        var stage12 = new Stage()
        {
            Name = "btu_12",
            Type = StageType.Regular,
        };
        var order12 = new List<StepInStage>()
        {
            new() {AttachedStage = stage12, Payload = step48, Order = 1, Delay = 1 },
            new() {AttachedStage = stage12, Payload = step49, Order = 2, Delay = 1 },
            new() {AttachedStage = stage12, Payload = step50, Order = 3, Delay = 1 },
        };
        stage12.Steps = order12;
        return stage12;

    }

    public static Stage CreateStage_BTU_13()
    {
        var step51 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Сейчас мы с тобой выйдем на проспект Ленина и двинемся в сторону еще одного университета, который появился благодаря ТГУ. Но об этом я расскажу чуть позже.",
                }
            }
        };
        var step52 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo17
                            Caption = "А пока выходи через главные ворота ТГУ, поворачивай налево и иди вдоль ограды. Но только выходи через боковые калитки! Студенты говорят, что выходить через центральные ворота – плохая примета!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIG02NU1xIthKc96G10cXuItQkhd8CEAAJ-vzEbL4aoSiy28nHkSCw0AQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step53 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Мало кто знает, что эта пешеходная часть проспекта Ленина неофициально называется Александровским бульваром. Так аллею назвали в память о трех императорах: Александре I, Александре II и Александре III. Именно благодаря им и появился первый в Сибири университет.",
                }
            }
        };
        var step54 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo18
                            Caption = "Идем дальше? Сейчас тебе нужно дойти до конца Александровского бульвара. Там ты увидишь корпус третьего на нашем маршруте университета.\nКак дойдешь, отпишись!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIG62NU2cW7xdeJR_CwObTgB2Xx5DclAAKPvzEbL4aoSmth2Kpc8X8IAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var stage13 = new Stage()
        {
            Name = "btu_13",
            Type = StageType.Regular,
        };
        var order13 = new List<StepInStage>()
        {
            new() {AttachedStage = stage13, Payload = step51, Order = 1, Delay = 1 },
            new() {AttachedStage = stage13, Payload = step52, Order = 2, Delay = 1 },
            new() {AttachedStage = stage13, Payload = step53, Order = 3, Delay = 1 },
            new() {AttachedStage = stage13, Payload = step54, Order = 4, Delay = 1 },
        };
        stage13.Steps = order13;
        return stage13;
    }

    public static Stage CreateStage_BTU_14()
    {
        var step55 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo19
                            Caption = "В этом здании, построенном в 1892 году, располагаются факультетские клиники Сибирского государственного медицинского университета. Это настоящий многопрофильный специализированный клинический комплекс, где лечат больных. Предлагаю послушать историю факультетских клиник и прогуляться вдоль корпуса до перекрестка.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHBmNU2zlhu1ARZG3DEnHVImH9fsF2AAKUvzEbL4aoSj3YzpA9AQlLAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step56 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICU2NR5O5kgVuli_DZPljpD_Uncz9RAALqGwADhZFKoKkgUvAvGaIqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/Kliniki-10-23",
                        }
                    }
                }
            }
        };
        var step57 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo20
                            Caption = "Идем дальше? Поворачивай налево на перекрестке и дойди до главного корпуса  Сибирского государственного медицинского университета.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHCGNU3ATyXWns3qHE2oPxiD1pSvWcAAKVvzEbL4aoSvYFxi6gkRmaAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var stage14 = new Stage()
        {
            Name = "btu_14",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 6,
                Latitude = 56.472977,
                Longitude = 84.950107,
                Label = "Факультетские клиники СибГМУ",
                Address = "пр. Ленина, 38; Факультетские клиники СибГМУ"
            },
        };
        var order14 = new List<StepInStage>()
        {
            new() {AttachedStage = stage14, Payload = step55, Order = 1, Delay = 1 },
            new() {AttachedStage = stage14, Payload = step56, Order = 2, Delay = 1 },
            new() {AttachedStage = stage14, Payload = step57, Order = 3, Delay = 1 },
        };
        stage14.Steps = order14;
        return stage14;
    }

    public static Stage CreateStage_BTU_15()
    {
        var step58 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo21
                            Caption = "Перед тобой главный корпус одного из старейших и наиболее авторитетных российских медицинских вузов – СибГМУ.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHCmNU3dz2U0LSUeIs07mZAxaU6yZUAAKevzEbL4aoSnMzDv_rmqwfAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step59 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICVWNR5PbZLEvWn6Uy2OKOrctngtg9AALrGwADhZFKWyQKoU2qfgYqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/SibGMU-10-23",
                        }
                    }
                }
            }
        };
        var step60 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Тебе нужно вернуться на проспект Ленина и перейти по пешеходному переходу со светофором на другую сторону. Мы — на площади Ново-Соборной. Обрати внимание на здание на углу площади и проспекта Ленина.",
                }
            }
        };
        var step61 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo22
                            Caption = "Это, между прочим, одно из старейших зданий города! Построено двухэтажное кирпичное здание в стиле классицизма в 1842 году. До 1919 года в нем располагалось губернское управление, затем – органы советской власти. А в 1928 году его передали Сибирскому физико-техническому институту, основанному, кстати, на базе Института прикладной физики Томского технологического института (ныне ТПУ).",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHDGNU35sRMEDT4jfBNmXvpeAbl83QAAKjvzEbL4aoSu3LdRxrHlt6AQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step62 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "А сейчас поворачивай налево и иди к фонтану в центре Ново-Соборной площади. Как будешь на месте, маякни!",
                }
            }
        };

        var stage15 = new Stage()
        {
            Name = "btu_15",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 7,
                Latitude = 56.472977,
                Longitude = 84.948348,
                Label = "Главный корпус СибГМУ",
                Address = "Московский тракт, 2; Главный корпус СибГМУ"
            },
        };
        var order15 = new List<StepInStage>()
        {
            new() {AttachedStage = stage15, Payload = step58, Order = 1, Delay = 1 },
            new() {AttachedStage = stage15, Payload = step59, Order = 2, Delay = 1 },
            new() {AttachedStage = stage15, Payload = step60, Order = 3, Delay = 1 },
            new() {AttachedStage = stage15, Payload = step61, Order = 4, Delay = 1 },
            new() {AttachedStage = stage15, Payload = step62, Order = 5, Delay = 1 },
        };
        stage15.Steps = order15;
        return stage15;
    }

    public static Stage CreateStage_BTU_16()
    {
        var step63 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo23
                            Caption = "Поздоровайся с Татьяной!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHDmNU5mz5TA0AAXSHWiLv17_QKGJuuAACsb8xGy-GqEqWVQ-RpgmaRAEAAwIAA3kAAyoE"}
                        }
                    }
                }
            }
        };
        var step64 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Есть в Томске еще одно место, куда студенты приходят перед важными учебными делами и просят помощи и удачи. Это памятник Святой Татьяне. По поверью, Святая Татьяна была покровительницей всех учащихся и студентов. Она помогала «грызть гранит науки», хорошо учиться и сдавать экзамены. Студенты Томска не забывают свою покровительницу: зимой, в самые морозы, они «утепляют» Татьяну, одевая ее в шарф и шапку. Обязательно сделай с Татьяной фото на память!",
                }
            }
        };
        var step65 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Ну а сейчас я покажу тебе самый молодой университет Томска. Возвращайся к фонтану и посмотри на противоположную сторону проспекта Ленина. ",
                }
            }
        };

        var stage16 = new Stage()
        {
            Name = "btu_16",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 8,
                Latitude = 56.474273,
                Longitude = 84.951418,
                Label = "Памятник Студенчевству",
                Address = "Новособорная площадь; Памятник Татьяне"
            },
        };
        var order16 = new List<StepInStage>()
        {
            new() {AttachedStage = stage16, Payload = step63, Order = 1, Delay = 1 },
            new() {AttachedStage = stage16, Payload = step64, Order = 2, Delay = 1 },
            new() {AttachedStage = stage16, Payload = step65, Order = 3, Delay = 1 },
        };
        stage16.Steps = order16;
        return stage16;
    }

    public static Stage CreateStage_BTU_17()
    {
        var step66 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            //photo24
                            Caption = "Ты видишь перед собой главный корпус Томского государственного университета систем управления и радиоэлектроники (ТУСУР). Это здание с монументальными колоннами известно многим, так как находится напротив главной площади Томска. Но не все знают, что изначально оно было в два раза меньше, никаких колонн вообще не было! Да и вообще у этого здания очень длинная и богатая история, в которой нашлось место и железной дороге, и погрому, и электронике.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIHEGNU5_CM-19moMKvU8g-UQ5fInBUAAK3vzEbL4aoSim_UXh3ZV3_AQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        var step67 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Media,
                    Media = new()
                    {
                         new Media()
                        {
                            Type = MediaType.Sound,
                            Sound = new Sound()
                            {
                                Type = SoundType.Audio,
                                Audio = new(){ FileId = "CQACAgIAAxkBAAICV2NR5QIo_rwedKxuFff9LiCCT_XRAALsGwADhZFKsHUhie1c3xgqBA" }
                            }
                        }
                    },
                    Buttons = new()
                    {
                        new Button()
                        {
                            Label = "Расшифровка",
                            Type = ButtonType.InlineLink,
                            Link = "https://telegra.ph/TUSUR-10-23",
                        }
                    }
                }
            }
        };
        var step68 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "У студентов ТУСУРа есть необычная традиция. Каждый год в День радио, 7 мая, они выкидывают из окон общежития радиотехнического факультета старые телевизоры и другую неработающую технику. Это очень эффектное зрелище! Традиция зародилась в 1988 году – с тех пор студенты разбивают старые телевизоры в ознаменование победы технического прогресса. Технический мусор после выбрасывания университет передает на переработку.",
                }
            }
        };
        var step69 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Мы с тобой можем двигаться дальше. Предлагаю тебе подойти на остановку и ждать маршрутку. Тебе подойдет любой автобус, который идет в сторону Белого озера: 23, 33, 26, 130, 1, 3 троллейбусы и другие. Выйти нужно на остановке ТГАСУ.",
                }
            }
        };

        var stage17 = new Stage()
        {
            Name = "btu_17",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 9,
                Latitude = 56.474246,
                Longitude = 84.95097,
                Label = "Фонтан",
                Address = "Ново-Соборная площадь. Возле фонтана"
            },
        };
        var order17 = new List<StepInStage>()
        {
            new() {AttachedStage = stage17, Payload = step66, Order = 1, Delay = 1 },
            new() {AttachedStage = stage17, Payload = step67, Order = 2, Delay = 1 },
            new() {AttachedStage = stage17, Payload = step68, Order = 3, Delay = 1 },
            new() {AttachedStage = stage17, Payload = step69, Order = 4, Delay = 1 },
        };
        stage17.Steps = order17;
        return stage17;
    }

    /*------------------------------------------------------------------*/

    public static Stage CreateStage_BTU_00()
    {
        //text
        var step00 = new Step()
        {
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
                            /*Id = 14,*/
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