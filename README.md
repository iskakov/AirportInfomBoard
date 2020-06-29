# AirportInfomBoard
Тестовое задание на техническое собеседование в компанию "Випакс"
Описание тестового задания:

Задание соискателю на должность разработчик C# / WPF"
Информационное табло аэропорта

Создать приложение для отображения информации о работе аэропорта.

Из текстового файла загрузить расписание рейсов.
Расписание содержит информацию о
 - типе самолёта (*)
 - вылет/прилёт
 - времени вылета/прилёта
 - городе (куда вылетел/откуда прилетел)

(*) Тип самолёта определяет его максимальную вместимость,
фактическое количество пассажиров определяется случайным образом в процессе работы приложения.

При старте приложения начинается имитация работы аэропорта, согласно расписанию.
Скорость имитации задается множителем (от x1 до x10000).
Скорость имитации можно изменять во время работы приложения.

Интерфейс приложения.

Сверху - строка информации о последнем рейсе.

Основная область (слева) -  количество пассажиров (прилёт)
 - в последнем рейсе
 - за последние 24 часа
 - сумма за всё время работы

Основная область (справа) -  количество пассажиров (вылет)
 - в последнем рейсе
 - за последние 24 часа
 - сумма за всё время работы

Снизу - гистограмма (прилёт/вылет) за последние 24 часа (накопление за 1 час).

Каждое изменение информации должно быть анимировано и привлекать внимание.

В ходе разработки были выполнены следующие задачи:
1. Описана модель;
2. Создан интерфейс;
3. Была выполнена привязка интерфейса к модели;
4. Описана логика имитации;
5. Добавлена генерация файла с расписанием и считывание из файла;
6. Добавлена анимация.

Все задачи описанные в тексте тестового задания были выполнены.
