using System.Text.RegularExpressions;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class MUR
{
    public static Route CreateRoute_MMUR()
    {
        var stage1 = CreateStage_MUR_1();
        var stage2 = CreateStage_MUR_2();
        var stage3 = CreateStage_MUR_3();
        var stage4 = CreateStage_MUR_4();
        var stage5 = CreateStage_MUR_5();
        var stage6 = CreateStage_MUR_6();
        var stage7 = CreateStage_MUR_7();
        var stage8 = CreateStage_MUR_8();
        var stage9 = CreateStage_MUR_9();
        var stage9_1 = CreateStage_MUR_9_1();
        var stage10 = CreateStage_MUR_10();
        var stage10_1 = CreateStage_MUR_10_1();
        var stage11 = CreateStage_MUR_11();
        var stage12 = CreateStage_MUR_12();
        var stage13 = CreateStage_MUR_13();
        var stage14 = CreateStage_MUR_14();
        var stage15 = CreateStage_MUR_15();
        var stage16 = CreateStage_MUR_16();
        var stage17 = CreateStage_MUR_17();
        var stage18 = CreateStage_MUR_18();
        var stage19 = CreateStage_MUR_19();
        var stage20 = CreateStage_MUR_20();
        var stage21 = CreateStage_MUR_21();
        var stage22 = CreateStage_MUR_22();
        var stage23 = CreateStage_MUR_23();
        var stage24 = CreateStage_MUR_24();
        var stage25_1 = CreateStage_MUR_25_1();
        var stage25_2 = CreateStage_MUR_25_2();
        var stage25_3 = CreateStage_MUR_25_3();
        var stage26 = CreateStage_MUR_26();
        var stage27 = CreateStage_MUR_27();
        var stage28 = CreateStage_MUR_28();
        var stage29 = CreateStage_MUR_29();
        var stage30 = CreateStage_MUR_30();
        var stage31 = CreateStage_MUR_31();

        var route = new Route()
        {
            Name = "mur",
            Label = "🔶 Муралы. Граффити. Заплатки.",
            Description = "Здесь я покажу тебе, в каких местах Томска можно найти уличное искусство. \nОт огромной надписи на стене библиотеки, до крошечных арт - заплаток, от нелегальных муралов, до наследия фестивалей. \nХочу, чтобы ты полюбил это новое искусство в старинном городе также, как и я.",
            InitialStage = stage1
        };

        var stages = new List<StageSequence>()
        {
            new() {AttachedRoute = route, From = stage1, To = stage2},
            new() {AttachedRoute = route, From = stage2, To = stage3},
            new() {AttachedRoute = route, From = stage3, To = stage4},
            new() {AttachedRoute = route, From = stage4, To = stage5},
            new() {AttachedRoute = route, From = stage5, To = stage6},
            new() {AttachedRoute = route, From = stage6, To = stage7},
            new() {AttachedRoute = route, From = stage7, To = stage8},
            new() {AttachedRoute = route, From = stage8, To = stage9},
            new() {AttachedRoute = route, From = stage9, To = stage9_1},
            new() {AttachedRoute = route, From = stage9_1, To = stage10},
            new() {AttachedRoute = route, From = stage10, To = stage10_1},
            new() {AttachedRoute = route, From = stage10_1, To = stage11},
            new() {AttachedRoute = route, From = stage11, To = stage12},
            new() {AttachedRoute = route, From = stage12, To = stage13},
            new() {AttachedRoute = route, From = stage13, To = stage14},
            new() {AttachedRoute = route, From = stage14, To = stage15},
            new() {AttachedRoute = route, From = stage15, To = stage16},
            new() {AttachedRoute = route, From = stage16, To = stage17},
            new() {AttachedRoute = route, From = stage17, To = stage18},
            new() {AttachedRoute = route, From = stage18, To = stage19},
            new() {AttachedRoute = route, From = stage19, To = stage20},
            new() {AttachedRoute = route, From = stage20, To = stage21},
            new() {AttachedRoute = route, From = stage21, To = stage22},
            new() {AttachedRoute = route, From = stage22, To = stage23},
            new() {AttachedRoute = route, From = stage23, To = stage24},
            new() {AttachedRoute = route, From = stage24, To = stage25_1},
            new() {AttachedRoute = route, From = stage25_1, To = stage25_2},
            new() {AttachedRoute = route, From = stage25_2, To = stage25_3},
            new() {AttachedRoute = route, From = stage25_3, To = stage26},
            new() {AttachedRoute = route, From = stage26, To = stage27},
            new() {AttachedRoute = route, From = stage27, To = stage28},
            new() {AttachedRoute = route, From = stage28, To = stage29},
            new() {AttachedRoute = route, From = stage29, To = stage30},
            new() {AttachedRoute = route, From = stage30, To = stage31},
        };
        route.Stages = stages;
        return route;
    }

    public static Stage CreateStage_MUR_0()
    {

        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOtWNW-p4X_6_FkrgJOjCnDsg6SP-QAAKywzEbhDm4Sqp26tGNxR_eAQADAgADeQADKgQ"}, Caption ="«Муралы, граффити, заплатки» – это прогулка, во время которой покажу тебе уличное искусство Томска. От огромной надписи на стене библиотеки до крошечных арт-заплаток на тротуарах, от нелегальных муралов до основательных арт-консерваций. Это очень разные авторы и работы. Но объединяет их одно – желание оставить свой след в городе, поговорить с нами о том, что их волнует, что они любят, что хотят сохранить. И, конечно, дух свободы, без которого не бывает уличного искусства. Мы с тобой увидим работы, появившиеся не только после больших фестивалей, но и в результате бунтарских захватов/вторжений. Мне очень хочется, чтобы ты полюбил это новое искусство в нашем старинном городе так же, как и я!"}}}}
        };
        var step6 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Фишка бота – возможность делиться геопозицией и получать информацию сразу по прибытию. Для этого нужно поделиться геопозицией и выбрать режим «Трансляция», но это необязательно!",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step7 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Можно по-разному относиться к уличному искусству, но это важная часть жизни города. Мне кажется, нельзя понять Томск по-настоящему, если игнорировать стрит-арт. На этой прогулке нам с тобой придется часто куда-то сворачивать, искать объекты в арках, закоулках, внимательно смотреть под ноги. Давай будем гулять в светлое время суток! Выбери день с хорошей погодой. Возьми с собой наушники и бутылку воды. И не забудь внимательно изучить карту – нам многое с тобой предстоит увидеть! Как будешь на месте, дай мне знать.",
           }}
        };

        var stage = new Stage()
        {
            Name = "mur_0",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step5, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step6, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step7, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_1()
    {
        var step10_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOuWNW_489odLsB8K7rsLGIvaVszRbAAK9wzEbhDm4SsDvCtXKGBYYAQADAgADeQADKgQ"}, Caption ="Помнишь, как в 2016 году мир накрыла покемономания?! Миллионы людей тогда вышли на улицы искать и ловить покемонов в игре Pokémon Go. Не обошло это увлечение стороной и Томск."}},
            }}
        };
        var step10_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "На старой будке ты видишь Пикачу, со знакомства с ним мы и начнем наше путешествие. Но искать отправимся не покемонов, а уличное искусство. А оно часто анонимно. Кстати, имя художника, нарисовавшего Пикачу, тоже неизвестно. Автор может оставить у рисунка свой тэг – это подпись граффити-художника. Правда, если ты мало интересуешься темой, этот тэг тебе мало поможет. Но сейчас многие граффитисты перестали скрывать лица и свои работы открыто публикуют в соцсетях. Поэтому в некоторых локациях на нашем маршруте ты сможешь узнать об авторах работ!",
            }}
        };
        var step11 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOu2NW_9dp3-ITcAdiRv0tgoupgXXpAALAwzEbhDm4SgnOfDM2lgVtAQADAgADeQADKgQ"}, Caption ="Сейчас я пришлю тебе маршрут до следующей точки. Следуй согласно карте и не забывай посматривать под ноги!"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_1",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.465198,
                Longitude = 84.952417,
                Label = "Pokemon GO",
                Address = "Двор здания ул. Усова, 4а / ул. Советская, 73 с1",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step10_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step10_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step11, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_2()
    {
        var step12_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQamNXZDXX0l-m_rUop9WrAyAZwo7lAAIMvDEbhDnASiFOQH1PzQdJAQADAgADeQADKgQ"}, Caption ="Если встать рядом с памятником Кирову и смотреть в том же направлении, что и он, то слева ты увидишь огромные буквы на стене библиотеки Томского государственного университета."}}}}
        };
        var step12_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Надпись гласит: «Мы – буквы, с нами текст». Это самая масштабная текстовая стрит-арт работа в Томске. Создал ее художник Владимир Абих для фестиваля «мУкА. Склады искусства». Это арт-фестиваль в Томске, объединяющий современное искусство и культурное наследие.",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = "http://muka_artfestival.tilda.ws/muka_2021", Label = "🍞 Подробнее"} } }}
        };
        var step12_3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIOvWNXA7Cl7gEqk6nJgCzFPFlGtqp2AAJrDAACitq4Ur22_qG5-SIHKgQ"}}}}}}
        };
        var step12_4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOv2NXBBKT5aQaYMFYRLIv_bNaZnqTAALCwzEbhDm4Su_7T_UMZPOUAQADAgADeQADKgQ"}, Caption ="Следуй дальше до указанной точки, внимательно переходи через пешеходный переход!"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_2",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.466282,
                Longitude = 84.950970,
                Label = "Обзорная точка – «Мы – буквы. С нами текст»",
                Address = "пр. Ленина, начало аллеи Геологов",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step12_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step12_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step12_3, Order = 3, Delay = 0 },
            new() {AttachedStage = stage, Payload = step12_4, Order = 4, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_3()
    {
        var step13 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOx2NXCWjixeT4mCctYU5YXe3CSDSfAALFwzEbhDm4Skofz6nswBAgAQADAgADeQADKgQ"}, Caption ="Мы стоим у дома на ул. Кузнецова, 33. Этот «бедолага» сильно пострадал из-за строительства соседних кирпичных домов – у него треснул фундамент. Дом начал проседать. Жить в нем стало опасно, жильцов расселили, а особняк законсервировали."}}
            }}
        };
        var step13_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIOxWNXCRzypl0o61tvZ-1nMzk9oSNJAAK7DQACitq4UkcnLph6qhGtKgQ"}}}},
            }}
        };
        var step14 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIOwWNXCBdYy9CPd6-vlVe9HEjXG9CPAALDwzEbhDm4SuBIX4fpg_Y2AQADAgADeQADKgQ"}, Caption ="Мы совсем рядом, аккуратно перейди дорогу, смотри по сторонам."}}}}
        };


        var stage = new Stage()
        {
            Name = "mur_3",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.467314,
                Longitude = 84.954798,
                Label = "Жесть-арт",
                Address = "ул. Кузнецова, 33",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step13, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step13_1, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step14, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_4()
    {
        var step15_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQbGNXba3-KLi2jlUqi72pCokkNfj3AAIpvDEbhDnASqb1QV9ub5DSAQADAgADeQADKgQ"}, Caption ="Я тебя уже предупреждал, что надо быть внимательнее! Сейчас наблюдательность тебе пригодится. Мы должны найти арт-заплатку – маленький керамический кругляш с изображением значка ГТО. Он прячется за деревьями у проезжей части между домами по Кузнецова, 29 и 31."}},
            }}
        };
        var step15_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQbmNXbhT-OmOJ-0IQ4YLhIlxV78LRAAK3GQACitq4UjQPM7Rbyb8yKgQ"}}, Caption ="Нашел? Уверен, что у тебя возник вопрос: «А что это вообще такое? Зачем?»."}},
            }}
        };
        var step16 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQcGNXbnqZpmzBzvlYNby6FYbMB9S0AAIqvDEbhDnASiQ_7t7pFcc-AQADAgADeQADKgQ"}}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_4",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.467646,
                Longitude = 84.9549650,
                Label = "Арт-заплатка «Значок ГТО»",
                Address = "ул. Кузнецова, 30; возле Профессорской квартиры",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step15_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step15_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step16, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_5()
    {
        var step17_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQdGNXb1SJM0YfgB2-U57uK4h13ODrAAIsvDEbhDnASjdtxfhJUdC8AQADAgADeQADKgQ"}, Caption="Вообще-то, здесь два самолетика, но не все могут найти оба. Попробуешь?"}},
            }}
        };
        var step17_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQcmNXbyvEDETdoWf2-ZkWHzbykbwFAAIrvDEbhDnAStXp82q-HCWwAQADAgADeQADKgQ"}, Caption="Самолетики тоже относятся к маршруту «Спортивная история Томска: от ипподрома до Дворца спорта». Более подробно историю, связанную с ГТО и спортом в СССР, ты можешь послушать <b> <a href=\"https://www.izi.travel/ru/c203-gorodskoy-marshrut-sportivnaya-istoriya-tomska-ot-ippodroma-do-dvorca-sporta/ru#b8e228ec-343d-494e-9b55-3ced80e6c1ac\">вот здесь</a></b>"}},
            }}
        };
        var step18 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQdmNXcCJGEn3H5Z-Uoq1VqIZSZAtOAAItvDEbhDnASgQRAz59mAwIAQADAgADeQADKgQ"}, Caption ="Теперь я покажу тебе, что из себя представляют споты граффити-художников, движемся по маршруту дальше."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_5",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.468267,
                Longitude = 84.955141,
                Label = "Арт-заплатка «Самолёт»",
                Address = "ул. Кузнецова, 26, Физиопульпонологический медцентр",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step17_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step17_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step18, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_6()
    {
        var step19 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQeGNXcRBnV_y8Jqtvb_HUcOILuwcjAAIwGgACitq4Unv2ShJTB7v9KgQ"}}, Caption ="Вот мы и дошли с тобой до первого спота в нашем маршруте.\nКогда говорят про уличное искусство, то чаще всего сразу представляют муралы – большие и красивые картины на стенах. Но если ты спросишь граффити-художников, то они скажут, что первое, с чего начинается настоящая уличная художественная интервенция или захват пространства – это именно спот. Место, где много нелегальных работ, где все могут перекрасить друг друга без разрешения."}},
            }}
        };
        var step20 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQemNXcVO-a9pLK593jx6VaJc-8EkJAAIuvDEbhDnASs25J7likGM-AQADAgADeQADKgQ"}, Caption ="Познакомились с нелегальными работами, пойдем посмотрим на легальную."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_6",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.468267,
                Longitude = 84.9551410,
                Label = "Граффити-спот",
                Address = "ул. Советская, 51, у котельной",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step19, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step20, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_7()
    {
        var step21 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQfGNXdXMSmZgUek1ryPRawMkR66e0AAI1vDEbhDnASlKjbJXKLGHaAQADAgADeQADKgQ"}, Caption ="Ты задумывался о том, кто платит за красивые муралы на стенах? И как они вообще появляются в городе? Тут есть несколько вариантов. Например, художник может объявить о сборе денег и сделать нелегальную работу при помощи фанатов. А может участвовать в фестивалях или брать коммерческие заказы."}},
            }}
        };
        var step21_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQfmNXdaQE3cmCuzj4jkYXfDJXL9pMAALaGgACitq4UtPjnoyZGkK1KgQ"}}}},
            }}
        };
        var step22 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQgGNXddknEaWvGAfDlvJqw856UJrcAAI2vDEbhDnASsOE0lGcuhWrAQADAgADeQADKgQ"}, Caption ="Сейчас у нас будет большой переход от одного места к другому, ты можешь и самостоятельно выбрать, как до него добраться, но я тебе предлагаю пойти вот так:"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_7",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.471675,
                Longitude = 84.951680,
                Label = "Река жизни",
                Address = "ул. Герцена, гостиница Бон Апарт",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step21, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step21_1, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step22, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_8()
    {
        var step23 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQgmNXdjbFpU0YutaKMlLvJKdC5iOzAAI3vDEbhDnASvSAzOZ8X3TFAQADAgADeQADKgQ"}, Caption ="Еще одно место, которое захватили граффити-художники. В 2021 году в течение суток здесь проходила нелегальная передвижная выставка «Сквозь дворы». Это кочующая по городам экспозиция и собрание творческих проектов. Как пишут ее организаторы, «Сквозь дворы» — это про свободу, про свободу во всем и для всех. Монстрика, которого ты видишь, рисовал Женя Борисов из LIMBO CREW – новосибирского тандема молодых художников."}},
            }}
        };
        var step24 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQhGNXdoO5LBMbCmazu7NqY5WZllB0AAI4vDEbhDnASjcmWujFdEE0AQADAgADeQADKgQ"}, Caption ="Теперь пойдем я покажу тебе чертика, не бойся он не живой. Идем, тут не далеко."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_8",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 56.476775,
                Longitude = 84.949194,
                Label = "Граффити-спот",
                Address = "пр. Ленина, 46",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step23, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step24, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_9()
    {
        var step25_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQiGNXeA8dqh5Bo24AAdfomRUc5IGigQACOrwxG4Q5wEp4vXRF1OsYHgEAAwIAA3kAAyoE"}, Caption ="Уличное искусство, как я уже говорил, недолговечно. Поэтому, если работа «живет» на стене больше 10 лет, это почти чудо!"}},
           }}
        };
        var step25_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQhmNXdwOgtZYBCIBY-h6W2TwV_j0GAAIGGwACitq4UpDxKNEtBHXzKgQ"}}, Caption ="Мне немного жаль, что в городе стало меньше озорства. Возможно, скоро новый уличный художник начнет заселять город своими персонажами."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_9",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Чертик»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step25_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step25_2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    public static Stage CreateStage_MUR_9_1()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQlGNXfIVqDM0kgzw1cJkHMm889bKOAAJBvDEbhDnASkwFdggCPqn9AQADAgADeQADKgQ"}, Caption ="Ты еще не проголодался? Повезло, что прямо по нашему маршруту – Make Love Pizza на проспекте Ленина, 85а."}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Это очень уютная пиццерия, главный девиз которой: «Кайф! Драйв! Рок-н-ролл!». Забежим к ним на пиццу или просто выпьем кофе под виниловые пластинки?",
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_9_1",
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

    public static Stage CreateStage_MUR_10()
    {
        var step26 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQlGNXfIVqDM0kgzw1cJkHMm889bKOAAJBvDEbhDnASkwFdggCPqn9AQADAgADeQADKgQ"}, Caption ="Обрати внимание на дизайн интерьера – какие картины нарисованы на стенах! И, кстати, в подвальчике Make Love Pizza проводят вечеринки, концерты и разные другие тусы. В общем, скучно тебе точно не будет. Если решишь забежать к моим друзьям, то они угостят тебя чашечкой фильтра при любом твоем заказе! <b>Промокод?</b>"}},
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_10",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Make Love Pizza",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step26, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_10_1()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Подкрепились и отдохнули? Давай-ка заглянем в арку возле входа в Make Love Pizza. Там нас с тобой ждет много интересного.",
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQl2NXftYJA43w-R2cZqKmPqUBUwYfAAJAvDEbhDnASkZ9j-OiemIuAQADAgADeQADKgQ"}, Caption ="Как будешь готов, пойдем дальше."}},
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_10_1",
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
    public static Stage CreateStage_MUR_11()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQmWNXfy0syorHolpKw8XpRTHJu1QVAAJMvDEbhDnASgpybf0NfruSAQADAgADeQADKgQ"}, Caption ="Бывает так, что свои следы в городе оставляют стрит-арт художники, приехавшие на «гастроли» или просто потусить.\nНапример, в 2016 году новосибирская команда «Так надо» придумала арт-экспедицию по городам Сибири, чтобы понять, а есть ли какой-то свой, сибирский, стиль у местных уличных художников? Свою арт-экспедицию они так и назвали – «Сибирский стиль». Приезжая в город, ребята знакомились с местными граффити-художниками, а еще искали спот для собственных работ.\nВ Томске они выбрали арку по проспекту Ленина, 85а. Сейчас сохранилась только одна такая работа, леттеринг «Томск», сделанная Мариной Ягодой и Иваном Fans. И она сейчас прямо перед тобой. "}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQo2NXhWSD1UX7XrSfyBViRJLOvJLSAAJnvDEbhDnASoyKr8JzBqjqAQADAgADeQADKgQ"}, Caption ="Проходим дальше."}},
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_11",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Леттеринг «Томск»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_12()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ5GNXiVevJ2cRcHBMNRcTU4CnjrmxAAJ9vDEbhDnASlz5CV_3-0CjAQADAgADeQADKgQ"}, Caption = "Теперь мы с тобой находимся во внутреннем дворе Make Love Pizza.\nИ тут, как ты видишь, все в фирменном стиле: мир, гармония и крутая музыка! И у себя во дворе ребята из пиццерии захотели показать наглядно, что их вдохновляют свобода и любовь."}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Ты видишь муралы, которые создал художник Роман Ткачев. Они отражают дух свободы не только конца 1960-х годов, но и современной молодежи. С фестиваля «Вудсток», группы «Битлз» и Джимми Хендрикса когда-то начинался новый мир! В общем, make love, слушай крутую музыку и ешь вкусную пиццу.",
            }}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ5mNXiduCAdceYiOe_PiFYerOkCcmAAKEvDEbhDnAShK50JnfF4tOAQADAgADeQADKgQ"}, Caption ="Идем, сейчас я тебе покажу, как можно вдохнуть жизнь в дома, которые покинули их жители. "}},
            }}
        };


        var stage = new Stage()
        {
            Name = "mur_12",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Woodstock»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_13()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ6GNXik1x7lgDI-t9lP-Wq3V6G0gPAAKGvDEbhDnASv96w6MthceuAQADAgADeQADKgQ"}, Caption ="В 2021 году активисты общественной организации «Центр сохранения исторического наследия» Светлана Савина и Ольга Павлова придумали проект «Вдохни жизнь в томские окна». Название говорит само за себя – смотреть на заколоченные окна законсервированных домов очень печально, хотелось хотя бы с помощью картинок вдохнуть в них жизнь! И привлечь внимание к проблеме сохранения деревянных домов в Томске. Ты видишь перед собой первый объект проекта – двухэтажный дом на улице Гагарина, 33. В его окнах: трогательные сцены из повседневной жизни, такие уютные, словно из детства. Эскизы разработали дизайнер Павел Богданов и художница Анна Турченко, а нарисовали волонтеры проекта. "}},
            }}
        };
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ6mNXinuw0sAS2TjLgUtoXkZMVr0zAAKHvDEbhDnASu5bAAG3G6ciPQEAAwIAA3kAAyoE"}, Caption ="Сейчас у нас будет еще одна небольшая прогулка до следующего места, следуй маршруту."}},
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_13",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Окна моего детства",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_14()
    {
        var step33_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Думаю, ты уже понял, что городское искусство – это не только «пачкание» стен и развлечение, но и возможность привлечь внимание к проблемам сохранения культурного наследия.",
            }}
        };
        var step33_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ7GNXjCb-zW-T4XnZRde8vjKZnDoLAAKNvDEbhDnASo2yE8P6wvymAQADAgADeQADKgQ"}, Caption ="Перед тобой еще один вариант – в 2021 году Владимир Абих во время фестиваля «мУкА. Склады искусства» создал не только масштабную работу на стене «научки» ТГУ, но и выполнил собственную культурную интервенцию. У Владимира есть проект «Субтитры». Он рисует на заброшенных объектах – домах, стадионах, концертных площадках. В Томске частью проекта стал давно заброшенный деревянный дом на улице Советской, 19. На нем появилась надпись «Пошел по наклонной»."}},
            }}
        };
        var step34_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ7mNXjHulp60n-_hDInUKxQwqlInyAAKOvDEbhDnASsWREhj4HQ0YAQADAgADeQADKgQ"}, Caption ="Пройди немного вперед…"}},
            }}
        };
        var step34_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ8GNXjMGDpDuO2Lf5hYLwtti9WrVqAAKQvDEbhDnASpUfSnbWc2u0AQADAgADeQADKgQ"}, Caption ="На той стороне улице будет виден вот этот дом.\nНам не обязательно пересекать улицу, эту красоту видно отовсюду."}},
            }}
        };
        var stage = new Stage()
        {
            Name = "mur_14",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Пошёл по наклонной",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step33_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step33_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step34_1, Order = 3, Delay = 0 },
            new() {AttachedStage = stage, Payload = step34_2, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_15()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQ8mNXjmefnG3T18VkSXiLbxtCoEqdAAIaDQACitrAUn6OI-T7wpscKgQ"}}, Caption ="Мы с тобой уже немного узнали про тэги. Если забыл, напомню: это такая подпись граффити-художника, его никнейм. Обычно тэги делаются быстро, практически на ходу, маркером или баллоном. Но не все так просто!"}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Так что можешь не стесняться своего интереса к разрисованным стенам и смело объяснять, почему это тоже искусство!",
            }}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ9GNXjp4XSNHwpsEPm6jVVwUdcItjAAKTvDEbhDnASpxumOE70hxeAQADAgADeQADKgQ"}, Caption ="Идем дальше в ритме стука трамвайных колес."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_15",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Тэги",
                Address = "",
            }
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
    public static Stage CreateStage_MUR_16()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Сейчас ты увидишь еще одну работу-долгожителя.",
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ9mNXkMhxT48NKNX5eV4Ch1LVMlikAAKVvDEbhDnASmAZLY2q3u9aAQADAgADeQADKgQ"}, Caption ="В 2016 году на фестиваль Street Vision приехал новосибирский каллиграф Родион Илюхин. Ему предложили сделать небольшую работу – выбор пал на заброшенный дом на перекрестке улицы Советской и переулка Нахановича. Так появилось послание: с верой, надеждой и любовью к людям и памятникам деревянного зодчества."}},
           }}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ-GNXkPpwhQ_ijMAvvCMcwV1V7l_EAAKWvDEbhDnASvl-IZO0FdilAQADAgADeQADKgQ"}, Caption ="Дальше мы с тобой увидим, что тема «памяти места» вообще часто волнует томских деятелей современного искусства."}},
           }}
        };

        var stage = new Stage()
        {
            Name = "mur_16",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Вера. Надежда. Любовь",
                Address = "",
            }
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
    public static Stage CreateStage_MUR_17()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ-mNXkXJQNEI_V-2ZuqwlN-Mf7nP2AAKavDEbhDnASgABHA0zPFw0EwEAAwIAA3kAAyoE"}, Caption ="В 2022 году фестиваль «мУкА. Склады искусства» проходил на территории пустующего кинотеатра «Киномир» в самом центре Томска. Нынешний владелец здания планирует сделать в нем центр современного искусства. Исполнится ли этот проект, сказать пока что сложно, но память и впечатления от фестиваля точно сохранятся! "}},
            }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIQ_GNXkapoQ1RgQMtBPcPL9d8j9eCoAAKwDQACitrAUsPL_xiTmenlKgQ"}}},
            }}
        }
        };

        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIQ_mNXkkh8aegC8_w5n_lReIySvUrOAAKivDEbhDnASq3-6uZtgPuKAQADAgADeQADKgQ"}, Caption ="Дальше ты видишь работу художника из Нижнего Новгорода Никиты Nomerz’а."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_17",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Ассамбляж «Киномир»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step3, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_18()
    {
        var step40 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRAAFjV5L8MrPXpJ2XP8ucaxY6YeNiHQACsLwxG4Q5wEpDUwyQ6LK8IgEAAwIAA3kAAyoE"}, Caption ="Символично, что именно в Нижнем сформировалась, пожалуй, самая мощная стрит-арт культура в стране. В 2022 году на фестивале «мУкА» Никита представил работу «Это не кино»"}},
            }}
        };
        var step41 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Ее смысл автор объясняет так: «С весны 2022 года в России массово закрываются кинотеатры, перестали работать более 850 кинозалов. Взамен закрытых кинотеатров нам досталась реальность. Мой проект создан на месте пустых рекламных конструкций закрытого «Киномира», первого в Томске кинотеатра. Имитация киноафиш напоминает зрителям, что кино закончилось, все происходит наяву».",
            }}
        };
        var step42 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRAmNXk29XLR-8Zc1E6z6qhlW-AQZ0AAKxvDEbhDnASrkgsNY5bqFTAQADAgADeQADKgQ"}, Caption ="Перемещаемся к главному фасаду «Киномиру»."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_18",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Это не кино»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step40, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step41, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step42, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_19()
    {
        var step43_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRCmNXnUrjKSTNhNmOjBMs_HFWsxnDAAItvTEbeGzAShAoeCV_mLhhAQADAgADeQADKgQ"}, Caption ="Перед тобой баннеры с персонажами питерского художника и дизайнера Андрея Люблинского.\nОн создал около 350 персонажей, часть из них – герои собственной мифологии художника, часть – оригинальные версии культовых фигур из истории и различных сфер современной культуры. Вы найдете в его коллекции кого угодно – от политиков и героев мультфильмов, до религиозных деятелей и домашних животных."}},
            }}
        };
        var step43_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRDGNXnalGe1MlnPjAFdfYU-HzhtH1AAJTEAACitrAUhrAoyfi7gI7KgQ"}}},
            }}
        }
        };
        var step44 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRDmNXndhHYx8cMSI9WpikbZzPA-5kAAIzvTEbeGzASv9wZfOXbkjGAQADAgADeQADKgQ"}, Caption ="А сейчас мы с тобой пойдем во внутренний двор кинотеатра. Ты был тут когда-нибудь? Между прочим, это культовое для томских райтеров место! Уже больше 20 лет двор захвачен граффитосами. Но первое, что мы увидим, свернув во двор, это свежая работа с фестиваля «мУкА»."}},
            }}
        };


        var stage = new Stage()
        {
            Name = "mur_19",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Серия работ «Good Bad»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step43_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step43_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step44, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_20()
    {
        var step45_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIREGNXnpkQ9cuK9Ql4u5ZFK_jLJrbEAAI5vTEbeGzASuhyRNPuwuInAQADAgADeQADKgQ"}, Caption ="Думаю, мало кто не поймет отсылки – достаточно прочитать культовую фразу <b>I’ll be back!</b>\nОбраз яркой и красивой девушки создал дуэт двух художниц, двух Тань с фамилией на «Б» - Татьяны Байбородиной и Татьяны Берсневой."}},
            }}
        };
        var step45_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "О своей работе они пишут так: «Отсылка к кинотеатру и к самим художницам лично. Это про то, как кинотеатр возвращается, но в другом обличии (как и Терминатор возвращается в женском), и это про нас»",
            }}
        };
        var step46 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIREmNXnuu7WvDCrF5ClM-Jays_Ts5CAAI8vTEbeGzASr6S0n20yzI1AQADAgADeQADKgQ"}, Caption ="Познакомились с женской версией Терминатора и пошли дальше."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_20",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Женский терминатор»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step45_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step45_2, Order = 2, Delay = 0 },
             new() {AttachedStage = stage, Payload = step46, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_21()
    {
        var step47_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRFGNXn2CCSZoIOx6wD69yd6jSLwfNAAJAvTEbeGzASrgkSxbwtbbrAQADAgADeQADKgQ"}, Caption ="Вот ты в одном из самых старых спотов Томска. Сменяются поколения граффити-художников, а место остается. Представляешь, сколько на этих стенах наслоений тэгов и рисунков?"}},
            }}
        };
        var step47_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRFmNXn5cfm0_37OpnHHLjZEwog2XFAALEEAACitrAUol1INYUyxaPKgQ"}}}},
           }}
        };
        var step48 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRGGNXn9HWZ3v7vFn7zOC4ore2BLDBAAJBvTEbeGzASgv_tfTzv2cTAQADAgADeQADKgQ"}, Caption ="Давай заглянем в еще одну арку – там ты увидишь уже немного облупившиеся и «завандаленные» работы 2017 года, которые делали художники из России и Германии. Как же они оказались в одном месте?"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_21",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Юнити»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step47_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step47_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step48, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_22()
    {
        var step49_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRGmNXoNDkeSLEzOgx7OfFL-DmwsGUAAJIvTEbeGzASt8iYSb_9nHpAQADAgADeQADKgQ"}}},
            }}
        };
        var step49_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRHGNXoSQgLx8u-Uo05j7Jh-qEnaQNAAI1EQACitrAUpmXQYUy0DNoKgQ"}}}},
            }}
        };
        var step50 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRHmNXoVxRK003II63MPR80twDLeLRAAJLvTEbeGzASpWWKaoVMBb9AQADAgADeQADKgQ"}, Caption ="Сейчас мы с тобой перейдем дорогу и отравимся в еще одно место, культовое для граффити-художников Томска. До 2019 года там в основном были текстовые граффити – каждый мог оставить свое высказывание. Иногда диалоги и целые поэмы занимали все стены. Все это есть и так. Но с 2019 года там появились и большие муралы."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_22",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Культурный обмен»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step49_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step49_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step50, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_23()
    {
        var step51_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRIGNXomLHE0p2s1YwOLFZs9PrYC8gAAJWvTEbeGzASl-oE9yZWzqiAQADAgADeQADKgQ"}}},
            }}
        };
        var step51_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRImNXonRFyxAKVTfxaANFIoFlZa8mAAJXvTEbeGzASkpogLAMNrwFAQADAgADeQADKgQ"}}},
            }}
        };
        var step51_3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRJGNXoqzUo5lkCQ7yZ0rhwuw1vg5IAAKkEQACitrAUiWT-Z8rj-K6KgQ"}}}},
            }}
        };
        var step52 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRJmNXotzhOl1HBkZkNAi-MYD34X0jAAJcvTEbeGzASk1BzjkGCtufAQADAgADeQADKgQ"}, Caption = "Пойдем, посетим еще один подобный двор."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_23",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Галерея «Local place»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step51_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step51_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step51_3, Order = 3, Delay = 0 },
            new() {AttachedStage = stage, Payload = step52, Order = 4, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_24()
    {
        var step53 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRKGNXo6zw1cErFUauXgHiOvCsM2DgAAJjvTEbeGzAStrkyfr7IPLUAQADAgADeQADKgQ"}, Caption = "Еще один двор в самом центре Томска.\nИ снова результаты большой граффити-тусы. Художники, приехавшие на фестиваль Street Vision в 2021 году, просто решили немного кайфануть от совместной работы в каком-то знаковом месте. На фестивале каждый делал свой проект, а все вместе они захватили пространство у бара Dealers. Эта территория уже много лет была спотом, но не таким масштабным. В 2021-м здесь оставили свои работы граффити-художники под никами Enor, Rasko, Rebel, Brusto, Mack, Chervi, Jovanny, Eknot, Uut4k, Dzhio. "}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_24",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Спорт «Dealers»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step53, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    public static Stage CreateStage_MUR_25_1()
    {
        var step54 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRKmNXpH_FWfmpa6tKP6VwuCUQ0I6UAAJvvTEbeGzASttIy6-yM1V0AQADAgADeQADKgQ"}, Caption = "Мы с тобой прошли уже большую часть маршрута. И, как это обычно бывает, самое сладенькое у нас еще впереди! Но, если ты такой же сладкоежка и любитель кофе, как и я, то нам надо сделать небольшой перерыв. И зайти в кондитерскую TORTA на Набережной реки Ушайки, 16"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_25_1",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step54, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    public static Stage CreateStage_MUR_25_2()
    {
        var step55_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRLGNXpQynvOFViC_ltjx3k50Di40IAAJyvTEbeGzASmC24DhTHyAIAQADAgADeQADKgQ"}, Caption = "Всего в Томске четыре таких кондитерских, но в этой особый акцент сделан на историю Томска. здесь и карта города, и эксклюзивные открытки, и даже фирменный торт «Томск»! Интересно, почему до сих пор не придумали торт «Студенческий»?"}},
            }}
        };
        var step55_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Помимо десертов, у Tortы есть свои завтраки в кондитерской на проспекте Фрунзе, 98. Пышные панкейки, сэндвичи и многое другое. А специально для тебя Торта дарит скидку 30 % на все кофейные напитки по промокоду «Ефим» – так меня зовут, надеюсь, не забыл? Давай зайдем и попробуем?",
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_25_2",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step55_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step55_2, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    public static Stage CreateStage_MUR_25_3()
    {
        var step56 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRLmNXp1vXsCfWVKsSJVmmQ0tIKSlMAAKEvTEbeGzASg-iIN5GpxWNAQADAgADeQADKgQ"}, Caption = "Идем дальше, до следующей точки рукой подать"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_25_3",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Торта",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step56, Order = 1, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

    public static Stage CreateStage_MUR_26()
    {
        var step57 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRMGNXqGT1K_Ppri74LBPddy5yqeKsAAKFvTEbeGzASjma_0h0mf8uAQADAgADeQADKgQ"}, Caption = "Как ты относишься к голубям? А к большим нарисованным голубям, которые что-то знают?\nВ 2015 году в Томске вместо полноценного фестиваля Street Vision прошла рейв-тусовка. По воспоминаниям участников, тогда у художников остались баллоны, и они решили сделать большой мурал. Так и появился голубь на здании по ул. Набережная реки Ушайки, 8а."}},
            }}
        };
        var step58 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRMmNXqIWR5njLuWW4QFflFKoKoSNsAAKGvTEbeGzASmEROEAgixtHAQADAgADeQADKgQ"}, Caption = "От больших голубей – к камерным работам."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_26",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Птицы знают",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step57, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step58, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_27()
    {
        var step59 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRNGNXqgLorAaPD3agYspW1i0_lEWIAAKJvTEbeGzASur6Ue5SqDM8AQADAgADeQADKgQ"}, Caption = "Знаешь, меня всегда радует, когда уличный художник чувствует место и встраивает свою работу так, что пространство становится частью произведения. Я так и не нашел, кто автор данной работы. Но видно, что ее делал мастер! Он не спорит со стеной, не хочет ее подчинить, он просто оставил на ней свое лирическое высказывание. О чем оно, ты можешь придумать сам – об одиночестве, поиске света или чем-то другом… Я не знаю, но мне просто нравится, что где-то в Томске мне светит такой фонарь."}},
            }}
        };
        var step60 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRNmNXql9gEhb05tJmumItiDi6GTPqAAKKvTEbeGzASkKXTov9-fR_AQADAgADeQADKgQ"}, Caption = "И снова нужно внимательно смотреть под ноги! Мы с тобой уже видели несколько арт-заплаток из «Спортивной истории», пойдем, найдем и ее."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_27",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Фонарь",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step59, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step60, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_28()
    {
        var step61 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIROGNXqxi50MFFkemwJOlSrr2maVVfAAKLvTEbeGzASuyp-mfd2CJ4AQADAgADeQADKgQ"}, Caption = "Здесь перед тобой история про великого просветителя земли сибирской Петра Макушина. Причем тут бомба? О, это была душещипательная история о том, как на книгоиздателя Макушина написали донос. Мол, он хочет взорвать цесаревича Николая, будущего царя Николая второго! Как развивалась и чем закончилась эта история, ты сможешь узнать вот <b><a href=\"https://www.izi.travel/ru/98b8-gorodskoy-marshrut-po-sledam-petra-makushina/ru\"в этом аудиогиде</a></b>"}},
            }}
        };
        var step62 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIROmNXqzK2q9zteAKOkuIvycQGk1AaAAKMvTEbeGzASmfijXbpD3gUAQADAgADeQADKgQ"}, Caption = "Дальше – еще одна работа с фестиваля Street Vision. Чтобы ее увидеть, перейдем через реку Ушайку."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_28",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Арт-заплатка «Бомба»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step61, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step62, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_29()
    {
        var step63_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRPGNXq9V0KLOBbVuqTqgWArA7YuhWAAKNvTEbeGzASgpLDAXNkZcRAQADAgADeQADKgQ"}, Caption ="В прошлом, 2021 году, фестиваль впервые вышел с масштабными работами в исторический центр, да еще и в знаковых точках! Проект по созданию больших арт-объектов в центре Томска так и назвали – «Выход в город»."}},
            }}
        };
        var step63_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRPmNXrBrr9R9l1H64riTUboZqIL12AAJIFAACitrAUmJKdPPb30lmKgQ"}}}},
            }}
        };
        var step64 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRTmNXrJHjmMn30cC4s1EvHgxQ5eHSAAJ-wDEb7iPBSlrCJeu5BxOaAQADAgADeQADKgQ"}, Caption ="Нам осталось посетить еще 2 места, вперед - на последний рывок!"}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_29",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Томские мотивы",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step63_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step63_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step64, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_30()
    {
        var step65 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRaWNXsDBIcFFureloT3iOQgp8SLj0AAKrvTEbeGzASo5XJHkgpSjHAQADAgADeQADKgQ"}, Caption ="Еще одна работа – воспоминание о «Выходе в город». Ты удивишься, но она выполнена вообще без краски! Художники обыграли тему кондиционеров и жестяных труб водостоков и использовали штукатурку. Выложив такой рисунок, они хотели примирить коммуникации и декор. Сделать так, чтобы они «вступили друг с другом в диалог». Чтобы у того, кто смотрит на «Рельеф №3», объемные формы работы дарили ощущение, что «солнце разгонит тучи, звезда не успеет упасть до того, как ты загадаешь желание»."}},
            }}
        };
        var step66 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRa2NXsFSGI_zqd2XWlF4fgyl0l5uUAAKtvTEbeGzASv_A6mroVlvNAQADAgADeQADKgQ"}, Caption ="Последний объект совсем рядом, пройдем дворами."}},
            }}
        };

        var stage = new Stage()
        {
            Name = "mur_30",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Рельеф №3",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step65, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step66, Order = 2, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_31()
    {
        var step67_1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIRbWNXsMhwqS3fwgpPcqo0evBth9ybAAKzvTEbeGzASh_FCf0TEN3VAQADAgADeQADKgQ"}, Caption ="И наконец мы с тобой пришли к, пожалуй, самой скандальной работе города!"}},
            }}
        };
        var step67_2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId="AwACAgQAAxkBAAIRb2NXsQ1U-4nQBci7COZdtDjIiDFQAAKjFQACitrAUmQdPpxvwSKxKgQ"}}, Caption ="И тут снова не обошлось без участников фестиваля Street Vision 2021."}},
            }}
        };

        var step68 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Вот и завершилась наша с тобой прогулка. Конечно, это только малая часть уличного искусства в Томске. Надеюсь, тебе было интересно, и ты теперь будешь больше внимания обращать на стены и тротуар, не лениться заходить во дворы и арки. И город будет открываться перед тобой все больше и больше.",
            }}
        };
        var step69 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Я буду хранить и вспоминать о нашей совместной прогулке, а если ты еще полон сил, мы можем прогуляться и по другим маршрутам – просто выбери один из них: куда пойдем! /choose",
            }}
        };


        var stage = new Stage()
        {
            Name = "mur_31",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Свинка-принцесса»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step67_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step67_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step68, Order = 3, Delay = 0 },
            new() {AttachedStage = stage, Payload = step69, Order = 4, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
}