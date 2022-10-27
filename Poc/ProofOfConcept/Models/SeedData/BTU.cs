
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class BTU
{
    public static Route CreateRoute_BTU()
    {
        var stage2 = BTU.CreateStage_BTU_2();
        var stage3_1 = BTU.CreateStage_BTU_3_1();
        var stage3_2 = BTU.CreateStage_BTU_3_2();
        var stage4 = BTU.CreateStage_BTU_4();
        var stage5 = BTU.CreateStage_BTU_5();
        var stage6 = BTU.CreateStage_BTU_6();
        var stage7 = BTU.CreateStage_BTU_7();
        var stage8 = BTU.CreateStage_BTU_8();
        var stage9 = BTU.CreateStage_BTU_9();
        var stage10 = BTU.CreateStage_BTU_10();
        var stage11 = BTU.CreateStage_BTU_11();
        var stage12 = BTU.CreateStage_BTU_12();
        var stage13 = BTU.CreateStage_BTU_13();
        var stage14 = BTU.CreateStage_BTU_14();
        var stage15 = BTU.CreateStage_BTU_15();
        var stage16 = BTU.CreateStage_BTU_16();
        var stage17 = BTU.CreateStage_BTU_17();
        var stage18_1 = BTU.CreateStage_BTU_18_1();
        var stage18_2 = BTU.CreateStage_BTU_18_2();
        var stage18_a = BTU.CreateStage_BTU_18_a();
        var stage19 = BTU.CreateStage_BTU_19();
        var stage20 = BTU.CreateStage_BTU_20();
        var stage21 = BTU.CreateStage_BTU_21();
        var stage22 = BTU.CreateStage_BTU_22();
        var stage23 = BTU.CreateStage_BTU_23();
        var stage24 = BTU.CreateStage_BTU_24();


        var route = new Route()
        {
            Name = "btu",
            Label = "🏛 Большой томский университет",
            Description = "Томск – это город вузов.\nНа этом маршруте я покажу тебе первое в Томске студенческое общежитие, \nрасскажу,\n зачем студенты красят сапоги Кирову,\n какой памятник приносит томским студентам удачу, \nи что для этого нужно сделать.\n Мы прогуляемся по университетским корпусам,\n библиотекам и главным студенческим улицам Томска. \nТы узнаешь не только об истории вузов, \n            но и об открытиях и судьбах ученых и исследователей,\n связанных с ними.",
            InitialStage = stage2
        };
        var stages = new List<StageSequence>()
        {
            new() {AttachedRoute = route, From = stage2, To = stage3_1},
            new() {AttachedRoute = route, From = stage2, To = stage3_2},
            new() {AttachedRoute = route, From = stage3_1, To = stage4},
            new() {AttachedRoute = route, From = stage3_2, To = stage4},
            new() {AttachedRoute = route, From = stage4, To = stage5},
            new() {AttachedRoute = route, From = stage5, To = stage6},
            new() {AttachedRoute = route, From = stage6, To = stage7},
            new() {AttachedRoute = route, From = stage7, To = stage8},
            new() {AttachedRoute = route, From = stage7, To = stage11},
            new() {AttachedRoute = route, From = stage8, To = stage9},
            new() {AttachedRoute = route, From = stage9, To = stage11},
            new() {AttachedRoute = route, From = stage8, To = stage10},
            new() {AttachedRoute = route, From = stage10, To = stage11},
            new() {AttachedRoute = route, From = stage11, To = stage12},
            new() {AttachedRoute = route, From = stage12, To = stage13},
            new() {AttachedRoute = route, From = stage13, To = stage14},
            new() {AttachedRoute = route, From = stage14, To = stage15},
            new() {AttachedRoute = route, From = stage15, To = stage16},
            new() {AttachedRoute = route, From = stage16, To = stage17},
            new() {AttachedRoute = route, From = stage17, To = stage18_1},
            new() {AttachedRoute = route, From = stage17, To = stage18_2},
            new() {AttachedRoute = route, From = stage18_1, To = stage18_a},
            new() {AttachedRoute = route, From = stage18_2, To = stage18_a},
            new() {AttachedRoute = route, From = stage18_a, To = stage19},
            new() {AttachedRoute = route, From = stage19, To = stage20},
            new() {AttachedRoute = route, From = stage20, To = stage21},
            new() {AttachedRoute = route, From = stage21, To = stage22},
            new() {AttachedRoute = route, From = stage22, To = stage23},
            new() {AttachedRoute = route, From = stage23, To = stage24},
            new() {AttachedRoute = route, From = stage24, To = SeedData.ChooseStage},
        };
        route.Stages = stages;
        return route;
    }

    public static Stage CreateStage_BTU_2()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "А ты знал, что официально <b>Томск — студенческая столица России?</b> Администрация города зарегистрировала соответствующий товарный знак в специальном государственном реестре.\n\nПо количеству студентов Томск на третьем место после Москвы и Санкт-Петербурга, а еще он входит в международный рейтинг лучших городов для студентов.\n\nПо сути, <b>Томск – это город-университет</b>. И в 2019 году все вузы и научно-исследовательские институты объединились в мегапроект «Большой университет Томска».\n\nДавай-ка прогуляемся по нашему городу-университету!",
           }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIUHGNY0zDmHbSItuFGsXHPbcXxB50KAALivTEbeGzISqBTvRYSJDYqAQADAgADeQADKgQ"}, Caption ="Главный корпус ТПУ"}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Начинаем прогулку с места, где был открыт первый за Уралом технический вуз. <a href=\"https://tpu.ru/\">Это Томский политехнический университет.</a> Посмотри, сильно ли здание изменилось за более чем 120 лет?\n\nВ начале ХХ века этот корпус носил название Лекционный, потому что был открыт первым в 1900 году, и именно здесь начались занятия у будущих инженеров. ",
           }}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIUMmNY8lct3xA6Lo2vUR4bqWcjfqigAAKPvjEbeGzISqzT5n8mqH_DAQADAgADeQADKgQ"}, Caption ="Главный корпус ТПУ, начало ХХ в."}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Посмотри вокруг! Ты видишь <b>первый университетский квартал в Томске.</b> <b>И это всё – Томский политех.</b>\n\nСейчас у вуза 32 учебных и лабораторных корпуса. Если хочешь узнать про Главный корпус ТПУ и университетский квартал больше, <b>послушай историю строительства первого вузовского кампуса.</b>", Buttons = new() {
                new Button() { Type = ButtonType.KeyboardTransition, Label = "💁‍♂️ Да, хочу узнать", Target = new() { Name = "stage=btu_3_1" } },
                new() { Type = ButtonType.KeyboardTransition, Label = "🙅‍♂️ Нет, не хочу", Target = new() { Name = "stage=btu_3_2" } } } } },
        };

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
                Address = "Ленина, 30, главный вход"
            }
        };

        var order1 = new StepInStage() { AttachedStage = stage2, Payload = step1, Order = 1, Delay = 0 };
        var order2 = new StepInStage() { AttachedStage = stage2, Payload = step2, Order = 2, Delay = 0 };
        var order3 = new StepInStage() { AttachedStage = stage2, Payload = step3, Order = 3, Delay = 0 };
        var order4 = new StepInStage() { AttachedStage = stage2, Payload = step4, Order = 4, Delay = 0 };
        var order5 = new StepInStage() { AttachedStage = stage2, Payload = step5, Order = 5, Delay = 0 };
        stage2.Steps = new() { order1, order2, order3, order4, order5 };
        return stage2;
    }

    public static Stage CreateStage_BTU_3_1()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Type = MediaType.Sound, Sound = new() { Type = SoundType.Audio, Audio = new() { FileId = "CQACAgIAAxkBAAIUIGNY3Pyo7Gt9YukQ02MgsxdVXtfUAAIvIQACeGzISlpV_WgfYgEaKgQ" } } } }, Buttons = new() { new Button() { Line = 1, Type = ButtonType.InlineLink, Link = "https://telegra.ph/Istoriya-glavnogo-korpusa-TPU-10-23", Label = "Расшифровка" }, new Button() { Line = 2, Type = ButtonType.InlineTransition, Label = "Послушал", Target = new() { Name = "stage=btu_4" } } } } }
        };
        var stage = new Stage()
        {
            Name = "btu_3_1",
            Type = StageType.Regular,
        };
        var order3 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage, Payload = step, Order = 1, Delay = 0 },
        };
        stage.Steps = order3;

        return stage;
    }

    public static Stage CreateStage_BTU_3_2()
    {
        var step17 = new Step()
        {
            Name = "btu_3_17",
            Fragments = new() { new Fragment() { Type = FragmentType.Media, Media = new() { new Media() { Type = MediaType.Photo, Photo = new() { FileId = "AgACAgIAAxkBAAIUImNY4KGRk40LrpySBtiLn7MBjfRFAAIQvjEbeGzISocp_WlcAgUpAQADAgADeQADKgQ" }, Caption = "Если тебе интересно, как же жили томские профессора в начале XX века, то предлагаю посетить очень интересный <b><a href=\"https://museum.tomsk.ru/\"> частный музей «Профессорская квартира»</a></b>.\n\nЗдесь можно увидеть подлинную мебель, предметы быта, фотографии, картины и другие уникальные свидетельства эпохи.\n\nИ все это – без всяких заграждений – можно рассмотреть и потрогать. И музей этот совсем рядом с нашим маршрутом, можешь зайти и туда." } } } }
        };

        var stage = new Stage()
        {
            Name = "btu_3_2",
            Label = "Профессорская квартира",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage =  stage, Payload = step17, Order = 1, Delay = 0 },
        };
        stage.Steps = order;

        return stage;
    }

    public static Stage CreateStage_BTU_4()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIUJGNY77fVOsuE324x_BwcvZyBaYmaAAJsvjEbeGzISp-lefXF8HQKAQADAgADeQADKgQ"}, Caption ="Ну а мы идем с тобой дальше.Поворачивай направо и иди в сторону университетской лестницы."}}}}
        };

        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Спускайся вниз по лестнице к самому первому университету на территории русской Азии. Но при этом не забывай смотреть по сторонам!\n\nВидишь на другой стороне проспекта Ленина памятник?\nПосвящен он Сергею Мироновичу Кирову. Он когда-то тоже хотел быть студентом, посещал подготовительные курсы Томского технологического института, но не сложилось – увлекся революцией и впоследствии стал крупным советским государственным и политическим деятелем." } }
        };

        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIULmNY8Jgfin4cC6F-cw_bmqhnPv04AAJ1vjEbeGzISuR4Y9maatYqAQADAgADeQADKgQ"}, Caption ="<i>Но Кирова в Томске не забыли.</i>\n\nУ студентов ТПУ есть давняя традиция: перекрашивать в яркие цвета сапоги у памятника в дни экзаменов, выпускных или перед защитой диплома.\n\nНо долго «обновками» Киров не хвастается – обычно служба кампуса ТПУ моментально перекрашивает сапоги обратно в белый цвет, только вот студенты не сдаются, поэтому история повторяется регулярно."}}}}
        };
        var step4 = new Step()
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUMGNY8fhj1F5Nbq1ZJ0SeXy7nS0atAAKNvjEbeGzISp6rhIJeLJvCAQADAgADeQADKgQ"},
                            Caption = "А буквально рядом с тобой, за забором, расположилась <b>уникальная Университетская роща</b>.\n\nНе каждый город может похвастаться таким старинным парком. Рощу заложили в 1885 году во время строительства Императорского университета. И сейчас это одна из главных достопримечательностей города."
                        }
                    }
                }
            }
        };
        var step5 = new Step()
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
                            Caption = "Мы почти дошли до здания <b>первого университетского общежития!</b> Посмотри, как оно выглядело в начале ХХ века.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUNGNY8mbufgABipm5CpUoeROikZQpAQAC7L0xG3hsyEqI6jGQf9nWjgEAAwIAA3kAAyoE"}
                        }
                    }
                }
            }
        };

        var stage3 = new Stage()
        {
            Name = "btu_4",
            Type = StageType.Regular,
        };
        var order3 = new List<StepInStage>()
        {
            new() {AttachedStage =  stage3, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage =  stage3, Payload = step2, Order = 2, Delay = 0 },
            new() {AttachedStage =  stage3, Payload = step3, Order = 3, Delay = 0 },
            new() {AttachedStage =  stage3, Payload = step4, Order = 4, Delay = 0 },
            new() {AttachedStage =  stage3, Payload = step5, Order = 5, Delay = 0 },
        };
        stage3.Steps = order3;

        return stage3;
    }

    public static Stage CreateStage_BTU_5()
    {
        var step27 = new Step()
        {
            Name = "btu_5_27",
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUNmNY9oRewgN7X7tX-QABx-Q0Y0P95gACn74xG3hsyEqIIBiBzV2srQEAAwIAA3kAAyoE"},
                            Caption = "«Приют для учащихся» или Дом общежития студентов – так называлось первое студенческое общежитие Императорского Томского университета. Общежитие вмещало чуть более 75 студентов. Раньше считали, что, сколько в комнате окон, столько и студентов должно там жить. Да, шикарные условия, скажу вам!\n\nНу а сейчас, это <b>третий корпус ТГУ</b>, где проходят занятия у современных студентов. Загляни за угол! Ты увидишь <a href=\"https://www.lib.tsu.ru/ru\"><b>здания Научной библиотеки Томского государственного университета.</b></a>"
                        }
                    },
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
            new() {AttachedStage =  stage5, Payload = step27, Order = 1, Delay = 0 },
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUOGNY-HIPlT_Kx8O2UzUNV_DEE0MZAAKqvjEbeGzISkQNc1DPQZA0AQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUOmNY-LuqMXHRDYI74vdNhZ9OU0UTAALsIQACeGzIShBZ_qD8C8yYKgQ" }
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
        var step30 = new Step()
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
                            Caption = "Надеюсь, тебе понравилась история «Научки»!\n\nА теперь давай прогуляемся с тобой по Университетской роще до главного корпуса Томского государственного университета.\n\nЕсли нам повезет, то в роще мы сможем встретить белок. Ты приготовил для них угощения?\n\n<b>Пройди под переходом между зданиями библиотеки и поворачивай направо за старым корпусом.</b>",
                        }
                    },
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
            new() {AttachedStage =  stage6, Payload = step28, Order = 1, Delay = 0 },
            new() {AttachedStage =  stage6, Payload = step29, Order = 2, Delay = 0 },
            new() {AttachedStage =  stage6, Payload = step30, Order = 3, Delay = 0 },
        };
        stage6.Steps = order6;
        return stage6;
    }

    public static Stage CreateStage_BTU_7()
    {
        // ты в университетской роще
        var step32 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Ты в <b>Университетской роще!</b>\n\nМожешь наслаждаться природой, но не забывай внимательно смотреть по сторонам – Университетская роща полна интересных деталей.\n\nХочешь, расскажу?",
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
            new() {AttachedStage =  stage7, Payload = step32, Order = 1, Delay = 0 },
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUPGNY-VSSYoR2iOe1jnW0mzAAAbE4QwACrb4xG3hsyEp7yJMJhYSHfAEAAwIAA3kAAyoE"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUPmNY-X0FDrCv19IBw9bSBnXeM_yIAAL0IQACeGzISus29iyxODHEKgQ" }
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUQGNY-gGFHW3BrdEC7QX8bDKFaAwEAAK5vjEbeGzIStEVZopZhdUvAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUQmNY-o4beKd6OpVuBay8mqOR-x82AAL3IQACeGzISvlJFdRaatW_KgQ" }
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIURGNY-rVnuWBAwhm0aZs2CIQl2Ym6AAK8vjEbeGzISugAAZk_rIzYvQEAAwIAA3kAAyoE"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIURmNY-txN3jnwatDm3tkWxX8Oje8_AAL5IQACeGzISoYZKMUdfr1VKgQ" }
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUSGNY-wMbLbOC_bqKjX7fV_K7emb6AALAvjEbeGzISsITbOgciHMnAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUSmNY-1Y5Yx3uwyN3Pnnd59G-JnvyAAL6IQACeGzISt8d-kTVfsnhKgQ" }
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
        // раз уж мы рядом с ёлками
        var step41 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Раз уж мы с тобой рядом с ёлками, то предлагаю найти каменные скульптуры — они где-то рядом. Называют их каменными бабами — скорее всего, из-за созвучного названия – балбал.\n\nНашёл?",
                    Buttons = new()
                    {
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "🔘 Да",
                            Target = new() { Name = "route=btu:stage=btu_9" }
                        },
                        new Button()
                        {
                            Type = ButtonType.KeyboardTransition,
                            Label = "⚪️ Нет",
                            Target = new() { Name = "route=btu:stage=btu_10" }
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
            new() {AttachedStage = stage8, Payload = step33, Order = 1, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step34, Order = 2, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step35, Order = 3, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step36, Order = 4, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step37, Order = 5, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step38, Order = 6, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step39, Order = 7, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step40, Order = 8, Delay = 0 },
            new() {AttachedStage = stage8, Payload = step41, Order = 9, Delay = 0 },
        };
        stage8.Steps = order8;
        return stage8;
    }

    public static Stage CreateStage_BTU_9()
    {
        // каменные извояния
        var step42 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Такие каменные изваяния воздвигали на просторах Евразии в VI-IX веках во времена тюркских каганатов. Эти скульптуры посвящали воинам-героям и знатным людям.\n\nВ ТГУ средневековые изваяния попали из Семиречья и Алтая в 1886 – 1900 годах. Со дня установки и до нашего времени каменные бабы успели обрасти легендами и стали неотъемлемой частью Университетской рощи.",
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
            new() {AttachedStage = stage9, Payload = step42, Order = 1, Delay = 0 },

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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUTGNY_At7J2UMXXYvHS7ueH0AAa9jDAACxL4xG3hsyEpepcgf0m4V0AEAAwIAA3kAAyoE"}
                        }
                    }
                }
            }
        };
        //их воздвигали
        var step44 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Такие каменные изваяния воздвигали на просторах Евразии в VI-IX веках во времена тюркских каганатов. Эти скульптуры посвящали воинам-героям и знатным людям.\n\nВ ТГУ средневековые изваяния попали из Семиречья и Алтая в 1886 – 1900 годах. Со дня установки и до нашего времени каменные бабы успели обрасти легендами и стали неотъемлемой частью Университетской рощи.",
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
                            Caption = "Есть в роще и еще один, более молодой памятник. Посвящен он покровителям и устроителям Императорского томского университета – Дмитрию Ивановичу Менделееву и Василию Марковичу Флоринскому.\n\nСредства на установку собирали благодарные сибиряки – выпускники университета и меценаты. Скульптура украсила рощу в 2018 году. У этого памятника есть название – <b>профессора Флоринский и Менделеев обсуждают проект Первого Сибирского университета.</b>",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUTmNZAAHxV7Jc6CzRhmpZbEjhR5I8JwAC1L4xG3hsyEqTfwABDNR6MsEBAAMCAAN5AAMqBA"}
                        }
                    }
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
            new() {AttachedStage = stage10, Payload = step43, Order = 1, Delay = 0 },
            new() {AttachedStage = stage10, Payload = step44, Order = 2, Delay = 0 },
            new() {AttachedStage = stage10, Payload = step45, Order = 3, Delay = 0 },
        };
        stage10.Steps = order10;
        return stage10;
    }

    public static Stage CreateStage_BTU_11()
    {
        // прогуляйся по университетской роще
        var step47 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Прогуляйся по университетской роще, подыши чистым воздухом, послушай пение птиц.\n\nКак дойдешь до главного корпуса Томского государственного университета, скажи.",
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
            new() {AttachedStage = stage11, Payload = step47, Order = 1, Delay = 0 },

        };
        stage11.Steps = order11;
        return stage11;
    }

    public static Stage CreateStage_BTU_12()
    {
        // первый универ сибири
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
                            Caption = "Предлагаю походить возле или вокруг корпуса.\nА пока ходишь-бродишь, я расскажу тебе немного про историю вуза.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUUGNZATciAlWknbw6ktgSoYUTmctbAALVvjEbeGzISg9D_vwuXzGTAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUUmNZAXcrGjOJ3FN5F-nXPLsRz6K_AAIiIgACeGzISizoKc1mcyuSKgQ" }
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
        //дай знать как закончишь
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
                        new() {AttachedStage = stage12, Payload = step46, Order = 1, Delay = 0 },
            new() {AttachedStage = stage12, Payload = step48, Order = 2, Delay = 0 },
            new() {AttachedStage = stage12, Payload = step49, Order = 3, Delay = 0 },
            new() {AttachedStage = stage12, Payload = step50, Order = 4, Delay = 0 },
        };
        stage12.Steps = order12;
        return stage12;

    }

    public static Stage CreateStage_BTU_13()
    {
        // сейчасмы с тобой выйдем
        var step51 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Сейчас мы с тобой выйдем на проспект Ленина и двинемся в сторону еще одного университета, который появился благодаря ТГУ.\n\nНо об этом я расскажу чуть позже.",
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
                            Caption = "А пока выходи через главные ворота ТГУ, поворачивай налево и иди вдоль ограды.\n\n<b>Но только выходи через боковые калитки!</b>\n\nСтуденты говорят, что выходить через центральные ворота – плохая примета!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUVGNZAbqULbxvTO1sHP-2DmG9Pw1xAALYvjEbeGzISqNNaBBpPgivAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        // мало кто знает
        var step53 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Мало кто знает, что эта пешеходная часть проспекта Ленина <b>неофициально называется Александровским бульваром</b>.\n\nТак аллею назвали в память о трех императорах: Александре I, Александре II и Александре III.Именно благодаря им и появился первый в Сибири университет.",
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
                            Caption = "Идем дальше? Сейчас тебе нужно дойти до конца Александровского бульвара. Там ты увидишь корпус третьего на нашем маршруте университета.\n\nКак дойдешь, отпишись!",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUVmNZAmIF_MzjBQUyGyScZnMvZxlBAALavjEbeGzISv1CrbLmPYdlAQADAgADeQADKgQ"}
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
            new() {AttachedStage = stage13, Payload = step51, Order = 1, Delay = 0 },
            new() {AttachedStage = stage13, Payload = step52, Order = 2, Delay = 0 },
            new() {AttachedStage = stage13, Payload = step53, Order = 3, Delay = 0 },
            new() {AttachedStage = stage13, Payload = step54, Order = 4, Delay = 0 },
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
                            Caption = "В этом здании, построенном в 1892 году, располагаются факультетские клиники <a href=\"https://ssmu.ru/ru/\"><b>Сибирского государственного медицинского университета</b></a>. Это настоящий многопрофильный специализированный клинический комплекс, где лечат больных.\n\nПредлагаю послушать историю факультетских клиник и прогуляться вдоль корпуса до перекрестка.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUWGNZAn5IG31Cmbt15QjT3i49UV5EAALbvjEbeGzISvS8YSq9y8EtAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUWmNZAy-4ORbaq33RqVxM0RarnP51AAI6IgACeGzISvy4gwR9ah01KgQ" }
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
                            Caption = "Идем дальше?\n\nПоворачивай налево на перекрестке и дойди до <b>главного корпуса  Сибирского государственного медицинского университета.</b>",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUXGNZA3y0XnR9VeMGIqZypyuxVmtpAALdvjEbeGzISuLsfGaywe6zAQADAgADeQADKgQ"}
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
                Address = "пр. Ленина, 38, Факультетские клиники СибГМУ"
            },
        };
        var order14 = new List<StepInStage>()
        {
            new() {AttachedStage = stage14, Payload = step55, Order = 1, Delay = 0 },
            new() {AttachedStage = stage14, Payload = step56, Order = 2, Delay = 0 },
            new() {AttachedStage = stage14, Payload = step57, Order = 3, Delay = 0 },
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
                            Caption = "Перед тобой <b>главный корпус</b> одного из старейших и наиболее авторитетных российских медицинских вузов – <b>СибГМУ.</b>",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUXmNZA9O8O5-cockE61hE8l315ywiAALkvjEbeGzISkRg_MVREtWYAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUYGNZA_5n-HORzKEXD46BNWJssD3HAAJAIgACeGzISpzhSieGZeCfKgQ" }
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
        // тебе нужно вернуться
        var step60 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Тебе нужно вернуться на проспект Ленина и перейти по пешеходному переходу со светофором на другую сторону.\n\nМы — <b>на площади Ново-Соборной.</b> Обрати внимание на здание на углу площади и проспекта Ленина.",
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
                            Caption = "Это, между прочим, одно из старейших зданий города!\n\nПостроено двухэтажное кирпичное здание в стиле классицизма в 1842 году. До 1919 года в нем располагалось губернское управление, затем – органы советской власти. А в 1928 году его передали Сибирскому физико-техническому институту, основанному, кстати, на базе Института прикладной физики Томского технологического института (ныне ТПУ).",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUYmNZBDwGn4D-B735GWtdKUPMQ-KPAALovjEbeGzISt-uyjHqtTYaAQADAgADeQADKgQ"}
                        }
                    }
                }
            }
        };
        //а сейчас поворачивай налево
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
            new() {AttachedStage = stage15, Payload = step58, Order = 1, Delay = 0 },
            new() {AttachedStage = stage15, Payload = step59, Order = 2, Delay = 0 },
            new() {AttachedStage = stage15, Payload = step60, Order = 3, Delay = 0 },
            new() {AttachedStage = stage15, Payload = step61, Order = 4, Delay = 0 },
            new() {AttachedStage = stage15, Payload = step62, Order = 5, Delay = 0 },
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
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUZGNZBH2y-3S7cAABEdTmXP-Kbd1yXAAC6b4xG3hsyEqeLU2E0x2okwEAAwIAA3kAAyoE"}
                        }
                    }
                }
            }
        };
        // есть в томске ещё одно место
        var step64 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Есть в Томске еще одно место, куда студенты приходят перед важными учебными делами и просят помощи и удачи.\n<b>Это памятник Святой Татьяне.</b>\n\nПо поверью, Святая Татьяна была покровительницей всех учащихся и студентов. Она помогала «грызть гранит науки», хорошо учиться и сдавать экзамены.\n\nСтуденты Томска не забывают свою покровительницу: зимой, в самые морозы, они «утепляют» Татьяну, одевая ее в шарф и шапку. <b>Обязательно сделай с Татьяной фото на память!</b>",
                }
            }
        };
        // ну а сейчас я тебе покажу
        var step65 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Ну а сейчас я покажу тебе самый молодой университет Томска.\nВозвращайся к фонтану и посмотри на противоположную сторону проспекта Ленина. ",
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
            new() {AttachedStage = stage16, Payload = step63, Order = 1, Delay = 0 },
            new() {AttachedStage = stage16, Payload = step64, Order = 2, Delay = 0 },
            new() {AttachedStage = stage16, Payload = step65, Order = 3, Delay = 0 },
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
                            Caption = "Ты видишь перед собой <a href=\"https://tusur.ru/\"><b>главный корпус Томского государственного университета систем управления и радиоэлектроники</b></a> (ТУСУР).\n\nЭто здание с монументальными колоннами известно многим, так как находится напротив главной площади Томска. Но не все знают, что изначально оно было в два раза меньше, никаких колонн вообще не было!\n\nДа и вообще у этого здания очень длинная и богатая история, в которой нашлось место и железной дороге, и погрому, и электронике.",
                            Type = MediaType.Photo,
                            Photo = new() {FileId = "AgACAgIAAxkBAAIUamNZBZqYnVql50KWAeg11EWIfwQGAALyvjEbeGzISrXNZe9vTDcvAQADAgADeQADKgQ"}
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
                                Audio = new(){ FileId = "CQACAgIAAxkBAAIUZmNZBXAC6R3skgj2f7ejlkaAyIp6AAJMIgACeGzISqCbuA0KnJuLKgQ" }
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
        // у студентов тусура
        var step68 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "У студентов ТУСУРа есть <i>необычная традиция</i>.\n\nКаждый год в День радио, 7 мая, они выкидывают из окон общежития радиотехнического факультета старые телевизоры и другую неработающую технику. Это очень эффектное зрелище!\n\nТрадиция зародилась в 1988 году – с тех пор студенты разбивают старые телевизоры в ознаменование победы технического прогресса. Технический мусор после выбрасывания университет передает на переработку.",
                }
            }
        };
        // мы с тобой можем двигаться дальше
        var step69 = new Step()
        {
            Fragments = new()
            {
                new Fragment()
                {
                    Type = FragmentType.Text,
                    Text = "Мы с тобой можем двигаться дальше.\n\nПредлагаю тебе подойти на остановку и ждать маршрутку. Тебе подойдет любой автобус, который идет в сторону Белого озера: <b>23, 33, 26, 130, 1, 3 троллейбусы</b> и другие.\n\n<i>Выйти нужно на остановке ТГАСУ.</i>",
                    Buttons = new(){new(){Type=ButtonType.KeyboardTransition, Label="🚌 Поеду", Target = new(){Name="stage=btu_18_1"}},new() { Type = ButtonType.KeyboardTransition, Label = "🚶‍♂️ Пойду", Target = new() { Name = "stage=btu_18_2" } } }
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
            new() {AttachedStage = stage17, Payload = step66, Order = 1, Delay = 0 },
            new() {AttachedStage = stage17, Payload = step67, Order = 2, Delay = 0 },
            new() {AttachedStage = stage17, Payload = step68, Order = 3, Delay = 0 },
            new() {AttachedStage = stage17, Payload = step69, Order = 4, Delay = 0 },
        };
        stage17.Steps = order17;
        return stage17;
    }

    //кратное оформление**
    // да поеду
    public static Stage CreateStage_BTU_18_1()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXfmNZyHEo9NWzbDjLdpaaxTr7Yu1WAAI2wzEb6jTRSooNO1WDipMCAQADAgADeQADKgQ"}, Caption ="Лови транспорт, устраивайся поудобнее и слушай историю создания томского центра подготовки инженеров-строителей и архитекторов."}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Type = MediaType.Sound, Sound = new() { Type = SoundType.Audio, Audio = new() { FileId = "CQACAgIAAxkBAAIXfGNZx7jFl9bzFRQbYYwq6S8hL0zQAAJXJgAC6jTRStuJoc4aw8w9KgQ" } } } }, Buttons = new() { new Button() { Type = ButtonType.InlineLink, Link = "https://telegra.ph/Istoriya-TGASU-10-26", Label = "Расшифровка" } } } }
        };

        var stage = new Stage()
        {
            Name = "btu_18_1",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    //нет
    public static Stage CreateStage_BTU_18_2()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXgGNZyukbJ7c1LkTVKBbqScC9AAEQ1wACOMMxG-o00Ur37WaEbCUEeAEAAwIAA3kAAyoE"}, Caption ="А вот такая дорога у нас пешком."}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Type = MediaType.Sound, Caption = "Можешь послушать историю создания томского центра подготовки инженеров-строителей и архитекторов.", Sound = new() { Type = SoundType.Audio, Audio = new() { FileId = "CQACAgIAAxkBAAIXgmNZywkoeJof6H-nffb5wCWQNMmlAAJaJgAC6jTRSjfiv1fEiM1HKgQ" } } } }, Buttons = new() { new Button() { Type = ButtonType.InlineLink, Link = "https://telegra.ph/Istoriya-TGASU-10-26", Label = "Расшифровка" } } } }
        };

        var stage = new Stage()
        {
            Name = "btu_18_2",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    //реклама
    public static Stage CreateStage_BTU_18_a()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXhmNZy6AYt1tDORF-51QHjKKR4u11AAI5wzEb6jTRSpub_QIsZa1gAQADAgADeQADKgQ"}, Caption ="А чтобы не устать от новых знаний, предлагаю зайти перекусить по пути!\n\nЕсли любишь пиццу — загляни в <a href=\"https://makelovepizza.ru/tomsk\"><b>“Make Love Pizza”</b></a>. на ​пр. Ленина, 85а. Это кайфовая доставка пиццы и уютные кафешки. Они живут под лозунгом: Кайф! Драйв! Рок - н - ролл! Забегай туда на любимую пиццку или просто послушать винильчик под чашку фильтра.\n\nРебята называют проспект Ленина проспектом Леннона и в своем подвальчике на Леннона проводят вечеринки, тусы, концерты и другие сборища. Шепни, что ты <i>«от Ефима»</i>, и хозяева угостят тебя чашечкой фильтра при любом заказе."}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXiGNZzGyCK64g1nX6TzFpG31L4YXsAAI9wzEb6jTRStPiLFI1JN0LAQADAgADeQADKgQ"}, Caption ="А второе место – для сладкоежек и любителей кофе.\n\nЭто кондитерская <a href=\"https://torta-torta.ru/\"><b>TORTA</b></a> на Набережной реки Ушайки, 16. Всего в городе 4 таких заведения, но это знаменито своим акцентом на историю Томска. Здесь и карта города, и эксклюзивные открытки и главное — фирменный торт «Томск»! Интересно, почему до сих пор не придумали торт «Студенческий»?\n\nКроме десертов, у Торты есть завтраки в кондитерской по адресу Фрунзе, 98. Пышные панкейки, сендвичи и многое другое:) А специально для тебя Торта <b>дарит скидку 30%</b> на все кофейные напитки. Просто скажи на баре, что ты <i>«от Ефима»</i>. Заходи и пробуй :)"}}}}
        };

        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Ещё ты можешь заглянуть в интересное место – <a href=\"https://slav-museum.ru/\"><b>Первый музей славянской мифологии</b></a> на <i>улице Загорной, 12</i>.\n\nИнтересные выставки расскажут об истории, культуре, традициях и обычаях нашей страны. А в большом магазине сувениров чего только нет! ",
            }}
        };


        var stage = new Stage()
        {
            Name = "btu_18_a",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    // на площади соляной
    public static Stage CreateStage_BTU_19()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Мы добрались!\n\nИсторию строительного университета ты уже знаешь. Предлагаю познакомиться с корпусами вуза. Они, кстати, тоже исторические и являются памятниками архитектуры.\n\n<i>Переходи на противоположную сторону улицы и двигайся в сторону второго корпуса ТГАСУ (пл. Соляная, 2, кор. 2)</i>",
            }}
        };

        var stage = new Stage()
        {
            Name = "btu_19",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Latitude = 56.496154,
                Longitude = 84.960206,
            },
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_BTU_20()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXimNZ15pKKO6I-WFjGl_v5TcyBgABhQACPsMxG-o00UpdMgdnJyPDtQEAAwIAA3kAAyoE"}, Caption ="<a href=\"https://tsuab.ru/\"><b>Второй корпус ТГАСУ</b></a>, или, как еще его называют, <b>«красный корпус»</b> – памятник истории и архитектуры Томска.\n\nЗданию почти 120 лет. Построил корпус из красного кирпича талантливый архитектор Константин Лыгин для первого в Сибири коммерческого училища."}},
            }}
        };

        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXjGNZ2Lvz-moIGIcygVB5nQzzp3q9AAI_wzEb6jTRSm7bx--tiRVIAQADAgADeQADKgQ"}, Caption ="Во внутреннем дворике между корпусами вуза есть интересная локация – <i>Место силы креативных индустрий</i>.\n\nЭто локация в большей степени для творческих людей, где они могут встречаться, обмениваться идеями, проводить презентации, выставки и другие мероприятия. Но площадка используется пока только в теплое время года."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "btu_20",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 10,
                Latitude = 56.496946,
                Longitude = 84.957289,
                Label = "2-й корпус ТГАСУ",
                Address = "пл. Соляная, 2, к. 2"
            },
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_BTU_21()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXjmNZ2hEmmhNei3pQu8FOaf22BYULAAJAwzEb6jTRSkPjzwbniDdrAQADAgADeQADKgQ"}, Caption ="Рядом с краснокирпичным творением Лыгина обрати внимание на еще один корпус ТГАСУ. Здание, достроенное в 1937 году, выполнено <i>в абсолютно другом стиле – постконструктивизма</i>"}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Строили его для общежития мукомольно-элеваторного института.\n\nПо проекту здание состояло из общежития, 16-квартирного жилого корпуса для преподавателей и столовой. По городской легенде считается, что на стройке использовали кирпич, оставшийся после сноса в 1934 году крупнейшего храма Томска, – Троицкого кафедрального собора. Он стоял на знакомой тебе Ново-Соборной площади.\n\nВ 1952 году общежитие передали строительному институту.",
            }}
        };

        var stage = new Stage()
        {
            Name = "btu_21",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 12,
                Latitude = 56.49595,
                Longitude = 84.958591,
                Label = "3-й корпус ТГАСУ",
                Address = "пл. Соляная, 3"
            },
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_BTU_22()
    {

        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Итак, со строителями разобрались. У нас с тобой остался последний вуз, о котором я хочу рассказать. Придется еще немного покататься на автобусах.",
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXkmNZ3FYeJb-5krfqRvwqqLnGRBwUAAJCwzEb6jTRSsy_sdKRqxqVAQADAgADeQADKgQ"}, Caption ="Дойди до остановки «ТГАСУ» у «красного корпуса» и дождись <b>автобус № 8</b>. <i>Тебе нужно доехать до остановки «Киевская».</i>"}},
            }}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Caption = "А пока ты едешь, я расскажу тебе историю создания <b>первого педагогического вуза за Уралом</b>.", Type = MediaType.Sound, Sound = new() { Type = SoundType.Audio, Audio = new() { FileId = "CQACAgIAAxkBAAIXkGNZ2-txCbvceEzQY3lIZjbj_2yAAAJdJgAC6jTRSiEgzfOlTirMKgQ" } } } }, Buttons = new() { new Button() { Type = ButtonType.InlineLink, Link = "https://telegra.ph/Istoriya-TGPU-10-27", Label = "Расшифровка" } } } }
        };

        var stage = new Stage()
        {
            Name = "btu_22",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_BTU_23()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXlGNZ3XRlVgABlXdaeWKpOuCKOzmKdwACQ8MxG-o00UoQG3uU3m7czgEAAwIAA3kAAyoE"}, Caption ="На остановке поверни налево и двигайся в сторону улицы Киевской. Пройди по ней до улицы Герцена и сверни направо."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "btu_23",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Latitude = 56.476098,
                Longitude = 84.97608,
                Label = "Остановка Киевская",
                Address = "пересечении ул. Киевской и пр. Фрунзе"
            },
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_BTU_24()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIXlmNZ3iNFage8yVf6wG9Qm3BE16arAAJEwzEb6jTRSnwXYkdjEVQvAQADAgADeQADKgQ"}, Caption ="Вот и он – <a href=\"https://www.tspu.edu.ru/\"><b>главный корпуса «педа»</b></a>!"}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Ну, вот и все!\n\nТы узнал чуть больше об истории возникновения всех высших учебных заведений Томска и зданиях-памятниках, с ними связанных. Ты – герой!\n\nНадеюсь, было интересно и предлагаю посмотреть другие маршруты :)",
            }}
        };

        var stage = new Stage()
        {
            Name = "btu_24",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Number = 0,
                Latitude = 56.475011,
                Longitude = 84.975884,
                Label = "Главный корпус ТГПУ",
                Address = "ул.  Киевская, 60а"
            },
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

}

// public static Stage CreateStage_BTU_18()
// {
//     var step = new Step()
//     {
//         Fragments = new() { new() { Type = FragmentType.Media,
//             Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
//             }}
//     };
//     var step = new Step()
//     {
//         Fragments = new() { new() { Type = FragmentType.Text, Text = "",
//             }}
//     };
//     var step = new Step()
//     {
//         Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Type = MediaType.Sound, Sound = new() { Type = SoundType.Audio, Audio = new() { FileId = "" } } } }, Buttons = new() { new Button() { Type = ButtonType.InlineLink, Link = "", Label = "Расшифровка" } } } }
//     };

//     var stage = new Stage()
//     {
//         Name = "btu_",
//         Type = StageType.Regular,
//         Location = new Spot()
//         {
//             Number = 0,
//             Latitude = 56.,
//             Longitude = 84.,
//             Label = "П",
//             Address = ""
//         },
//     };
//     var order = new List<StepInStage>()
//         {
//             new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
//         };
//     stage.Steps = order;
//     return stage;
// }
