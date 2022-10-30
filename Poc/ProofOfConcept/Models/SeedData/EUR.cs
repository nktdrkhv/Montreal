using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public static class EUR
{
    public static Route CreateRoute_EUR()
    {
        var stage1_ad = CreateStage_EUR_1_ad();
        var stage1 = CreateStage_EUR_1();
        var stage2 = CreateStage_EUR_2();
        var stage3 = CreateStage_EUR_3();
        var stage4 = CreateStage_EUR_4();
        var stage5 = CreateStage_EUR_5();
        var stage6 = CreateStage_EUR_6();
        var stage7 = CreateStage_EUR_7();
        var stage8 = CreateStage_EUR_8();
        var stage9 = CreateStage_EUR_9();
        var stage10 = CreateStage_EUR_10();
        var stage11 = CreateStage_EUR_11();
        var stage12 = CreateStage_EUR_12();
        var stage13 = CreateStage_EUR_13();
        var stage14 = CreateStage_EUR_14();
        var stage15 = CreateStage_EUR_15();


        var route = new Route()
        {
            Name = "eur",
            Label = "🌁 По ту сторону Европейского квартала",
            Description = "По ту сторону Европейского квартала. Это прогулка, во время которой мы увидим центр Томска с неожиданной стороны. Узнаем, где во дворах исторических корпусов Томского политеха профессора сажали картошку, а студенты играли в снежки. Посмотрим на стену, которой больше 110 лет, и на которой кто-то настойчиво пишет посвящения культовой группе Pink Floyd. Услышим исторические факты, малоизвестные легенды и мифы. И даже немного поговорим про НЛО.",
            InitialStage = stage1_ad
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
            new() {AttachedRoute = route, From = stage9, To = stage10},
            new() {AttachedRoute = route, From = stage10, To = stage11},
            new() {AttachedRoute = route, From = stage11, To = stage12},
            new() {AttachedRoute = route, From = stage12, To = stage13},
            new() {AttachedRoute = route, From = stage13, To = stage14},
            new() {AttachedRoute = route, From = stage14, To = stage15},
            new() {AttachedRoute = route, From = stage15, To = SeedData.ChooseStage},
        };
        route.Stages = stages;
        return route;
    }


    public static Stage CreateStage_EUR_1_ad()
    {
        var step0 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Media = new() { new() { Type = MediaType.Sticker, Sticker = new() { FileId = "CAACAgIAAxkBAAIfcGNdAran_fSKS_OkXA36iWJkZT4gAAKNIAACmNbRSo6rFbsq-M0AASoE" } } } } }
        };
        var step1 = new Step()
        {
            Name = "eur_1_coffee_ad",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIea2NbcmMtW9Cs7jongyTS_ppxsHFkAAKFvzEb3rPhSopkfeAqf72PAQADAgADeQADKgQ"}, Caption ="В такую погоду неплохо в путешествие взять стаканчик кофе... Поэтому, если ты не против, я забегу <b>в «Территорию кофе» на Усова 9Б</b>, возьму себе латте.\n\nЗаодно поздороваюсь с моим другом Михаилом Щеголевым, он открыл эту кофейню, и благодаря ему отсюда начинается день многих студентов. Михаил, кстати, тоже выпускник Томского политеха.\n\nЕсли хочешь, можешь тоже взять с собой горячий напиток в дорогу?"}}, Buttons = new(){new Button(){Type = ButtonType.InlineReplace, Label = "Да, очень хочу", Line =1, Target=new(){Name = "route=eur:step=eur_1_coffee_yes"}}, new Button() { Type = ButtonType.InlineReplace, Label = "Нет, спасибо", Line = 2, Target = new() { Name = "route=eur:step=eur_1_coffee_no" } } }}}
        };
        var step2 = new Step()
        {
            Name = "eur_1_coffee_yes",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIea2NbcmMtW9Cs7jongyTS_ppxsHFkAAKFvzEb3rPhSopkfeAqf72PAQADAgADeQADKgQ"}, Caption ="Отлично, только тебе по секрету: <b>скажи, что ты от Ефима, и тебе сделают скидку…</b>"}}, Buttons = new(){new Button(){Type = ButtonType.InlineReplace, Label = "А что дальше?", Line =1, Target=new(){Name = "route=eur:step=eur_2"}}}}}
        };
        var step3 = new Step()
        {
            Name = "eur_1_coffee_no",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIea2NbcmMtW9Cs7jongyTS_ppxsHFkAAKFvzEb3rPhSopkfeAqf72PAQADAgADeQADKgQ"}, Caption ="Дай мне пару секунд, я заберу свой латте, и мы отправимся в путь"}}, Buttons = new(){new Button(){Type = ButtonType.InlineReplace, Label = "А что дальше?", Line = 1, Target = new() { Name = "route=eur:step=eur_2" } }}}}
        };

        var stage = new Stage()
        {
            Name = "eur_1_ad",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 1,
                Latitude = 56.463883,
                Longitude = 84.957018,
                Label = "Территория кофе",
                Address = "ул. Усова, 9Б"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step0, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step1, Order = 2, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_1()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfcmNdA1xLAVvnmegVtueZHo2k2rscAALEvjEbIzfpSpSBRXG9Z45zAQADAgADeQADKgQ"}, Caption ="Итак, до первого пункта в нашем маршруте не так далеко, движемся в ту сторону…"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfdGNdA7Afbz--aeb9CMs1S3BDji5uAALHvjEbIzfpSsI4QTAcgStcAQADAgADeQADKgQ"}, Caption ="Идем, идем, не останавливаемся!"}}, Buttons = new() {new Button(){Type=ButtonType.InlinePause}}}}
        };

        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfdmNdA8OsriIpBduF8_FOZqDEDOzJAALIvjEbIzfpStGJNz1bnUNIAQADAgADeQADKgQ"}, Caption ="А теперь прямо, пока не перейдем пешеходный переход перед нами."}}, Buttons = new() {new Button(){Type=ButtonType.InlinePause}}}}
        };

        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIehmNbhJ9yLxdR-Cz9RZgj-xDitmBPAAKqvzEb3rPhSt3K0Ru6zhnbAQADAgADeQADKgQ"}, Caption ="Справа от нас еще один пешеходный, переходим его… смотрим по сторонам… и движемся прямо…"}}, Buttons = new() {new Button(){Type=ButtonType.InlinePause}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfemNdBjsNkMCoJmwAAYnedEAZzkIN5gACz74xGyM36UojwQu6YPBK8gEAAwIAA3kAAyoE"}, Caption ="Идем, пока слева от нас не появится шлагбаум. Нам к нему 👆"}}, Buttons = new() {new Button(){Type=ButtonType.InlinePause}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_1",
            Type = StageType.Regular,
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 5, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_2()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "<b>Ура, мы на месте!</b>\n\nИтак, наша история по ту сторону Европейского квартала начинается на границе двух эпох. Слева от тебя корпус №19 (ул. Усова, 4а), а справа №1 (ул. Советская, 73), он же горный корпус. Разница видна невооруженным глазом.\n\nНо я хочу тебе рассказать не о том, что есть, а о том, чего нет. Смотри 👇",
                }}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIffGNdGteFX3cySLrNDnmS4ttuuofvAAIEvzEbIzfpSsnEYrKLnb89AQADAgADeQADKgQ"}, Caption ="Здания не удалось вписать в общую картину Европейского квартала. Так, ближе к пешеходному переходу, откуда ты пришел, должен был находиться административный флигель, наверное, там бы сейчас работал, не покладая рук, наш ректор.\n\nА еще ближе к тебе хотели построить одноэтажный дом служб с прачечной. Почему эти здания так и не появились, остается только гадать. Возможно, просто не хватило средств. Зато сейчас у нас есть не менее необходимое здание 19-го корпуса, где учатся студенты. "}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIffmNdGybcJiP5m528InWrtTncSuGRAAIGvzEbIzfpSkXsRctCEDdOAQADAgADeQADKgQ"}, Caption ="Итак, мы входим <i>по ту сторону Европейского квартала</i>. По правой стороне от тебя должна быть лестница, видишь? Спускайся вниз, и идем дальше до следующей точки!"}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfgGNdHI6LMGpO4h-ek316axK5hAVdAAIQvzEbIzfpSpIMi7p3kgdJAQADAgADeQADKgQ"}}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_2",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 2,
                Latitude = 56.465281,
                Longitude = 84.953273,
                Label = "Вход двух эпох",
                Address = "ул. Советская, 73с1 (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_3()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfgmNdJmOdccAN_aACWZ0rn1rPZFzlAAJLvzEbIzfpShcDFyGMazwQAQADAgADeQADKgQ"}, Caption ="Мы во внутреннем дворе горного корпуса. Тут сохранился <i>небольшой участок деревьев, высаженных самим <b>Василием Афанасьевичем Обручевым!</b></i>"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfhGNdJ7Y0Hs5IuyKvq2v2uVe3bAxAAAJSvzEbIzfpSl5J_WC-JMsJAQADAgADeQADKgQ"}, Caption ="Профессор, академик, геолог, географ, писатель-фантаст (хотя бы про «Землю Санникова» ты точно слышал), выдающийся и разносторонний ученый придерживался интересной философии.\n\nЗабирая у природы ресурс, инженер обязан не уничтожить ее целостность полностью, а по возможности, даже приумножить ее богатство. Например, Обручев был инициатором высадки трав, кустарников и деревьев рядом с Закаспийской железной дорогой. Такая система защиты до сих пор является общепризнанной и часто используется.\n\nТак и деревья вокруг старинных корпусов ТПУ помогают зданиям оставаться неподвижными, ведь они находятся на склоне. И сибирские лиственницы, высаженные Обручевым, которые ты видишь перед собой, это еще одно напоминание об инженерной философии."}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfhmNdJ-En44hf5QJl5i-WLGqNKYKmAAJUvzEbIzfpSqKguY6QUTmRAQADAgADeQADKgQ"}, Caption ="Не отставай! Я убежал немного вперед, двигайся мне навстречу до следующей точки. Догоняй!"}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfiGNdJ_KVLjrw9vUF_Fjw9BiKbIBsAAJVvzEbIzfpSjkLpDn-ctofAQADAgADeQADKgQ"}}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfimNdKApD-UbeKmz1_dfPoe5RW-N-AAJVvzEbIzfpSjkLpDn-ctofAQADAgADeQADKgQ"}}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_3",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 3,
                Latitude = 56.465964,
                Longitude = 84.952920,
                Label = "Лес Обручева",
                Address = "ул. Советская, 73 (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_4()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIfjGNdKLFrp8O6J9CgJcLBJkweL7jXAAJYvzEbIzfpSlBNr7TGE9YDAQADAgADeQADKgQ"}, Caption ="Сейчас ты находишься возле стены. Казалось бы, стена и стена. Но, конечно, это не так, иначе зачем бы я тебя сюда привел? <b>Во-первых, этой стене как минимум 115 лет!</b>"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf7mNeAAEBm0dTpMjwHfPjJg4Ecl3-pAACrMAxGzfK8Up60rHtw_OrNAEAAwIAA3kAAyoE"}, Caption ="Построили ее в 1907 году. И вряд ли строители думали, что у студентов она будет ассоциироваться с музыкой.\n\nДело в том, что в 1979 году британская рок-группа Pink Floyd выпустила альбом под названием The Wall, что в переводе, конечно же, означает стена.Альбом стал легендарным, <b>а у студентов политеха появилась традиция: писать его название на этой стене.</b>"}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf8GNeAAE6EEQxkr70z4-xDs-NvzGDUgACrsAxGzfK8Uqo2uPhuD2-WAEAAwIAA3kAAyoE"}, Caption ="<b>Надпись The Wall появляется здесь уже около 40 лет.</b> Но ты ничего не пиши, все равно краской замажут, поверь мне! "}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf8mNeAAFnOTrgLYQqi-9ThaAAAQT0fY4AAq_AMRs3yvFKlHmy_y73hUsBAAMCAAN5AAMqBA"}, Caption ="Давай лучше двигаться дальше, впереди еще много всего интересного. Вот маршрут до следующей точки!"}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_4",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 4,
                Latitude = 56.465964,
                Longitude = 84.952920,
                Label = "THE WALL",
                Address = "пр. Ленина, 43а (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_5()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf9GNeENEnQtRmaC8j9MmYH_JzjamjAAK-wDEbN8rxSiyOA-1fecFUAQADAgADeQADKgQ"}, Caption ="Химический корпус (пр. Ленина, 43-а) ТПУ многие считают самым мистическим из всех исторических построек.\n\nЧего только стоят истории о подземных ходах, соединявших его с другими корпусами, таинственные маскароны на фасаде – тайна их происхождения и назначения, эксперименты с лекарствами против химического оружия в годы Великой Отечественной войны… И это только часть!\n\nВот ты, например, сейчас стоишь в месте, где в 40-е годы XX века проход был закрыт. Горожане это место старались обходить, а некоторые и вовсе боялись поднять глаза на окна жилой части корпуса. Видишь их?"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf9mNeEUo-EO34u1sl_kYPKz3mBViNAAK_wDEbN8rxSq9WAiUOZ0AQAQADAgADeQADKgQ"}, Caption ="Когда-то <b>в этой квартире жил сын самого Лаврентия Берии</b> – великого и ужасного начальника НКВД. Серго Берия и его мать приехали в Томск в эвакуацию в 1942 году.\n\nИзвестно о «Спецобъекте НКВД» тогда было только нескольким приближенным. Поэтому документов, подтверждающих его существование, нет и не могло быть. Откуда тогда слухи?\n\nСтрожайшую секретность портили неоднозначные личности, постоянно крутившиеся возле здания, машины, привозившие продукты, недоступные в те годы в Томске никому, даже высшим чинам института. Сохранились и байки невольных соседей Серго о черноволосом парне, одетом с иголочки, и его улыбке, вызывавшей разве что страх и желание поскорее уйти.\n\nДва года томичи шепотом передавали слухи о сыне Берии. А в 1944 году он уехал из Томска, не оставив о себе почти никакого следа. И лишь изредка старожилы вспоминают о «черноволосом парне», который то ли был, то ли не был в Томске."}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf-GNeEqlsoYS5eu9i_SIr0U56b5eNAALCwDEbN8rxSvPv_q8mGW6hAQADAgADeQADKgQ"}, Caption ="Движемся дальше до следующей точки. Кстати, пойдем тропою прислуги, о ней я тебе тоже немного расскажу. Вот маршрут!"}}}}
        };


        var stage = new Stage()
        {
            Name = "eur_5",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 5,
                Latitude = 56.466067,
                Longitude = 84.952052,
                Label = "Спецобъект НКВД",
                Address = "пр. Ленина, 43а (рядом)"
            },
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
    public static Stage CreateStage_EUR_6()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf-mNeFmx31pLqbNns0mTpXXXSOKx4AALEwDEbN8rxSpXKHf0_uLvgAQADAgADeQADKgQ"}, Caption ="Как завернешь за угол, пройди немного вперед и остановись у подъезда №6 – он будет по правой стороне от тебя."}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Этот подъезд — бывший черный ход для обслуживающего персонала в жилой флигель Химического корпуса. В начале XX века быт профессоров, как и всех остальных, не отличался особыми удобствами. Таких обыденных для нас с тобой вещей, как холодильник, стиральная машина, микроволновка, просто не существовало. Но ученый просто не мог тратить много времени на повседневные заботы.\n\nЕсли бы профессора сами себе постоянно готовили, то мы, наверное, только сейчас начали бы бурить нефтяные скважины! Так что, конечно, помощники сильно облегчали жизнь – и чай тебе вовремя принесут, и на стол накроют. Да и их самих институт не обижал. Называли таких людей не слугами, а полноправным рабочим персоналом, как и самих профессоров, между прочим. Оплата была стабильной и своевременной, пусть и не самой высокой. ", } }
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Теперь, когда мы пойдем дальше по этой тропе, ты будешь понимать, что она протоптана простыми людьми, которые помогали тем, кто творил историю.", } }
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf_GNeF4hJYYd-GyDXrfMYwPy4K10uAALIwDEbN8rxSkf4jaef45tyAQADAgADeQADKgQ"}, Caption ="Идем прямо и затем поворачиваем налево, а дальше вверх по лестнице. Перед тобой должен открыться вот такой вид."}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIf_mNeF60saOc_iK5pHKWRtLUhU2rpAALJwDEbN8rxSvOo6r8IoMKnAQADAgADeQADKgQ"}, }}}}
        };

        var stage = new Stage()
        {
            Name = "eur_6",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 6,
                Latitude = 56.465897,
                Longitude = 84.952494,
                Label = "Тропа прислуг",
                Address = "пр. Ленина, 43а (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_7()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Поверишь ли ты в то, что там, где ты сейчас стоишь, был огород служителей политеха? А он был. Жители корпусов любили побаловать себя свежими овощами, выращенными буквально под окнами квартир. А когда приходила зима, и снег покрывал профессорские грядки, студенты устраивали здесь нешуточные снежные баталии! А кое-кто поумнее, вроде профессора Бориса Петровича Вейнберга, заливал ледовые башни для экспериментов. Между прочим, в результате был создан термобур и в придачу устройство для консервирования града! Время шло, все менялось – так и бывшие огороды превратились в обычный двор. Но открою тебе секрет: здесь некоторые жильцы из профессорских квартир до сих пор держат небольшие грядки – выращивают клубнику. Но где, не покажу. Пусть это останется небольшой тайной.", } }
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgAmNeGdOWTuyCne1cvhmz8iddV2CeAALMwDEbN8rxSj9QMsVylRuCAQADAgADeQADKgQ"}, }}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgAAFjXhmyaMe1aXgUx6fuP44SL4M_rQACy8AxGzfK8UrMAyiACQb8bwEAAwIAA3kAAyoE"}, Caption ="Как же здесь тихо и спокойно, как будто время остановилось, правда? Насладишься этой атмосферой, можем следовать дальше по маршруту до следующей точки."}}}}
        };


        var stage = new Stage()
        {
            Name = "eur_7",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 7,
                Latitude = 56.464951,
                Longitude = 84.952202,
                Label = "Огород и башни изо льда",
                Address = "пр. Ленина, 43 (рядом)"
            },
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
    public static Stage CreateStage_EUR_8()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media, Buttons = new(){new(){Type = ButtonType.InlineReplace, Label = "Поближе 🔎", Target = new(){Name = "eur_8_1_zoom"}}} ,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgBGNeGnFz3yBvKSpDB9Ti2KwaLO0TAALNwDEbN8rxSh4Q34nx2-tAAQADAgADeQADKgQ"}, Caption ="Наш следующий объект восхищения – это парадная дверь. Выглядеть она должна вот так. Видишь?"}}}}
        };
        var step1_1 = new Step()
        {
            Name = "eur_8_1_zoom",
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgBmNeGo_aMju1n7kbxaOUYbvObcgBAALOwDEbN8rxSsf1_hE5jBgGAQADAgADeQADKgQ"}, Caption ="Наш следующий объект восхищения – это парадная дверь. Выглядеть она должна вот так. Видишь?"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Перед тобой забытый парадный ход. Древнегреческий бог Портун, хранитель ключей и входных дверей, давно покинул его. А когда-то многие ученые и профессора именно здесь переступали порог корпуса, приходя к первому директору Томского Технологического института Ефиму Зубашеву. Удивишься, но они могли днями не выходить из здания. А, собственно, зачем?\n\nЕсли из своей квартиры профессор мог напрямую попасть в корпус, а дальше в аудиторию или лабораторию. Конечно, я утрирую! Великим умам необходима прогулка, свежий воздух, но, согласись, если дорога в мир науки ведет через такой красивый порог, то глупо отказываться от возможности его переступить!\n\nУкрашающие вход колонны с лепниной так и зазывают зайти и посмотреть, что же находится по ту сторону. Но, как я и сказал, Портун давно покинул это место…", } }
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgCGNeHAABlyJEXY6HwsVMBR4mbHq6GQAC0cAxGzfK8Uq78zw7AhBP1wEAAwIAA3kAAyoE"}, Caption ="И мы его тоже покидаем! Вот тебе маршрут до следующей точки.\n\n"}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_8",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 8,
                Latitude = 56.464294,
                Longitude = 84.952001,
                Label = "Забытый Портун",
                Address = "пр. Ленина, 43 (рядом)"
            },
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
    public static Stage CreateStage_EUR_9()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgCmNeTgb1jAtSj6GDhPbitpl4x4nTAAJUwTEbN8rxSvk6vHZ2hNHGAQADAgADeQADKgQ"}, Caption ="Иногда самое интересное можно пропустить, просто не подняв вовремя голову. Мы с тобой прошли половину маршрута, поэтому давайте разомнем шею и рассмотрим вон ту крышу. Видишь?"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgDGNeTo0PuoLiD6nYzpCvFMDMkI9bAAJVwTEbN8rxSjBksCVBnzHXAQADAgADeQADKgQ"}, Caption ="Когда-то в нашем славном городе жил и работал выдающийся профессор-геофизик Борис Петрович Вейнберг.\n\nДа, да, тот, который строил во дворе корпуса ледяные башни. Он заглядывал в прошлое, изучая льды Арктики, и смотрел в будущее – по его проекту в вузе была собрана первая в мире модель безрельсовой дороги на магнитной подушке. Может быть, слышали про такого Илона Маска? Вот он планирует развить идею Вейнберга.\n\nКроме того, Борис Петрович любил посещать крыши. Зачем? Чтобы наблюдать за звездами, конечно же. И лучше всего ему наблюдалось на самой высокой на тот момент точке города – на крыше физического корпуса ТПУ (пр. Ленина, 43). Оттуда ученый организовал наблюдение за кометой Галлея – в мае 1910 года наша с вами планета пролетела сквозь ее хвост!\n\nВейнберг все это, конечно, видел и все тщательно записал в своем отчете. Так началась история астрономических наблюдений в Томске. Но на этом вполне удивительная история крыши не закончилась – в 1952 году тут установили оборудование для первого публичного сеанса телевещания в городе."}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgDmNeTr0iZI8Sr8O158gB5yu0CfKFAAJWwTEbN8rxSrme2EMiIetrAQADAgADeQADKgQ"}, Caption =" Я тебе не случайно предложил размять шею, потому что впереди нас ждет небольшой квест! Тебе придется найти несколько объектов, которые я загадал. Следуй дальше по маршруту и да начнется <i>Квестовый поход</i>!"}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgEGNeTwly1s85hlATnZldWNzwT2SkAAJXwTEbN8rxSpFScWc7cdq9AQADAgADeQADKgQ"}, Caption ="Иди прямо, пока не дойдешь до шлагбаума, он будет слева от тебя."}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgEmNeTzX34U5i8eTHossnEsS2_M71AAJYwTEbN8rxSgbdujSbgUjNAQADAgADeQADKgQ"}, Caption ="Дальше нам во внутренний двор. Иди прямо, а затем налево, как на фотографии."}}}}
        };
        var step6 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgFGNeT1wSWqPWl0LWt17NaF8RxM5hAAJZwTEbN8rxSs-vf6lwA7saAQADAgADeQADKgQ"}, Caption ="И теперь по прямой, вон до того миленького гаража. "}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_9",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 9,
                Latitude = 56.464222,
                Longitude = 84.950502,
                Label = "Крыша Вейнберга",
                Address = "пр. Ленина, 30а (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
                new() {AttachedStage = stage, Payload = step6, Order = 6, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_10()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Можно подумать, что двор за инженерным корпусом (пр. Ленина, 30-а) не такой уж впечатляющий. Но это пока ты не начнешь его изучать. Итак, как и обещал, я загадываю объект, а ты его находишь:",
                }}
        };

        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgFmNeVqfj1CENbZn0g1HS4DueRqSPAAJ2wTEbN8rxSoQJNJQUgEFjAQADAgADeQADKgQ"}, Caption ="Это сооружение появилось чуть раньше, чем все имперские корпуса ТПУ, в 1894 году. На некоторых картах ты даже не найдешь его адреса. Нашел?"}}}}
        };
        var step2_y = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgGGNeVrMbdPuEQIlpBcK6Y5H4X1MiAAJ3wTEbN8rxShhnDmPzWoyRAQADAgADeQADKgQ"}, Caption ="Такой старый, но еще держится!"}}}}
        };
        var step2_n = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgGGNeVrMbdPuEQIlpBcK6Y5H4X1MiAAJ3wTEbN8rxShhnDmPzWoyRAQADAgADeQADKgQ"}, Caption ="Вот он, старичок!"}}}}
        };

        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgGmNeVv06gwWJdD8RGs6NcMbWlRmDAAJ4wTEbN8rxSulJaRa967O1AQADAgADeQADKgQ"}, Caption ="Это не единственное жилое помещение поблизости. Следуй тропой прислуги, и ты найдешь его. Нашел?"}}}}
        };
        var step3_y = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgHGNeVw29-gABkSnnR5IK8e3qHID4qwACecExGzfK8Uq4GfNBeWlaKwEAAwIAA3kAAyoE"}, Caption ="Вот бы жить тут! Вышел из дома и сразу на учебу!"}}}}
        };
        var step3_n = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgHGNeVw29-gABkSnnR5IK8e3qHID4qwACecExGzfK8Uq4GfNBeWlaKwEAAwIAA3kAAyoE"}, Caption ="А, вот он где спрятался! Вот бы жить тут! Вышел из дома и сразу на учебу!"}}}}
        };

        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgHmNeV0uURHbGW8PRLoNL0RYurPV_AAJ6wTEbN8rxSrXe50lfP456AQADAgADeQADKgQ"}, Caption ="Когда холод, нужно тепло. Котельная нам в помощь. Вода, испаряясь, превращается пар. А куда дым выходит? Нашел?"}}}}
        };
        var step4_y = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgIGNeV5ynajDXgEKDSpS-6m3zzLlzAAJ7wTEbN8rxSlaSVFHb3saJAQADAgADeQADKgQ"}, Caption ="Красивый вид, наверное, сверху!"}}}}
        };
        var step4_n = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgIGNeV5ynajDXgEKDSpS-6m3zzLlzAAJ7wTEbN8rxSlaSVFHb3saJAQADAgADeQADKgQ"}, Caption ="А эта труба вовсе и не прячется. Наверное, красивый вид оттуда на наш университет!"}}}}
        };

        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgImNeV7kgGjPCrMkEaenfOpF4xrxWAAJ8wTEbN8rxSpD9KVfPAaEPAQADAgADeQADKgQ"}, Caption ="Найдешь корпус механический (пр. Ленина, 30, стр.1), найдешь и забытый исторический механизм, который мог доставить груз в открытое окно. Нашел?"}}}}
        };
        var step5_y = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgJGNeV8hQdeNpGb69KFTHJgmopN9AAAJ-wTEbN8rxSkKlxKR1svqaAQADAgADeQADKgQ"}, Caption ="Интересно, что же с помощью него в окно доставляли… Будет у меня дом, такой же себе сделаю!"}}}}
        };
        var step5_n = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgJGNeV8hQdeNpGb69KFTHJgmopN9AAAJ-wTEbN8rxSkKlxKR1svqaAQADAgADeQADKgQ"}, Caption ="А вон где он спрятался! Будет у меня дом, такой же себе сделаю!"}}}}
        };

        var step6 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgJmNeV-_YYScg-qkXQjDZx8jWW0t0AAJ_wTEbN8rxSlVZLkGrrE2CAQADAgADeQADKgQ"}, Caption =""}}}}
        };
        var step6_y = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId=""}, Caption ="Вот тебе фотография, где множество кирпичей. Это не издевательство. Найди кирпич с фамилией неизвестного купца на ней. Нашел?"}}}}
        };
        var step6_n = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgKGNeWBlKFoVObeeHE2OSlsz42AtbAAKAwTEbN8rxSg2EWcvGcX6HAQADAgADeQADKgQ"}, Caption ="Какой же ты глазастый! Будь у меня такое зрение, я бы микроскопом, наверное, и не пользовался никогда!"}}}}
        };

        var step7 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgKGNeWBlKFoVObeeHE2OSlsz42AtbAAKAwTEbN8rxSg2EWcvGcX6HAQADAgADeQADKgQ"}, Caption ="Вот он, красавец! Узнать бы теперь, кто этот человек…"}}}}
        };

        var step8 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgKmNeWPXwpSZINsf6IWZOH3naEVtmAAKBwTEbN8rxStXaIWVJmBM-AQADAgADeQADKgQ"}, Caption ="На этом с Квестовым походом все. Надеюсь, тебе понравилось! Исследовать старинные здания интересно, никогда не знаешь, что еще в них найдешь. Наша прогулка на этом не закончилась, давай двигаться дальше к следующей точке."}}}}
        };
        var step9 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgLGNeWTAQEK6AHy48Cgg9wWZtahhMAAKCwTEbN8rxSjQIW5Dzn-InAQADAgADeQADKgQ"}}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_10",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 10,
                Latitude = 56.464252,
                Longitude = 84.949432,
                Label = "Квестовый поход",
                Address = "пр. Ленина, 30/3 (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
                new() {AttachedStage = stage, Payload = step6, Order = 6, Delay = 0 },
                new() {AttachedStage = stage, Payload = step7, Order = 7, Delay = 0 },
                new() {AttachedStage = stage, Payload = step8, Order = 8, Delay = 0 },
                new() {AttachedStage = stage, Payload = step9, Order = 9, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_11()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgLmNeWk5X774RdvvBQv7MWtzlRGHGAAKGwTEbN8rxSva3CdR8b3HdAQADAgADeQADKgQ"}, Caption ="Мы с тобой находимся перед проходом во внутренний двор Главного корпуса ТПУ (пр. Ленина, 30) – южным крылом Главного корпуса.\n\nНо, прежде чем мы туда пойдем, я расскажу тебе вот что. Может показаться странным, но достраивался корпус уже во время учебы первых студентов. Открылся институт, а ныне университет, в 1900 году, а Главный корпус строили с 1897 по 1907 годы. Причем северное и южное крыло здания никто изначально строить не планировал! <i>Но лекционные аудитории и кабинеты были необходимы, так что их построили.</i>"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgMGNeWnzhAypvMjgZuMdM4Lip0ntJAAKHwTEbN8rxSv8YUW3dZypjAQADAgADeQADKgQ"}, Caption ="Правда, с небольшими погрешностями: кое-где пришлось замуровывать окна! Видишь, вон те два?\n\nПодозреваю, что от них сильно дуло, так что кирпичи укладывали второпях. Присмотрись, там даже оконную раму забыли вытащить. А может, там еще какой исторический артефакт припрятан… Такое вот оно: делится на две части, но никак не разделить. В двух словах: делимое неделимое."}}}}
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgMmNeWpwaZjJaUGR63AABoBeTyJ_RJQACiMExGzfK8UrWCuTmw4EY5wEAAwIAA3kAAyoE"}, Caption ="А теперь идем в одно из самых моих любимых мест в политехе – внутренний двор за Главным корпусом! Держи маршрут – проходим вперед, а затем сразу направо."}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgNGNeWreiMZtZsBdDTdUU6z5WWUrMAAKJwTEbN8rxSvPQpQLDlQQ6AQADAgADeQADKgQ"}, Caption ="И дальше идем вон до того входа."}}}}
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgNmNeWtLpKGvZSiVUzDnRbONX1aYoAAKKwTEbN8rxSqjWKiYZDWb_AQADAgADeQADKgQ"}, Caption ="Как дойдешь, встань, чтобы вход был прямо перед тобой, примерно вот так."}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_11",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 11,
                Latitude = 56.464790,
                Longitude = 84.949458,
                Label = "Делимое неделимое",
                Address = "пр. Ленина, 30 (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                 new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_12()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Надеюсь, тебе нравится внутренний двор – сейчас это идеальное место для неспешных прогулок. Но таким его никто не задумывал. Появилось это место только тогда, когда стало необходимым. С 1897 по 1900 годы никаких клумб тут не было – шла большая стройка, так что на заднем дворе хранили стройматериалы, да и вообще мало думали о его красоте. Еще здесь был постоялый двор для призванных в армию и место для подготовки техники к сельскохозяйственным работам – к концу XX века чего здесь только не было! Но сейчас я тебе хочу показать настоящий черный ход. Исторически так сложилось, что его всегда располагали зеркально парадному входу с другой стороны здания. Правда, особо его никогда не украшали. Да и зачем? Ведь нужен был черный, он же служебный, ход для вывоза мусора, доставки припасов и прохода прислуги, а никак не для красоты. Сейчас, как вы видите, этот ход облагорожен, а курьеров, доставляющих почту и заказы в университет, можно увидеть не здесь, а у главных дверей.", } }
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Иногда через эти двери заходит ректор. Может, и сейчас его получится застать.", Timer = new() { Delay = 3 } } }
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Подождем его немного.", Timer = new() { Delay = 3 } } }
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Еще чуть-чуть подождем. Ты же никуда не торопишься?", Timer = new() { Delay = 4 } } }
        };
        var step5 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgOGNeXD4AASqp1e0qM4NJaQkTENFjkwACjsExGzfK8Uoe3t0q_y59YQEAAwIAA3kAAyoE"}, Caption ="Ладно, идем дальше до следующей точки."}}}}
        };

        var stage = new Stage()
        {
            Name = "eur_12",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 12,
                Latitude = 56.465386,
                Longitude = 84.949908,
                Label = "Чёрный ход",
                Address = "пр. Ленина, 30 *пядом"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
                new() {AttachedStage = stage, Payload = step5, Order = 5, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_13()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Мы сейчас стоим перед проходом через северное крыло Главного корпуса. Пройдем через него мы чуть позже. А пока я хочу, чтобы ты нашел вот этот балкон. <b>ФОТОГРАФИЯ БАЛКОНА?</b> Видишь его?", } }
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Это еще одна малозаметная архитектурная особенность этого корпуса — балконы. И их сразу два! Признайся, не заметил их? Оба находятся в северном крыле корпуса. Один – с видом на Университетскую рощу, другой – во внутреннем дворе.\n\nИнтересно, что изначально в проекте никаких балконов не было. Лишь со временем, когда в проект внесли две геодезические лаборатории, в Главном корпусе появились «смотровые площадки» для геодезической съемки. Случилось это в 1908 году.\n\nСейчас, правда, балконы по назначению не используют." } }
        };
        var step3 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgOmNeaKIi5fa8eqf3RVd5SJnCVaNfAAKlwTEbN8rxStRCSMAF9T2FAQADAgADeQADKgQ"}, Caption ="Мы движемся к концу нашего маршрута, ныряй в проход под северным крылом…"}}}}
        };
        var step4 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgPGNeaK4j1yixCJfZWrpNvFWwW6-4AAKmwTEbN8rxSli96kyCPBtBAQADAgADeQADKgQ"}, Caption ="И  остановись вот здесь, напротив корпуса №12."}}}}
        };


        var stage = new Stage()
        {
            Name = "eur_13",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 13,
                Latitude = 56.465719,
                Longitude = 84.949432,
                Label = "Забытая архитектура",
                Address = "пр. Ленина, 30 (рядом)"
            },
        };
        var order = new List<StepInStage>()
            {
                new() {AttachedStage = stage, Payload = step1, Order = 1, Delay = 0 },
                new() {AttachedStage = stage, Payload = step2, Order = 2, Delay = 0 },
                new() {AttachedStage = stage, Payload = step3, Order = 3, Delay = 0 },
                new() {AttachedStage = stage, Payload = step4, Order = 4, Delay = 0 },
            };
        stage.Steps = order;
        return stage;
    }
    public static Stage CreateStage_EUR_14()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "Слышал ли ты что-нибудь про 12-й корпус ТПУ (пр. Ленина, 30, стр. 3)?\n\nУверен, что нет, а если и обращал внимание, то наверняка думал, что это просто хозяйственная пристройка. И это, в принципе, правильно. Это здание мы на общем плане первых корпусов и построек ТПУ не найдем, но в начале XX века солдаты использовали его в качестве общей бани.\n\nА еще раньше, если верить предположениям, часть постройки использовали под конюшню. Но самое интересное было позднее – в конце второй половины XX века там находился Сибирский научно-исследовательский центр по исследованию аномальных явлений.\n\n<i>Представляешь, была когда-то и такая государственная организация при вузе.</i>", } }
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "И вот мы с тобой завершаем нашу прогулку. Последняя локация, которую я хочу тебе показать, это <i>Инженерный дворик</i> – он справа от тебя.",
                }}
        };

        var stage = new Stage()
        {
            Name = "eur_14",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 14,
                Latitude = 56.465976,
                Longitude = 84.949264,
                Label = "Кони, бани и аномалии",
                Address = "пр. Ленина, 30с3 (рядом)"
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
    public static Stage CreateStage_EUR_15()
    {
        var step1 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Media,
                Media = new() {new(){Type=MediaType.Photo, Photo = new(){FileId="AgACAgIAAxkBAAIgPmNeaUeqB1CrCpW0Vk7hSK1A0bnYAAKqwTEbN8rxSuIDSVk34bUHAQADAgADeQADKgQ"}, Caption ="<b>Инженерный дворик</b> — новая городская локация. Открылся он к 126-летию со дня основания вуза. И за первые пять месяцев его посетили более 9 000 человек!\n\nЧего там только не было: лекции блогеров и экспертов, выставки современного искусства, концерты, DJ-сеты, мастер-классы… Все сразу и не перечислишь.\n\nЛокацию украшают 139-метровый красочный мурал, инсталляции от молодых художников, фотографии сотрудников ТПУ — снимки топлив будущего и материалов под микроскопом, интерьеров корпусов вуза, исследовательского ядерного реактора, научного оборудования.\n\nИ локация обязательно будет обновляться, так что встретимся с тобой в Инженерном дворике!"}}}}
        };
        var step2 = new Step()
        {
            Fragments = new() { new() { Type = FragmentType.Text, Text = "А на этом у меня все! Мы побывали с тобой по ту сторону Европейского квартала.Ну а если ты еще полон сил, мы можем прогуляться и по другим маршрутам – просто выбери один из них: куда пойдем!" } }
        };

        var stage = new Stage()
        {
            Name = "eur_15",
            Type = StageType.Regular,
            Location = new Spot()
            {
                Prefered = SpotType.Label,
                Number = 15,
                Latitude = 56.465991,
                Longitude = 84.949908,
                Label = "Инженерный дворик",
                Address = "пр. Ленина, 30с3 (рядом)"
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