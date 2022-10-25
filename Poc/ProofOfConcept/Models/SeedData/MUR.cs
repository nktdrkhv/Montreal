using System.Text.RegularExpressions;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class MUR
{
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
                Address = "л. Кузнецова, 33",
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
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Арт-заплатка «Значок ГТО»",
                Address = "",
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
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Арт-заплатка «Самолёт»",
                Address = "",
            }
        };
        var order = new List<StepInStage>()
        {
            new() {AttachedStage = stage, Payload = step17_1, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step17_2, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step17, Order = 3, Delay = 0 },
            new() {AttachedStage = stage, Payload = step18, Order = 4, Delay = 0 },
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
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Граффити-спот",
                Address = "",
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
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Река жизни",
                Address = "",
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
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "Граффити-спот",
                Address = "",
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
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_20()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_21()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_22()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_23()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_24()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_25()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };


        var stage = new Stage()
        {
            Name = "mur_25",
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_26()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };


        var stage = new Stage()
        {
            Name = "mur_26",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "",
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
    public static Stage CreateStage_MUR_27()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };


        var stage = new Stage()
        {
            Name = "mur_27",
            Type = StageType.Regular,
            Location = new()
            {
                Latitude = 0.0,
                Longitude = 0.0,
                Label = "«Птицы знают»",
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
    public static Stage CreateStage_MUR_28()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_29()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_30()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_MUR_31()
    {
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "",
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
        };
        var step = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
            Media = new() {new(){Type=MediaType.Sound, Sound = new() {Type = SoundType.Voice, Voice=new(){FileId=""}}, Caption =""}},
            Buttons = new() {new() {Type = ButtonType.InlineLink, Link = ""} }}}
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
            new() {AttachedStage = stage, Payload = step, Order = 1, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 2, Delay = 0 },
            new() {AttachedStage = stage, Payload = step, Order = 3, Delay = 0 },
        };
        stage.Steps = order;
        return stage;
    }

}